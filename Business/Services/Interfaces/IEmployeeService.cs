using Business.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces;

public interface IEmployeeService
{
    IEnumerable<GetEmployeeDto> GetAll();
    GetEmployeeDto GetById(int id);
    Task CreateAsync(CreateEmployeeDto entity);
    void Update(UpdateEmployeeDto entity);
    void Delete(int id);
    Task SaveAsync();

}
// core dataccess business api 