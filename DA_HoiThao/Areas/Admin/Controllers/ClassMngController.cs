using DA_HoiThao.Models;
using DA_HoiThao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace DA_HoiThao1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ClassMngController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFacultyRepository _facultyRepository;
        //Ham constractor (khoi tao)
        public ClassMngController(IStudentRepository studentRepository, IClassRepository classRepository,
            IFacultyRepository facultyRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _facultyRepository = facultyRepository;
        }

        public async Task<IActionResult> Index()
        {

            var classes = await _classRepository.GetAllAsync();
            return View(classes);
        }

        public async Task<IActionResult> Details(int id)
        {

            var classes = await _classRepository.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }
        public async Task<IActionResult> Add()
        {
            var faculties = await _facultyRepository.GetAllAsync();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Class Class)
        {

            if (ModelState.IsValid)
            {
                await _classRepository.AddAsync(Class);
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
            var faculties = await _facultyRepository.GetAllAsync();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            return View(Class);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Class = await _classRepository.GetByIdAsync(id);
            if (Class == null)
            {
                return NotFound();
            }
            return View(Class);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _classRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var Class = await _classRepository.GetByIdAsync(id);
            if (Class == null)
            {
                return NotFound();
            }
            var faculties = await _facultyRepository.GetAllAsync();
            ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
            return View(Class);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Class Class)
        {
            if (ModelState.IsValid)
            {
                await _classRepository.UpdateAsync(Class);
                return RedirectToAction(nameof(Index));
            }
            return View(Class);
        }
    }
}
