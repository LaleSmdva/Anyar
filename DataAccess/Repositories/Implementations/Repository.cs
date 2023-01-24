using Core.Interfaces;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<T> GetById(int id,bool isTracking=false)
        {
            if(isTracking)
            { 
                return _table.AsQueryable();
            }
            return _table.AsQueryable().AsNoTracking();
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
    }
}
