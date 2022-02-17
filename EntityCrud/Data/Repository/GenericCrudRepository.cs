using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EntityCrud.Data.IRepository;


namespace EntityCrud.Data.Repository    
{
    internal class GenericCrudRepository<T> : IGenericCrudRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericCrudRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> objects)
        {
            await _dbSet.AddRangeAsync(objects);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj)
        {
            _dbSet.Remove(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> pred = null)
        {
            Expression<Func<T, bool>> predicate = p => true;

            return await _dbSet.Where(pred ?? predicate).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> pred = null)
        {
            Expression<Func<T, bool>> predicate = p => true;

            return await _dbSet.FirstOrDefaultAsync(pred ?? predicate);
        }

        public async Task UpdateAsync(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
