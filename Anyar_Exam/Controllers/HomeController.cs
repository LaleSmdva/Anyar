using DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Anyar_Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Employees);
        }

    }
}
