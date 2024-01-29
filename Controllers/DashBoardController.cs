using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalExam.Data;
using FinalExam.Models;

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
        //public async Task<IActionResult> Index()
        //{
        //    var viewModel = new WorkSpaceIndexData();
        //    viewModel.WorkSpaces = await _context.WorkSpace
        //        .Include(i => i.User)
        //        .Include(i => i.WorkSpaceMembers)
        //            .ThenInclude(i => i.User)
        //        .Include(i => i.Boards)
        //            .ThenInclude(i => i.Lists)
        //                .ThenInclude(i => i.TaskItems)
        //                    .ThenInclude(i => i.Comments)
        //        .AsNoTracking()
        //        .OrderBy(i => i.WorkSpaceId)
        //        .ToListAsync();
        //    viewModel.Users = await _context.User
        //        .Include(i => i.WorkSpaceMembers)
        //            .ThenInclude(i => i.WorkSpace)
        //        .Include(i => i.WorkSpaces)
        //        .AsNoTracking()
        //        .OrderBy(i => i.LastName)
        //        .ToListAsync();

        //    return View(viewModel);
        //}
    }
}
