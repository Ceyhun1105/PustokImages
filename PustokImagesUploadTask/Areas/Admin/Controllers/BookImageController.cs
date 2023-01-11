using Microsoft.AspNetCore.Mvc;

namespace PustokImagesUploadTask.Areas.Admin.Controllers
{
    public class BookImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
