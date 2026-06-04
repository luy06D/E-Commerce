using E_Commerce.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext dbContext) where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();    
        }
    }
}
