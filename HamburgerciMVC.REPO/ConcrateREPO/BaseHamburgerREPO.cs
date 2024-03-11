using HamburgerciMVC.DATA.Abstract;
using HamburgerciMVC.REPO.Context;
using HamburgerciMVC.REPO.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciMVC.REPO.ConcrateREPO
{
    public class BaseHamburgerREPO<T> : IBaseHamburgerREPO<T> where T : BaseHamburger
    {

        private readonly ApplicationContext _context;

        public BaseHamburgerREPO(ApplicationContext context)
        {
            _context = context;

        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {

            return await _context.Set<T>().AnyAsync(expression);

        }

        public int Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {

            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges();

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id); 
         }

        public async Task<TResult> GetFilteredFirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {

            IQueryable<T> query = _context.Set<T>();

            if (join != null)
            {
                query = join(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(select).FirstOrDefaultAsync();
            }

        }

        public async Task<List<TResult>> GetFilteredListAsync<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (join != null)
            {
                query = join(query);
            }

            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(select).ToListAsync();
            }
            else
            {
                return await query.Select(select).ToListAsync();
            }
        }

        public async  Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public int Update(T entity)
        {

            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }

}
