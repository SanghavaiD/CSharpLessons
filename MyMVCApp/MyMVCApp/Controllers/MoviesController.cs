using Microsoft.AspNetCore.Mvc;

namespace MyMVCApp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
