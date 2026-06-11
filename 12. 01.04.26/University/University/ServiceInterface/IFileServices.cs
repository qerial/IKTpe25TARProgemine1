namespace University.ServiceInterface
{
    public interface IFileServices
    {
        /// <summary>
        /// Upload a file and associate it with a course
        /// </summary>
        Task<string> UploadFileAsync(IFormFile file, int courseId);

        /// <summary>
        /// Download a file by its path
        /// </summary>
        Task<(byte[] fileContent, string fileName, string contentType)> DownloadFileAsync(string filePath);

        /// <summary>
        /// Delete a file from storage
        /// </summary>
        Task<bool> DeleteFileAsync(string filePath);

        /// <summary>
        /// Get all files for a specific course
        /// </summary>
        Task<List<string>> GetCourseFilesAsync(int courseId);

        /// <summary>
        /// Check if file exists
        /// </summary>
        Task<bool> FileExistsAsync(string filePath);

        /// <summary>
        /// Validate file before upload (check size, extension, etc.)
        /// </summary>
        bool ValidateFile(IFormFile file, long maxSizeInBytes = 10485760); // 10MB default
    }
}
