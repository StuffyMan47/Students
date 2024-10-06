////using Microsoft.AspNetCore.Mvc;
////using Students.DataBase;
////using Students.Models;
////using System.Diagnostics;

////namespace Students.Controllers
////{
////    public class HomeController : Controller
////    {
////        private readonly ILogger<HomeController> _logger;
////        private readonly AppDBContext _context;
////        public HomeController(ILogger<HomeController> logger)
////        {
////            _logger = logger;
////        }

////        public IActionResult Index1()
////        {
////            return View();
////        }
////        public async Task<IActionResult> Index()
////        {
////            var view = new IndexModel(_context);
////            view.OnGet();
////            return View(view);
////        }
////        public IActionResult Privacy()
////        {
////            return View();
////        }

////        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
////        public IActionResult Error()
////        {
////            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
////        }
////    }
////}


using Microsoft.AspNetCore.Mvc;
using Students.Models;
using System.Diagnostics;

namespace test.Controllers
{
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
