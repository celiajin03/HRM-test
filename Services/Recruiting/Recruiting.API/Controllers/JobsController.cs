using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        // add references for ApplicationCore and Infra Projects
        // copy all the DI registrations including DbContext into API project program.cs
        // copy the connection string from MVC appSettings to API appSettings

        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        /*
        // http:localhost/api/jobs
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();

            if (!jobs.Any())
            {
                // no jobs exists, then 404
                return NotFound(new { error = "No open job found, please try later" });
            }
            // return Json data, and also HTTP status codes
            // serialization C# objects into Json Objects using System.Text.Json
            return Ok(jobs);
        }
        */

        // http:localhost/api/jobs
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetJobsByPagination(int page = 1, int pageSize = 10)
        {
            var jobs = await _jobService.GetJobsByPagination(page, pageSize);

            if (!jobs.Any())
            {
                return NotFound(new { error = "No open job found, please try later" });
            }

            return Ok(jobs);
        }

        // http:localhost/api/jobs/1
        [HttpGet]
        [Route("{id:int}", Name = "GetJobDetails")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { errorMessage = "No Job found for this id" });
            }

            return Ok(job);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // 400 status code
                return BadRequest();
            }

            var job = await _jobService.AddJob(model);
            return CreatedAtAction("GetJobDetails", new { controller = "Jobs", id = job }, "Job Created");
        }

        // http:localhost/api/jobs/1/submissions
        [HttpGet]
        [Route("{id:int}/submissions", Name = "GetJobSubmissions")]
        public async Task<IActionResult> GetJobSubmissions(int id)
        {
            var submissions = await _jobService.GetJobSubmissions(id);
            if (!submissions.Any())
            {
                return NotFound(new { errorMessage = "No Submissions found for this job" });
            }

            return Ok(submissions);
        }

        // http:localhost/api/jobs/1
        [HttpPost]
        [Route("{id:int}", Name = "ApplyJob")]
        public async Task<IActionResult> ApplyJob(int id, SubmissionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var submission = await _jobService.ApplyJob(id, model);
            if (submission == null)
            {
                return BadRequest(new {message = "An existing submission already exists for this candidate"});
            }
            return Ok(new { message = "Job application successful",  submission});
        }
        
        [HttpPut]
        [Route("{id:int}", Name = "CloseJob")]
        public async Task<IActionResult> CloseJob(int id, JobUpdateModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var job = await _jobService.CloseJob(id, model);

            if (job == null)
            {
                return NotFound(new { error = "Job not found" });
            }

            return Ok(new { message = "Job closed successfully" });
        }
    }
}
