using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using University.Models;

namespace University.ViewModel
{
    public class StudentIndexViewModel
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 1)]
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
    }
}
