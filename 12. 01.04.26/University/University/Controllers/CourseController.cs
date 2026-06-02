using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;
using University.ViewModel;
using University.ViewModel.CoursesVM;

namespace University.Controllers
{
    public class CourseController : Controller
    {
        //on vaja kututada välja Univercity constructor 
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
            var course = _context.Courses
                .Include(c => c.Department)
                .Select(c => new CourseIndexViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
                    DepartmentId = c.DepartmentId,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department.Name
                    }
                });

            return View(course);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = await _context.Courses
                .Where(c => c.CourseId == id)
                .Select(c => new CourseUpdateViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        DepartmentName = c.Department != null ? c.Department.Name : null
                    }
                })
                .FirstOrDefaultAsync();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CourseUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var course = new Course
                {
                    CourseId = vm.CourseId,
                    Title = vm.Title,
                    Credits = vm.Credits,
                    Department = new Department
                    {
                        Name = vm.Department.DepartmentName
                    }
                };

                _context.Update(course);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            PopulateDepartmentDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CourseCreateViewModel vm)
        {

            var course = new Course
            {
                CourseId = vm.CourseId,
                Title = vm.Title,
                Credits = vm.Credits,
                Department = new Department
                {
                    Name = vm.Department.Name
                }
            };

            _context.Add(course);
            await _context.SaveChangesAsync();

            PopulateDepartmentDropDownList(course.DepartmentId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Department)
                .Where(c => c.CourseId == id)
                .Select(c => new CourseDetailsViewModel
                {
                    CourseId = c.CourseId,
                    Title = c.Title,
                    Credits = c.Credits,
                    Department = new CourseDepartmentIndexViewModel
                    {
                        Name = c.Departments.Name
                    }
                })
                .FirstOrDefaultAsync();
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }


        private void PopulateDepartmentDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentId = new SelectList(departmentsQuery
                .AsNoTracking(), "DepartmentId", "Name", selectedDepartment);
        }
    }
}
