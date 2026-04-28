using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using University.Data;
using University.Models;
using University.ViewModel;

namespace University.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController
            (
                UniversityContext context
            )
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //leiame kõik student'id ja tesendame need StudentIndexViewModel'iks
            //miks peab kasutama await?
            //kui me kasutame await, siis me ootame kuni päring on lõpetatud
            //ja saame tulemuse enne kui me jätkame koodi täitmist

            var result = await _context.Students
            .Select(s => new ViewModel.StudentIndexViewModel
            {
                Id = s.Id,
                LastName = s.LastName,
                FirstMidName = s.FirstMidName,
                EnrollmentDate = s.EnrollmentDate
            }).ToListAsync();

            return View(result);
        }

        public async Task<IActionResult> Details(int? id)
        {
            //kui student on null, siis tagastame NotFound() tulemuse
            if (id == null)
            {
                return NotFound();
            }
            //leiame studenti Id järgi
            var student = await _context.Students
                //include lubab objektil kasutada objekti sees
                .Include(s => s.Enrollments)
                //kui tahad uuesti objekti kasutada objekti sees, siis kasutad ThenInclude
                .ThenInclude(e => e.Course)
                //andmeid ei salvestata vahemällu ja ei jälgita
                .AsNoTracking()
                //tagastab esimese elemendi andmetest, mis on tingimuses välja toodud
                .FirstOrDefaultAsync(m => m.Id == id);


            var vm = new ViewModel.StudentDetailsViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
                //kui objekt on objekti sees, siis tuleb teha niimodi
                //miks kasutasime ?? - vaikiva väärtuse annab e default väärtus, kui muutuja on tühi(null)
                //või mitte defineeritud. Annab vasakpoolse väärtuse, kui see ei ole null. Kui on null,
                //siis annab parempoolse väärtuse
                EnrollmentsVm = (student.Enrollments ?? Enumerable.Empty<Enrollment>())
                    .Select(x => new EnrollmentViewModel
                    {
                        CourseId = x.CourseId,
                        Grade = x.Grade,
                        CourseVm = new CourseViewModel
                        {
                            CourseId = x.Course?.CourseId ?? 0,
                            Title = x.Course?.Title,
                            Credits = x.Course?.Credits ?? 0
                        }
                        //üks õpilane võib mitu kursust olla läbinud ja
                        //selle tulemusel tuleb lõppu panna  ToArray

                    }).ToArray()
            };
            //kui student on null, siis tagastame NotFound() tulemuse

            if (student == null)
            {
                return NotFound();
            }

            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }

        //POST: Student/Create
        //see meetod salvestab uue studenti andmebaasi
        [HttpPost]
        //see meetod on kaitstud CSRF rünnakute eest
        //see meetod on asünkroonene, mis tähendab, et see meetod ei saa
        //olla samaaegselt mitu korda käivitatud
        public async Task<IActionResult> Create(StudentCreateViewModel vm)
        {
            //kui model on valiidne, siis loome uue studenti ja salvestame selle andmebaasi
            if (ModelState.IsValid)
            {
                var student = new Models.Student
                {
                    LastName = vm.LastName,
                    FirstMidName = vm.FirstMidName,
                    EnrollmentDate = vm.EnrollmentDate
                };
                //lisame studenti andmebaasi ja salvestame muudatused
                _context.Add(student);
                //miks kasutame await?
                //kui me kasutame await, siis me ootame kuni salvestamine on lõpetatud
                await _context.SaveChangesAsync();
                //pärast salvestamist suuname kasutaja tagasi Index vaatesse
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            //kui student on null, siis on NotFound
            if (student == null)
            {
                return NotFound();
            }
            var vm = new StudentUpdateViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,
            };
            _context.Update(student);

            //tuleb teha domaini modelist andmete ülekanne view modeli omasse
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = new Models.Student
                {
                    Id = vm.Id,
                    LastName = vm.LastName,
                    FirstMidName = vm.FirstMidName,
                    EnrollmentDate = vm.EnrollmentDate
                };
                _context.Update(student);
                await _context.SaveChangesAsync();

                //Kui andmed on uuendatud siis suunab tagasi Update vaatesse, kus kohe uuesti andmeid uuendada
                //Hetkel suunab Indexi vaatesse peale uuendust
                return RedirectToAction(nameof(Update));
            }

            return View(vm);
        }
        //tehke Delete Get meetod
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            var vm = new ViewModel.StudentDeleteViewModel
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstMidName = student.FirstMidName,
                EnrollmentDate = student.EnrollmentDate,

                EnrollmentsVm = (student.Enrollments ?? Enumerable.Empty<Enrollment>())
        .Select(x => new EnrollmentViewModel
        {
            CourseId = x.CourseId,
            Grade = x.Grade,
            CourseVm = new CourseViewModel
            {
                CourseId = x.Course?.CourseId ?? 0,
                Title = x.Course?.Title,
                Credits = x.Course?.Credits ?? 0
            }

        }).ToArray()
            };

            if (student == null)
            {
                return NotFound();
            }

            return View(vm);
        }
    }
}