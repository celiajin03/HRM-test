using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ISubmissionService
	{
		Task<List<SubmissionResponseModel>> GetSubmissionsByJobId(int jobId);

		Task<Submission> GetSubmissionByCandidateId(int candidateId);

		Task<Submission> AddSubmission(int jobId, int candidateId);
	}
}

