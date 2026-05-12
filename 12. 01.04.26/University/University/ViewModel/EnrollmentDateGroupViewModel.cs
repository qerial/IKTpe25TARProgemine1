
using Microsoft.AspNetCore.Mvc;
using University.Controllers;

namespace University.ViewModel
{
    public class EnrollmentDateGroupViewModel 
    {
        public DateTime? EnrollmentDate { get; set; }
        public int StudentCount { get; set; }

    }
}
