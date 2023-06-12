using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewsController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }
        
        // http:localhost/api/Interviews
        // [HttpGet]
        // [Route("")]
        // public async Task<IActionResult> GetInterviewsByPagination(int page = 1, int pageSize = 10)
        // {
        //     var interviews = await _interviewService.GetInterviewsByPagination(page, pageSize);
        //
        //     if (!interviews.Any())
        //     {
        //         return NotFound(new { error = "No Interviews found, please try later" });
        //     }
        //     return Ok(interviews);
        // }
        
        // http:localhost/api/Interviews/1
        [HttpGet]
        [Route("{id:int}", Name="GetInterviewDetails")]
        public async Task<IActionResult> GetInterviewDetails(int id)
        {
            var interview = await _interviewService.GetInterviewById(id);
            if (interview == null)
            {
                return NotFound(new { errorMessage = "No Interview found for this id" });
            }
            return Ok(interview);
        }

        // http:localhost/api/Interviews
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var interview = await _interviewService.AddInterview(model);
            return CreatedAtRoute("GetInterviewDetails", new {id = interview.Id}, interview);
        }
        
        // http:localhost/api/Interviews/1/reschedule
        [HttpPut]
        [Route("{id:int}/reschedule", Name="RescheduleInterview")]
        public async Task<IActionResult> RescheduleInterview(int id, InterviewRescheduleModel model)
        {
            var updatedInterview = await _interviewService.RescheduleInterview(id, model);

            if (updatedInterview == null)
            {
                return BadRequest(new { error = "Failed to re-schedule interview" });
            }
            
            return Ok(updatedInterview);
        }
        
        // http:localhost/api/Interviews/1
        [HttpDelete]
        [Route("{id:int}", Name = "DeleteInterview")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            var interview = await _interviewService.GetInterviewById(id);
            if (interview == null)
            {
                return NotFound(new { error = "Interview not found" });
            }
            
            var deleteId = await _interviewService.DeleteInterview(id); 
            return Ok(new { message = "Interview deleted successfully" });
        }

        // http:localhost/api/Interviews/1/feedback-rating
        [HttpPut]
        [Route("{id:int}/feedback-rating", Name = "GiveFeedbackRating")]
        public async Task<IActionResult> GiveFeedbackRating(int id, InterviewFeedbackModel model)
        {
            var interview = await _interviewService.GiveFeedbackRating(id, model);
            if (interview == null)
            {
                return BadRequest(new { error = "Failed to update feedback and rating" });
            }
            return Ok(interview);
        }
        
        // http:localhost/api/Interviews/interviewer/1
        [HttpGet]
        [Route("interviewer/{interviewerId:int}", Name="GetInterviewsByInterviewer")]
        public async Task<IActionResult> GetInterviewsByInterviewer(int interviewerId, int page = 1, int pageSize = 10)
        {
            var interviews = await _interviewService.GetInterviewsByInterviewer(interviewerId, page, pageSize);

            if (!interviews.Any())
            {
                return NotFound(new { error = "No interviews found for the specified interviewer" });
            }

            return Ok(interviews);
        }
        
        [HttpGet]
        [Route("")]
        // [Authorize]
        public IActionResult GetAllInterviews()
        {
            // go to database and get all the interviews based on role
            // if role = admin, get all
            // if role = manger, get only manager's interviews
            // read the header using HttpContext
            // JWT token
            // Authorization Header, bearer akdfl;gncvbopnzeaa;rgbebvnv;irga;sdm
            // userid, roles
            // decode the JWT to C# object
            /*
            // Equivalent to [Authorize]:
            if (this.HttpContext.User.Identity.IsAuthenticated)
            {
                // go to database, and get the values
            }
            */
            var interviews = new List<string>(new[] { "abc, xyz, dddd" });
        
            return Ok(interviews);
        }

    }
}

