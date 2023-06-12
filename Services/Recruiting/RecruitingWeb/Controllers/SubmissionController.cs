using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class SubmissionController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // return View();
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        // [HttpPost]
        // public async Task<IActionResult> Create(SubmissionRequestModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View();
        //     }
        //     // await _jobService.AddJob(model);
        //     // return RedirectToAction("Index"); 
        // }
    }
}

