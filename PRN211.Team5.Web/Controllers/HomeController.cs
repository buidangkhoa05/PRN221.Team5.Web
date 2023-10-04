using Microsoft.AspNetCore.Mvc;
using PRN211.Team5.Web.Models;
using System.Diagnostics;

namespace PRN211.Team5.Web.Controllers
{
    [Route("home-controler")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("[Action]")]
        
        public IActionResult People()
        {
            return View(new PeopleModel());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var companyName = Request.Form["CompanyName"];

            return View(new Student());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}