using Business.DTOs.Employee;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Business.Services.Interfaces;

public interface IEmployeeService
{
    IEnumerable<GetEmployeeDto> GetAll();
    Task<Employee> GetById(int id);
    //Task<List<GetEmployeeDto>> FindByConditionAsync(Expression<Func<Employee, bool>> expression);
    Task CreateAsync(CreateEmployeeDto entity);
    Task Update(int id,UpdateEmployeeDto entity);
    void Delete(int id);

}
// core dataccess business api 