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
        var school = new School("George's Institute", 2020, SchoolType.High, "Argentina", "Córdoba", "2372 San Javier Street");        
        school.UniqueId = Guid.NewGuid().ToString();

        return View(school);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}