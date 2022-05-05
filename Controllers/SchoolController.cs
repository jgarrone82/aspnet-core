using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;

public class SchoolController : Controller
{
    private SchoolContext _context;

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index()
    {
        //var school = new School("George's Institute", 2020, SchoolType.High, "Argentina", "Córdoba", "2372 San Javier Street");
        //school.UniqueId = Guid.NewGuid().ToString();

        var school = _context.Schools.FirstOrDefault();

        return View(school);
    }

    public SchoolController(SchoolContext context)
    {
        _context= context;
    }


}