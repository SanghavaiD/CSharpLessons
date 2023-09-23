using Microsoft.AspNetCore.Mvc;
using MyMVCApp.Models;
using System.Diagnostics;
using System.Text;

namespace MyMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IActionResult Menu()
        {
            String constring = _configuration.GetConnectionString("DefaultConnection");
            _logger.Log(LogLevel.Information, constring);           //LogLevel is a enum here..Information is the constant in that enum
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        //Method Overload
        [HttpPost]
        public IActionResult Index(int x, IFormCollection collection)
        {
            StringBuilder data = new StringBuilder(500);
            data.Append("x:");
            data.Append(x);
            data.Append(" ");
            data.Append("name");
            data.Append(collection["name"]);
            data.Append(" ");
            data.Append("password:");
            data.Append(collection["password"]);

            //foreach (var item in collection)
            //{
            //    data.Append(item.Key);
            //    data.Append(":");
            //    data.Append(item.Value);
            //    data.Append(" ");
            //}

            ViewData["x"] = data.ToString();
            //TempData["globalX"] = x;
            return View("IndexPost");
        }
        public ActionResult DoTask(int? id)
        {
            if (id.HasValue)
            {
                ViewData["id"] = id.Value;
            }
            else
            {
                ViewData["id"] = 0;
            }
            return View();
        }
        public ActionResult Test()
        {
            return RedirectToAction("Index");
        }
        public IActionResult GetBook()
        {
            Book b1 = new Book()
            { AuthorName = "H Lee" };
            ViewData["book"] = b1;
            return View();
        }

        [ResponseCache(Duration = 15)]
        public IActionResult GetTime()
        {
            String todate = DateTime.Now.ToLongTimeString();
            ViewData["date"] = todate;
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
       
        public ActionResult Echo(String name, String city)
        {
            String s1 = "user= " + name + " from City=" + city;
            ViewData.Add("Data1", s1);
            return View();
        }
        public ActionResult SayHello(String name)
        {
            //Home/SayHello?name=Sanghavai
            String s1 = ("Hello " + name);
            ViewData.Add("Data1", s1);
            return View("Echo");
        }

    }
}