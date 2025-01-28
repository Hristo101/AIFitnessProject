using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Core.Models.Document;
using AIFitnessProject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AIFitnessProject.Controllers
{
    public class DocumentController : Controller
    {

        private readonly IDocumentService documentService;

        public DocumentController(IDocumentService _documentService)
        {
            documentService = _documentService;
        }
        [HttpGet]
        public async Task<IActionResult> SendDocuments()
        {
            var model = new SendDocumentsViewModel();

            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> SendDocuments(SendDocumentsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = GetUserId();
            await documentService.SendDocumentsAsync(userId, model);

            if(model.Position == "Тренъор")
            {
                return RedirectToAction("All", "Trainer");
            }


            return RedirectToAction("All", "Dietitian");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
