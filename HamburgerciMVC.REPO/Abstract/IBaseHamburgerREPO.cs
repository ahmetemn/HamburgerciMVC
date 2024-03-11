using HamburgerciMVC.DATA.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.REPO.Interfaces
{
    public interface IBaseHamburgerREPO<T> where T : BaseHamburger
    {
    
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);


        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression);


        Task<TResult> GetFilteredFirstOrDefaultAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);

        Task<List<TResult>> GetFilteredListAsync<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null);
    }
}
 

