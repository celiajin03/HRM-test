using System;
using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using RecruitingWeb.Models;

namespace RecruitingWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IJobService _jobService;

    public HomeController(ILogger<HomeController> logger, IJobService jobService)
    {
        _logger = logger;
        _jobService = jobService;
    }

    public async Task<IActionResult> Index()
    {
        // return View("test");
        var jobs = await _jobService.GetAllJobs();
        return View(jobs);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    /*
    public IActionResult Jobs()
    {
        //InvalidOperationException: The view 'Jobs' was not found.
        return View();
    }
    */

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

