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

        public async Task<CategoryVM?>GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var categoryVM = new CategoryVM();

            if(category != null)
            {
                categoryVM.Name = category.Name;   
                categoryVM.CategoryId = category.CategoryId;    
            }

            return categoryVM;
        }


        public async Task UpdateAsync(CategoryVM categoryVM)
        {
            var entity = new Category
            {
                CategoryId = categoryVM.CategoryId,
                Name = categoryVM.Name,
            };
            await _categoryRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id )
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            await _categoryRepository.DeleteAsync(category!);    
        }
    }
}
