using Business.DTOs.Employee;
using Business.Services.Implementations;
using Business.Services.Interfaces;
using Business.Utilities;
using Core.Entities;
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

		public EmployeeController(AppDbContext context, IWebHostEnvironment env, IEmployeeService employeeService)
		{
			_context = context;
			_env = env;
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
			//if (!ModelState.IsValid) return View(createEmployeeDto);

			//if (createEmployeeDto.Image.CheckFileSize(100))
			//{
			//	ModelState.AddModelError("Image", "Size can't be bigger than 100");
			//	return View(createEmployeeDto);
			//}
			var fileName = await createEmployeeDto.Image.CopyFileAsync(_env.WebRootPath, "assets", "img","team");
			Employee employee = new()
			{
				Name=createEmployeeDto.Name,
				Description = createEmployeeDto.Description,
				Position=createEmployeeDto.Position,
				Image = fileName
			};
			await _context.AddAsync(employee);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			//var model = await _employeeService.GetById(id);
			
			//UpdateEmployeeDto employee = new()
			//{
			//	Name = model.Name,
			//	Position = model.Position,
			//	Description = model.Description
			//};
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, UpdateEmployeeDto entity)
		{
			//var model = await _employeeService.GetById(id);
			await _employeeService.Update(id, entity);
			await _employeeService.SaveAsync();

			return RedirectToAction(nameof(Index));
		}


		//public async Task<IActionResult> Update(int id)
		//{
		//	var model = await _context.Employees.FindAsync(id);
		//	if (model == null) return BadRequest();
		//	UpdateEmployeeDto employee = new()
		//	{
		//		Name= model.Name,
		//		Position=model.Position,
		//		Description = model.Description
		//	};
		//	return View(employee);
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Update(int id, UpdateEmployeeDto entity)
		//{
		//	var model = await _context.Employees.FindAsync(id);
		//	if (model == null) return BadRequest();
		//	var fileName = await entity.Image.CopyFileAsync(_env.WebRootPath, "assets", "img","team");

		//	model.Name = entity.Name;
		//	model.Description = entity.Description;
		//	model.Image = fileName;

		//	//_context.Update(model);
		//	await _context.SaveChangesAsync();
		//	return RedirectToAction(nameof(Index));
		//}

		public async Task<IActionResult> Delete(int id)
		{
			if (id == null) return BadRequest();
			var model = await _context.Employees.FindAsync(id);
			if (model == null) return BadRequest();

			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName(nameof(Delete))]

		public async Task<IActionResult> DeleteEmployee(int id)
		{
			if (id == null) return BadRequest();
			var model = await _context.Employees.FindAsync(id);
			if (model == null) return BadRequest();
			_context.Employees.Remove(model);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


	}
}
