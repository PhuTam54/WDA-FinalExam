using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalExam.Data;
using FinalExam.Models;
using FinalExam.Models.DepartmentViewModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting.Internal;

namespace FinalExam.Controllers
{
    public class UsersController : Controller
    {
        private readonly FinalExamContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UsersController(FinalExamContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var viewModel = new DepartmentIndexData();
            viewModel.Users = await _context.User
                .Include(i => i.Department)
                .AsNoTracking()
                .ToListAsync();

            return View(viewModel);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Department)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DepartmentId,EmployeeCode,Rank,LastName,FirstMidName")] User user, IFormFile Avatar)
        {
            if (true)
            {
                var allowedExtenstions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                var filePaths = new List<string>();
                // Check if the file has a valid extensions
                var fileExtension = Path.GetExtension(Avatar.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(fileExtension) || !allowedExtenstions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file extension. Allowed extensions are: " + string.Join(", ", allowedExtenstions));
                };

                if (Avatar.Length > 0)
                {
                    // Change the folder path
                    var uploadFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadFolderPath);

                    var fileName = Path.GetRandomFileName() + fileExtension;
                    var filePath = Path.Combine(uploadFolderPath, fileName);
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Avatar.CopyToAsync(stream);
                    }

                    user.Avatar = "/uploads/" + fileName;
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentName", user.DepartmentId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DepartmentId,EmployeeCode,Rank,LastName,FirstMidName")] User user, IFormFile Avatar)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (true)
            {
                var allowedExtenstions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

                var filePaths = new List<string>();
                // Check if the file has a valid extensions
                var fileExtension = Path.GetExtension(Avatar.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(fileExtension) || !allowedExtenstions.Contains(fileExtension))
                {
                    return BadRequest("Invalid file extension. Allowed extensions are: " + string.Join(", ", allowedExtenstions));
                };

                if (Avatar.Length > 0)
                {
                    // Change the folder path
                    var uploadFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadFolderPath);

                    var fileName = Path.GetRandomFileName() + fileExtension;
                    var filePath = Path.Combine(uploadFolderPath, fileName);
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Avatar.CopyToAsync(stream);
                    }

                    user.Avatar = "/uploads/" + fileName;
                }
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "DepartmentId", "DepartmentName", user.DepartmentId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Department)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'FinalExamContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.User?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
