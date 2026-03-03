namespace LINQall
{
    public class StudentData
    {
        public static readonly IList<Student> students = new List<Student>()
        {
             new Student() {StudentId = 1, Name = "John", Age = 13, StandardId = 1},
             new Student() {StudentId = 2, Name = "Moin", Age = 21, StandardId = 1},
             new Student() {StudentId = 3, Name = "Bill", Age = 18, StandardId = 2},
             new Student() {StudentId = 4, Name = "Ram", Age = 20, StandardId = 2},
             new Student() {StudentId = 5, Name = "Ron", Age = 15},
        };
    }
}
