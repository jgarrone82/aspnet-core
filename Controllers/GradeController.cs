using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;
public class GradeController : Controller
{
    private SchoolContext _context;
    public GradeController(SchoolContext context)
    {
        _context = context;
    }

    [Route("Grade/Index")]
    public IActionResult Index()
    {
        return View(_context.Grades);
    }

    [Route("Grade/Index/{gradeId}")]
    public IActionResult Index(string gradeId)
    {
        var grade = from g in _context.Grades
                    where g.UniqueId == gradeId
                    select g;

        return View(grade);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Grade grade)
    {
        if (ModelState.IsValid)
        {
            var school = _context.Schools.FirstOrDefault();
            grade.SchoolId = school.UniqueId;
            _context.Grades.Add(grade);
            _context.SaveChanges();
            ViewBag.Message = "Grade created";
            return View("Index",grade);
        }
        else
        {
            return View();
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
