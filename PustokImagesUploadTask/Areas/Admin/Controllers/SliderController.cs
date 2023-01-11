using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing;
using PustokImagesUploadTask.Helpers;
using PustokImagesUploadTask.Models;
using System.Reflection;

namespace PustokImagesUploadTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.ImageFile is null)
            {
                ModelState.AddModelError("ImageFile", "  Image is required");
                return View();
            }

            if (!slider.ImageFile.CheckFileLength(1048576))
            {
                ModelState.AddModelError("ImageFile", "Please , upload less than 1Mb");
                return View();
            }
            if (!slider.ImageFile.CheckFileType())
            {
                ModelState.AddModelError("ImageFile", "Please , upload only image file (jpeg or png) ");
                return View();
            }

            if (!ModelState.IsValid) return View();

            slider.ImageUrl = slider.ImageFile.SaveFile(_env.WebRootPath, "uploads/sliders");

            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Update(int id)
        {
            if (id == null) return View("Error");

            Slider exist = _context.Sliders.Find(id);

            if (exist is null) return View("Error");

            ViewBag.ImageUrl = exist.ImageUrl;

            return View(exist);
        }

        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            ViewBag.ImageUrl = slider.ImageUrl;
            if (slider.ImageFile is not null)
            {
                if (!slider.ImageFile.CheckFileLength(1048576))
                    ModelState.AddModelError("ImageFile", "Please , upload less than 1Mb");
                if (!slider.ImageFile.CheckFileType())
                    ModelState.AddModelError("ImageFile", "Please , upload only image file (jpeg or png) ");

                slider.ImageUrl = slider.ImageFile.SaveFile(_env.WebRootPath, "uploads/sliders");

                string filapath = Path.Combine(_env.WebRootPath, "uploads/sliders", _context.Sliders.Find(slider.Id).ImageUrl);
                if (System.IO.File.Exists(filapath))
                    System.IO.File.Delete(filapath);
            }

            if (!ModelState.IsValid) return View();

            Slider exist = _context.Sliders.Find(slider.Id);
            PropertyInfo[] existprops = exist.GetType().GetProperties();
            PropertyInfo[] newprops = slider.GetType().GetProperties();

            for (int i = 0; i < existprops.Length; i++)
            {

                existprops[i].SetValue(exist, newprops[i].GetValue(slider));
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            Slider exist = _context.Sliders.Find(id);

            if (exist is null) return View("Error");

            string filapath = Path.Combine(_env.WebRootPath, "uploads/sliders", _context.Sliders.Find(id).ImageUrl);
            if (System.IO.File.Exists(filapath))
                System.IO.File.Delete(filapath);

            _context.Sliders.Remove(exist);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
