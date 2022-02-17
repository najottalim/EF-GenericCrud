using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntityCrud.Data.IRepository   
{
    internal interface IGenericCrudRepository<T> where T : class
    {
        Task AddAsync(T obj);
        Task AddRangeAsync(IEnumerable<T> objects);
        Task UpdateAsync(T obj);    
        Task<T> GetAsync(Expression<Func<T, bool>> pred = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> pred = null);
        Task DeleteAsync(T obj);
    }
}
