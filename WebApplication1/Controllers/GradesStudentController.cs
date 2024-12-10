using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class GradesStudentController : Controller
    {
        public IActionResult Index()
        {
            // Użyj danych z kontrolera nauczyciela
            return View(GradesController.Subjects);
        }
    }
}