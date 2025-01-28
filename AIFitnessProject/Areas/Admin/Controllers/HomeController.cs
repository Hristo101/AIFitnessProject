using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
