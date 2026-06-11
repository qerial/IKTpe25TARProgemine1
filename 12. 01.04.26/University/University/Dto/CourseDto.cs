using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.ViewModel.CoursesVM;

namespace University.Dto
{
    public class CourseDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public DepartmentViewModel? Department { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ImageViewModel> FileToApis { get; set; }
            = new List<ImageViewModel>();
    }
}

