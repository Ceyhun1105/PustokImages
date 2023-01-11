using Microsoft.AspNetCore.Mvc;

namespace PustokImagesUploadTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GoHome()
        {
            return RedirectToAction("Index", "Home", new { area = "" });        
        }
    }
}
