using University.Models;
using University.ServiceInterface;
using University.ViewModel.CoursesVM;

namespace University.Services
{
    public class FileServices : IFileServices
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FileServices> _logger;
        private readonly string[] _allowedExtensions = { ".pdf", ".doc", ".docx", ".txt", ".xlsx", ".xls", ".ppt", ".pptx", ".jpg", ".jpeg", ".png", ".gif" };

        public FileServices(IWebHostEnvironment environment, ILogger<FileServices> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        /// <summary>
        /// Upload a file and associate it with a course
        /// </summary>
        public async Task<string> UploadFileAsync(IFormFile file, int courseId)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new ArgumentException("File is empty");
                }

                if (!ValidateFile(file))
                {
                    throw new ArgumentException("File validation failed");
                }

                // Create course-specific directory
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "courses", courseId.ToString());
                
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique filename
                string uniqueFileName = GenerateUniqueFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                _logger.LogInformation($"File uploaded successfully: {uniqueFileName} for course {courseId}");

                // Return relative path
                return $"/uploads/courses/{courseId}/{uniqueFileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error uploading file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Download a file by its path
        /// </summary>
        public async Task<(byte[] fileContent, string fileName, string contentType)> DownloadFileAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("File path is required");
                }

                // Sanitize path to prevent directory traversal
                string sanitizedPath = Path.GetFullPath(filePath);
                string uploadsBasePath = Path.GetFullPath(Path.Combine(_environment.WebRootPath, "uploads"));

                if (!sanitizedPath.StartsWith(uploadsBasePath))
                {
                    throw new UnauthorizedAccessException("Invalid file path");
                }

                string fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));

                if (!File.Exists(fullPath))
                {
                    throw new FileNotFoundException($"File not found: {filePath}");
                }

                byte[] fileContent = await File.ReadAllBytesAsync(fullPath);
                string fileName = Path.GetFileName(fullPath);
                string contentType = GetContentType(fullPath);

                _logger.LogInformation($"File downloaded: {fileName}");

                return (fileContent, fileName, contentType);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error downloading file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Delete a file from storage
        /// </summary>
        public async Task<bool> DeleteFileAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("File path is required");
                }

                // Sanitize path to prevent directory traversal
                string sanitizedPath = Path.GetFullPath(filePath);
                string uploadsBasePath = Path.GetFullPath(Path.Combine(_environment.WebRootPath, "uploads"));

                if (!sanitizedPath.StartsWith(uploadsBasePath))
                {
                    throw new UnauthorizedAccessException("Invalid file path");
                }

                string fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    _logger.LogInformation($"File deleted: {filePath}");
                    return await Task.FromResult(true);
                }

                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting file: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get all files for a specific course
        /// </summary>
        public async Task<List<string>> GetCourseFilesAsync(int courseId)
        {
            try
            {
                string courseFolder = Path.Combine(_environment.WebRootPath, "uploads", "courses", courseId.ToString());

                if (!Directory.Exists(courseFolder))
                {
                    return await Task.FromResult(new List<string>());
                }

                var files = Directory.GetFiles(courseFolder)
                    .Select(f => $"/uploads/courses/{courseId}/{Path.GetFileName(f)}")
                    .ToList();

                return await Task.FromResult(files);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting course files: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Check if file exists
        /// </summary>
        public async Task<bool> FileExistsAsync(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    return await Task.FromResult(false);
                }

                string fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
                return await Task.FromResult(File.Exists(fullPath));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error checking file existence: {ex.Message}");
                return await Task.FromResult(false);
            }
        }

        /// <summary>
        /// Validate file before upload (check size, extension, etc.)
        /// </summary>
        public bool ValidateFile(IFormFile file, long maxSizeInBytes = 10485760) // 10MB default
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    _logger.LogWarning("File is empty");
                    return false;
                }

                if (file.Length > maxSizeInBytes)
                {
                    _logger.LogWarning($"File size {file.Length} exceeds maximum allowed {maxSizeInBytes}");
                    return false;
                }

                string fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_allowedExtensions.Contains(fileExtension))
                {
                    _logger.LogWarning($"File extension {fileExtension} is not allowed");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error validating file: {ex.Message}");
                return false;
            }
        }

        // Helper methods
        private string GenerateUniqueFileName(string originalFileName)
        {
            string fileExtension = Path.GetExtension(originalFileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFileName);
            return $"{fileNameWithoutExtension}_{Guid.NewGuid()}{fileExtension}";
        }

        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension switch
            {
                ".pdf" => "application/pdf",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                ".xls" => "application/vnd.ms-excel",
                ".ppt" => "application/vnd.ms-powerpoint",
                ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                ".txt" => "text/plain",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                _ => "application/octet-stream"
            };
        }

        public Task<List<FileToApi>> FilesToApi(CourseCreateViewModel courseViewModel, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
