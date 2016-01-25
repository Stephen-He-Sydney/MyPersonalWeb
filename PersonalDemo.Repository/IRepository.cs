using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace PersonalDemo.Repository
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        Task InsertAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);
    }
}
