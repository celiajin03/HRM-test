using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using RecruitingWeb.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        private IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        
        // http://example.com/jobs/index
        // Hosted this webapp on the server, Azure-windows, azure linux
        // U1 -> http://example.com/jobs/index
        // u2, u3, u4...
        // 10:00 AM 300 users accessing your website, 200 are accessing index methods
        
        
        public async Task<IActionResult> Index()
        {
            // we need to get list of Jobs
            // all the Job Service
            // var jobsController = new JobsController(); [error]
            // jobsController.Index()

            // ASP.NET will assign a thread from thread pool (collection of threads) to do this task
            // T 1-100 threads
            // T1 ->
            var x = 10;
            
            // database
            // I/O bound -> go to this URL and fetch me some data/image network, file download, database calls
            // CPU bound => loan calculation, large PI number, resizing/processing image 
            
            // I/O bound operation↓ might take 2 sec, 10 ms, 10 sec, 300 ms
            // network, location, database disk SSD/hard drive, SQL slow or fast, might be not optimized
            // waiting
            // prevent Thread Starvation
            
            // 3 ways we can send data from controller/action method to view
            // 1. ViewBag
            // 2. View Data
            // 3. *** Strongly Typed Model Data *** (most preferred)
            ViewBag.PageTitle = "Showing Jobs"; 
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }

        public async Task<IActionResult> Details(int id)
        {
            //get job by Id
            var jobs = await _jobService.GetJobById(id);
            return View(jobs);
        }

        //show the empty page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // saving the Job Information
        [HttpPost]
        // public async Task<IActionResult> Create(JobRequestModel model, string Location, string LOCATION, string loc)
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            // check if the model is valid, on the server side
            if (!ModelState.IsValid)
            {
                return View();
            }
            // save the data in database
            // return to the index view
            await _jobService.AddJob(model);
            return RedirectToAction("Index"); 
        }
    }
}

