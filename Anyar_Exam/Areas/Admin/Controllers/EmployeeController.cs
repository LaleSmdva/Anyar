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
        public async Task<IActionResult> Detail(int id)
        {
            var model=await _context.Employees.FindAsync(id);
            return View(model);
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
            var model=await _employeeService.GetById(id);
            UpdateEmployeeDto employee = new()
            { 
                Name= model.Name,
                Position=model.Position,
                Description=model.Description
            };

            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id,UpdateEmployeeDto entity)
        {
            await _employeeService.Update(id,entity);

            return RedirectToAction(nameof(Index));
        }
    
    }
}
