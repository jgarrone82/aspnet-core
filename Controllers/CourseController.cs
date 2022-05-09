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
    public IActionResult Index()
    { 
        return View(_context.Courses);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}