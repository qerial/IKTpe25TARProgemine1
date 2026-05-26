using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using University.Data;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        //on vaja kutsuda välja University 
        private readonly UniversityContext _context;

        public CourseController
            (
                UniversityContext context
            )
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _context.Courses
                .Include(c => c.Departments)
                .AsNoTracking()
                .ToListAsync();

            return View(result);
        }
    }
}
