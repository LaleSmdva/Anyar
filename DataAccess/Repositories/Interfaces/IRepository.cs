using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class, new()
{
    IQueryable<T> GetAll();
    Task<T?> GetById(int id);
    //IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool isTracking=false);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    DbSet<T> _table { get; }
    Task SaveAsync();

}
