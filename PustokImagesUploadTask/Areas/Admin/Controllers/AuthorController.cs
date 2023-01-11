using Microsoft.AspNetCore.Mvc;
using PustokImagesUploadTask.Models;
using System.Reflection;

namespace Pustok.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Authors.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid) return View();

            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author is null) return View("Error");

            return View(author);
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            Author existAuthor = _context.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (existAuthor is null) return View("Error");

            PropertyInfo[] destination = existAuthor.GetType().GetProperties();
            PropertyInfo[] source = author.GetType().GetProperties();

            for (int i = 0; i < destination.Length; i++)
            {
                destination[i].SetValue(existAuthor, source[i].GetValue(author));
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (author is null) return View("Error");
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
