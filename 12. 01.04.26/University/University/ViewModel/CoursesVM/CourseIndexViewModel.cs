
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Models;

namespace University.ViewModel
{
    public class CourseIndexViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public CourseDepartmentIndexViewModel Departments { get; set; }
    }

    public class CourseDepartmentIndexViewModel
    {
        public string Name { get; set; }
    }
}