using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using aspnet_core.Models;

namespace aspnet_core.Controllers;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var studentList = GenerateRandomStudents();

        return View(studentList);
    }

    private List<Student> GenerateRandomStudents()
    {
        string[] name1 = { "Michael", "Janice", "John", "George", "Donald", "Thomas", "Nichole", "Karen" };
        string[] surname1 = { "Adams", "Smith", "Johnson", "Parker", "Trump", "Brown", "Turner" };
        string[] name2 = { "William", "Laura", "Rick", "Leonard", "Silvie", "Ellen", "Bryan", "Bruce" };

        var studentList = from n1 in name1
                          from n2 in name2
                          from a1 in surname1
                          select new Student { Name = $"{n1} {n2} {a1}" };

        return studentList.OrderBy((al) => al.UniqueId).ToList();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}