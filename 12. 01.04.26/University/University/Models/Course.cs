using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
        // mis on ICollection??
        //ICollection on üldine kogutüüp, mis võimaldab hoida mitut objekti. (Nimekiri) kuhu saab panna mitu objekti, aga ei pea
        public ICollection<Enrollment> Enrollments { get; set; }
        //miks siin ei kasutada ICollection, vaid lihtsalt OfficeAssignment?
        //Sest OfficeAssignment on üks-ühele seos Instructoriga, st iga õpetaja
        //võib omada ainult ühte kontoripinda. Seega ei ole vaja kasutada
        //ICollectioni, kuna ei ole vaja hoida mitut OfficeAssignment objekti.
        //võik kasutada ICollectioni, siis see tähendaks, et õpetaja
        //võiks omada mitut kontoripinda, mis ei ole meie mudelis korrektne.
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}