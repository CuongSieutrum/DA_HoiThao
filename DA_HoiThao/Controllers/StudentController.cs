using DA_HoiThao.Models;
using DA_HoiThao.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DA_HoiThao.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFacultyRepository _facultyRepository;
        //Ham constractor (khoi tao)
        public StudentController(IStudentRepository studentRepository, IClassRepository classRepository,
            IFacultyRepository facultyRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _facultyRepository = facultyRepository;
        }

        public async Task<IActionResult> Index()
        {

            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult> Details(int id)
        {

            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}