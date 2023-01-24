using Business.DTOs.Employee;
using Business.Services.Interfaces;
using Business.Utilities;
using Core.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IHostingEnvironment _env;

    public EmployeeService(IEmployeeRepository employeeRepository, IHostingEnvironment env)
    {
        _employeeRepository = employeeRepository;
        _env = env;
    }

    public  async Task CreateAsync(CreateEmployeeDto entity)
    {
        var fileName = await entity.Image.CopyFileAsync(_env.WebRootPath,"assets", "img");
        Employee employee = new()
        {
            Name = entity.Name,
            Position = entity.Position,
            Image=fileName
        };

        await _employeeRepository.Create(employee);
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

    public GetEmployeeDto GetById(int id)
    {
        throw new NotImplementedException();
    }


    public void Update(UpdateEmployeeDto entity)
    {
        throw new NotImplementedException();
    }
    public async Task SaveAsync()
    {
        await _employeeRepository.SaveAsync();
    }
}
