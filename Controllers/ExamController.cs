using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspnet_core.Models;

namespace aspnet_core.Controllers
{
    public class ExamController : Controller
    {
        private readonly SchoolContext _context;

        public ExamController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Exam
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Exams.Include(e => e.Course).Include(e => e.Student);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Exam/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exam/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "Name");
            ViewData["StudentUniqueId"] = new SelectList(_context.Students, "UniqueId", "Name");
            return View();
        }

        // POST: Exam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentUniqueId,CourseId,Note,UniqueId,Name")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "Name", exam.CourseId);
            ViewData["StudentUniqueId"] = new SelectList(_context.Students, "UniqueId", "Name", exam.StudentUniqueId);
            return View(exam);
        }

        // GET: Exam/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "Name", exam.CourseId);
            ViewData["StudentUniqueId"] = new SelectList(_context.Students, "UniqueId", "Name", exam.StudentUniqueId);
            return View(exam);
        }

        // POST: Exam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentUniqueId,CourseId,Note,UniqueId,Name")] Exam exam)
        {
            if (id != exam.UniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.UniqueId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "UniqueId", "Name", exam.CourseId);
            ViewData["StudentUniqueId"] = new SelectList(_context.Students, "UniqueId", "Name", exam.StudentUniqueId);
            return View(exam);
        }

        // GET: Exam/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Exams == null)
            {
                return Problem("Entity set 'SchoolContext.Exams'  is null.");
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(string id)
        {
          return (_context.Exams?.Any(e => e.UniqueId == id)).GetValueOrDefault();
        }
    }
}
