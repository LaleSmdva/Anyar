using Business.DTOs.Employee;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Business.Utilities;
using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Anyar_Exam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(AppDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_context.Employees);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateAsync(createEmployeeDto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model=await _context.Employees.FindAsync(id);
            UpdateEmployeeDto updateEmployeeDto = new()
            { 
                Name=model.Name,
                Position=model.Position,
                Description=model.Description
            };

            return View(updateEmployeeDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeDto ,int id)
        {
            var model = await _context.Employees.FindAsync(id);

            var filename = await updateEmployeeDto.Image.CopyFileAsync(_env.WebRootPath,"assets","img");
           model.Name= updateEmployeeDto.Name;
            model.Position=updateEmployeeDto.Position;
            model.Description=updateEmployeeDto.Description;
            model.Image = filename;

            await _employeeService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
