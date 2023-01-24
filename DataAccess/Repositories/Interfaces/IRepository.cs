using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class, new()
{
    IQueryable<T> GetAll();
    T GetById(int id);
    Task Create(T entity);
    void Update(T entity);
    void Delete(int id);
    DbSet<T> _table { get; }
    Task SaveAsync();

}
