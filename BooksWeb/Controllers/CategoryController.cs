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
        
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _database.Categories;
            
            return View(categoryList);
        }
    }
}
