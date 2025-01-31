using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AIFitnessProject.Core.Constants.RoleConstants;
namespace AIFitnessProject.Areas.Dietitian.Controllers
{
    [Area("Dietitian")]
    [Authorize(Roles = DietitianRole)]
    public class DietitianBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
