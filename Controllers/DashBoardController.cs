using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalExam.Data;
using FinalExam.Models;
using FinalExam.Models.DepartmentViewModels;

namespace FinalExam.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly FinalExamContext _context;

        public DashBoardController(FinalExamContext context)
        {
            _context = context;
        }

        // GET: DashBoard
        public async Task<IActionResult> Index()
        {
            var viewModel = new DepartmentIndexData();
            viewModel.Departments = await _context.Department
                .Include(i => i.Users)
                .AsNoTracking()
                .OrderBy(i => i.DepartmentId)
                .ToListAsync();
            viewModel.Users = await _context.User
                .Include(i => i.Department)
                .AsNoTracking()
                .OrderBy(i => i.ID)
                .ToListAsync();

            return View(viewModel);
        }
    }
}
