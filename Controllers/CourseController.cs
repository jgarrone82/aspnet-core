using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;

public class CourseController : Controller
{
    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {        
        var coursesList = new List<Course>(){
                            new Course{UniqueId = Guid.NewGuid().ToString(),
                            Name="Introduction 101"},
                            new Course{UniqueId = Guid.NewGuid().ToString(),
                            Name="C# 101"} ,
                            new Course{UniqueId = Guid.NewGuid().ToString(),
                            Name="Cyber-security 101"},
                            new Course{UniqueId = Guid.NewGuid().ToString(),
                            Name="Crypto analysis 101"}
            };


        return View(coursesList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}