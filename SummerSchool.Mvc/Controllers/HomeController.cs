using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummerSchool.Mvc.Models;
using SummerSchool.Services.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchool.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IAppLogging<HomeController> _logger;

        public HomeController(IAppLogging<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogAppWarning("This is a test");
            return View();
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
    }
}
