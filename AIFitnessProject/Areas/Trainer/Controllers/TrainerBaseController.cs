using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AIFitnessProject.Core.Constants.RoleConstants;
namespace AIFitnessProject.Areas.Trainer.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = TrainerRole)]
    public class TrainerBaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
