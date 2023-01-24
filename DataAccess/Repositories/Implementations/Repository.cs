using Core.Interfaces;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {

        private readonly AppDbContext _context;
  

        public DbSet<T> _table => _context.Set<T>();

        public Repository(AppDbContext context)
        {
            _context = context;
            
        }
 
        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public async  Task<T?> GetById(int id)
        {
            //if(isTracking)
            //{ 
            //    return _table.AsQueryable();
            //}
            return await _table.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
           await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }


        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        //public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTracking = false)
        //{
        //    if(isTracking)
        //    {
        //        return _table.Where(expression);
        //    }
        //    return _table.Where(expression).AsNoTracking();
        //}
    }
}
