using E_Commerce.Entities;
using E_Commerce.Models;
using E_Commerce.Repositories;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Services
{
    public class CategoryService(GenericRepository<Category> _categoryRepository)
    {
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesVM = categories.Select(item => new CategoryVM
            {
                CategoryId = item.CategoryId,
                Name = item.Name,
            }).ToList();    

            return categoriesVM;
        }

        public async Task AddAsync(CategoryVM categoryVM)
        {
            var entity = new Category
            {
                Name = categoryVM.Name,
            };

            await _categoryRepository.AddAsync(entity);
        }
    }
}
