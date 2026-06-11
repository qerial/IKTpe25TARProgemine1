namespace University.Models
{
    public class FileToApi
    {
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? ExistingFilePath { get; set; }
        public long FileSize { get; set; }
        public string? ContentType { get; set; }
        public int CourseId { get; set; }
        public DateTime UploadedDate { get; set; }

        // Foreign key
        public Course? Course { get; set; }
    }
}
