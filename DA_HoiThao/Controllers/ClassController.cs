using DA_HoiThao.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DA_HoiThao.Controllers
{
    public class ClassController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IFacultyRepository _facultyRepository;
        //Ham constractor (khoi tao)
        public ClassController(IStudentRepository studentRepository, IClassRepository classRepository,
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

            var classes = await _studentRepository.GetByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return View(classes);
        }
    }
}
