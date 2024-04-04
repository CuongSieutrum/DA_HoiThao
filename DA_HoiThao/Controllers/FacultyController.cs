using DA_HoiThao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DA_HoiThao.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFacultyRepository _facultyRepository;
        //Ham constractor (khoi tao)
        public FacultyController(IStudentRepository studentRepository, IClassRepository classRepository,
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

            var faculties = await _facultyRepository.GetByIdAsync(id);
            if (faculties == null)
            {
                return NotFound();
            }
            return View(faculties);
        }
    }
}
