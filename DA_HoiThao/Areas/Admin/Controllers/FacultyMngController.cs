using DA_HoiThao.Models;
using DA_HoiThao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DA_HoiThao1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class FacultyMngController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFacultyRepository _facultyRepository;
        //Ham constractor (khoi tao)
        public FacultyMngController(IStudentRepository studentRepository, IClassRepository classRepository,
            IFacultyRepository facultyRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _facultyRepository = facultyRepository;
        }
        public async Task<IActionResult> Index()
        {

            var faculties = await _facultyRepository.GetAllAsync();
            return View(faculties);
        }

        public async Task<IActionResult> Details(int id)
        {

            var faculty = await _facultyRepository.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Faculty faculty)
        {

            if (ModelState.IsValid)
            {
                await _facultyRepository.AddAsync(faculty);
                return RedirectToAction(nameof(Index));
            }
            foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];
                foreach (ModelError error in modelStateVal.Errors)
                {
                    var errorMessage = error.ErrorMessage;
                    var propertyName = modelStateKey;
                }
            }
            return View(faculty);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _facultyRepository.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _facultyRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var faculty = await _facultyRepository.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                await _facultyRepository.UpdateAsync(faculty);
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }
    }
}
