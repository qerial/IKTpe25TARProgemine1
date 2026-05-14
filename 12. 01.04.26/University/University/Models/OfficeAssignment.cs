using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class OfficeAssignment
    {
        //kui soovite konkreetselt välja tuua, et Instructorid on nii OfficeAssignementi
        //peamine võti kui ka võõrvõti, siis saate kasutada [Key] ja [ForeignKey] atribuute:
        [Key]
        public int InstructorId { get; set; }
        public string Location { get; set; } = string.Empty;
        public Instructor Instructor { get; set; }
    }
}
