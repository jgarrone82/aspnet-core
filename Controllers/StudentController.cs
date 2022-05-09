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
        _context= context;
    }
    public IActionResult Index()
    {        
        return View(_context.Students);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}