using Microsoft.AspNetCore.Mvc;

namespace MyMVCApp.Controllers
{
    public class PartialViewController : Controller
    {//GET:PartialView
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Tabs()
        {
            ViewData["data1"] = "Tom and Jerry are Good friends";
            return View();
        }
    }
}
