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

        public async Task AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync(); 
        }

        public async Task<TEntity?> GetByIdAsync(int entityId)
        {
            return await dbContext.Set<TEntity>().FindAsync(entityId);
        }
        
        public async Task UpdateAsync(TEntity entity)
        {
             dbContext.Set<TEntity>().Update(entity);
            await dbContext.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
