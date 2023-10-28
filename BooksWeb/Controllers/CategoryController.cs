using BooksWeb.Data;
using BooksWeb.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _database;
        public CategoryController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _database.Categories;

            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDatabase = _database.Categories.Find(id);

            if (categoryFromDatabase == null)
            {
                return NotFound();
            }

            return View(categoryFromDatabase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Имя не может совпадать с порядковым номером");
            }
            if (ModelState.IsValid)
            {
                _database.Categories.Add(obj);
                _database.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Имя не может совпадать с порядковым номером");
            }
            if (ModelState.IsValid)
            {
                _database.Categories.Update(obj);
                _database.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }
    }
}

