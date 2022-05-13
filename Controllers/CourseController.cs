using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;
namespace aspnet_core.Controllers;

public class CourseController : Controller
{
    private SchoolContext _context;
    public CourseController(SchoolContext context)
    {
        _context= context;
    }

    [Route("Course/Index")]
    public IActionResult Index()
    { 
        return View(_context.Courses);
    }

    [Route("Course/Index/{courseId}")]
    public IActionResult Index(string courseId)
    {
        var course = from c in _context.Courses
                            where c.UniqueId == courseId
                            select c;

        return View(course);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}