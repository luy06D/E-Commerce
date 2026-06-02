using E_Commerce.Context;
using E_Commerce.Entities;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoryController(AppDbContext _dbContext) : Controller
    {
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();    
            return View(categories);
        }
    }
}
