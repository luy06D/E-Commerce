using E_Commerce.Context;
using E_Commerce.Entities;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    public class CategoryController(CategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddUpdate(int id)
        {
            var categoryVM = await _categoryService.GetByIdAsync(id);
            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddUpdate(CategoryVM categoryVM)
        {
            ViewBag.message = null;
            if(!ModelState.IsValid) return View(categoryVM);
            await _categoryService.AddAsync(categoryVM);
            ViewBag.message = "Created category";
            return View();
        }

        



    }
}
