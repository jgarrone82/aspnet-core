using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;

public class StudentController : Controller
{
    private SchoolContext _context;
    public StudentController(SchoolContext context)
    {
        _context = context;
    }

    [Route("Student/Index")]
    public IActionResult Index()
    {
        return View(_context.Students);
    }

    [Route("Student/Index/{studentId}")]
    public IActionResult Index(string studentId)
    {
        var student = from s in _context.Students
                      where s.UniqueId == studentId
                      select s;

        return View(student);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}