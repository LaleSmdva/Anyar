using Business.DTOs.Employee;
using Business.Services.Interfaces;
using Business.Utilities;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHostingEnvironment _env;
    private readonly AppDbContext _context;

    public EmployeeService(IEmployeeRepository employeeRepository, IHostingEnvironment env, AppDbContext context)
    {
        _employeeRepository = employeeRepository;
        _env = env;
        _context = context;
    }

    public  async Task CreateAsync(CreateEmployeeDto entity)
    {
        var fileName = await entity.Image.CopyFileAsync(_env.WebRootPath,"assets", "img","team");
        Employee employee = new()
        {
            Name = entity.Name,
            Position = entity.Position,
            Description= entity.Description,
            Image=fileName
        };

        await _employeeRepository.CreateAsync(employee);
        await _employeeRepository.SaveAsync();
 
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GetEmployeeDto> GetAll()
    {
        throw new NotImplementedException();
    }

 


    public async Task Update(int id,UpdateEmployeeDto entity)
    {
        var model= _employeeRepository.GetById(id);
        //if (model == null) return Bad

        //var model = _employeeRepository.Update(entity);

        var filename = await entity.Image.CopyFileAsync(_env.WebRootPath, "assets", "img","team");
        model.Name = entity.Name;
        model.Position = entity.Position;
        model.Description = entity.Description;
        model.Image = filename;

        _employeeRepository.Update(model);
        await _employeeRepository.SaveAsync();
    }
    public async Task SaveAsync()
    {
        await _employeeRepository.SaveAsync();
    }

    public async Task<Employee> GetById(int id)
    {
        return _employeeRepository.GetById(id);

    }


    //public Task<List<GetEmployeeDto>> FindByConditionAsync(Expression<Func<Employee, bool>> expression)
    //{
    //    var model=_employeeRepository.FindByCondition(expression).ToList();

    //}
}
