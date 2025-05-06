using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace AIFitnessProject.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminDocumentController : AdminBaseController
    {
        private readonly IDocumentService documentService;

        public AdminDocumentController(IDocumentService _documentService)
        {
            this.documentService = _documentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmAccept(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid document ID.");
            }

            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var model = await documentService.ConfirmModel(id);
            if (model == null)
            {
                return NotFound("Document not found.");
            }

            return View(model);
        }

        [HttpPost] 
        public async Task<IActionResult> Accept(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid document ID.");
            }

            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var result = await documentService.Accept(id);
            if (result)
            {
                return RedirectToAction("All");
            }

            return BadRequest("Failed to accept the document.");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid document ID.");
            }

 
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var model = await documentService.ConfirmModel(id);
            if (model == null)
            {
                return NotFound("Document not found.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid document ID.");
            }

            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var result = await documentService.Delete(id);
            if (result)
            {
                return RedirectToAction("All");
            }

            return BadRequest("Failed to delete the document.");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var models = await documentService.AllDocumentsInAdmin();
            if (models == null)
            {
                return NotFound("No documents found.");
            }

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid document ID.");
            }

            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User is not authenticated.");
            }

            var model = await documentService.DetailsDocumentsInAdmin(id);
            if (model == null)
            {
                return NotFound("Document not found.");
            }

            return View(model);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
