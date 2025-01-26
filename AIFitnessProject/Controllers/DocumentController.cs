using AIFitnessProject.Core.Models.Document;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Controllers
{
    public class DocumentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> SendDocuments()
        {
            var model = new SendDocumentsViewModel();

            return View(model);

        }
    }
}
