using AIFitnessProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AIFitnessProject.Areas.Admin.Controllers
{
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
        public async Task<IActionResult> All()
        {
            var models = await documentService.AllDocumentsInAdmin();

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await documentService.DetailsDocumentsInAdmin(id);

            return View(model);
        }
    }
}
