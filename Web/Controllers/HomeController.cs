using System.Diagnostics;
using Business;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly TaskService taskService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, TaskService taskService)
    {
        _logger = logger;
        this.taskService = taskService;
    }

    public IActionResult Index()
    {
        return View(taskService.GetTasks());
    }

    [HttpPost]
    public IActionResult AddTask(string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
            taskService.AddTask(title);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CompleteTask(int id)
    {
        taskService.CompleteTask(id);
        
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
