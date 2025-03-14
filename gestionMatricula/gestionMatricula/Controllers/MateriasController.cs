using Microsoft.AspNetCore.Mvc;

namespace gestionMatricula.Controllers
{
    public class MateriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
