using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        
        // http:localhost/api/candidates
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();

            if (!candidates.Any())
            {
                return NotFound(new { error = "No candidates found, please try again later" });
            }
            return Ok(candidates);
        }
        
        // http:localhost/api/candidates/1
        [HttpGet]
        [Route("{id:int}", Name="GetCandidateDetails")]
        public async Task<IActionResult> GetCandidateDetails(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound(new { errorMessage = "No candidate found for this id" });
            }

            return Ok(candidate);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var candidate = await _candidateService.AddCandidate(model);
            return CreatedAtAction("GetCandidateDetails", new { controller = "Candidate", id = candidate }, "Candidate Created");
        }
        
        [HttpPut]
        [Route("{id:int}", Name = "UpdateResume")]
        public async Task<IActionResult> UpdateResume(int id, CandidateUpdateModel model)
        {
            var candidate = await _candidateService.UpdateResume(id, model);
            if (candidate==null)
            {
                return BadRequest(new { error = "Failed to update resume" });
            }
            return Ok(new { message = "Resume updated successfully" });
        }
    }
}
