using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class DietitianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
