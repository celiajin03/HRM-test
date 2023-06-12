using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
	public class SubmissionService: ISubmissionService
	{
		private readonly ISubmissionRepository _submissionRepository;

		public SubmissionService(ISubmissionRepository submissionRepository)
		{
			_submissionRepository = submissionRepository;
		}
		
		public async Task< List<SubmissionResponseModel>> GetSubmissionsByJobId(int jobId)
		{
			// Retrieve the list of submissions for the job
            var submissions = await _submissionRepository.GetSubmissionsByJobId(jobId);
            
            var submissionResponseModel = submissions.Select(submission => new SubmissionResponseModel
            {
                Id = submission.Id,
                JobId = submission.JobId,
                CandidateId = submission.CandidateId,
                SubmittedOn = submission.SubmittedOn,
                SelectedForInterview = submission.SelectedForInterview,
                RejectedOn = submission.RejectedOn,
                RejectedReason = submission.RejectedReason
            }).ToList();
            
            return submissionResponseModel;
		}

		public async Task<Submission> GetSubmissionByCandidateId(int candidateId)
		{
			return await _submissionRepository.GetSubmissionByCandidateId(candidateId);
		}
		
		public async Task<Submission> AddSubmission(int jobId, int candidateId)
		{
			var submissionEntity = new Submission
			{
				JobId = jobId,
				CandidateId = candidateId,
				SubmittedOn = DateTime.UtcNow,
			};
		
			var submission = await _submissionRepository.AddSync(submissionEntity);
			return submission;
		}

	}
}

