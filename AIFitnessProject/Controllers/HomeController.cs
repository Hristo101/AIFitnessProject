using AIFitnessProject.Core.Contracts;
using AIFitnessProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AIFitnessProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService _homeService)
        {
            _logger = logger;
            this.homeService = _homeService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await homeService.GetModelsForHomePageAsync();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult HowWeWork()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
