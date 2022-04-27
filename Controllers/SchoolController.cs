using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;

public class SchoolController : Controller
{
    private readonly ILogger<SchoolController> _logger;

    public SchoolController(ILogger<SchoolController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var school = new School();
        school.YearOfCreation = 2020;
        school.SchoolId = Guid.NewGuid().ToString();
        school.Name = "George's Institute";

        return View(school);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}