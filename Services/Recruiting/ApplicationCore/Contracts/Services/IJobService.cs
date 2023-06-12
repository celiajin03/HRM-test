using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IJobService
	{
		// List<JobResponseModel> GetAllJobs();
		Task<List<JobResponseModel>> GetAllJobs();

		Task<List<JobResponseModel>> GetJobsByPagination(int page, int pageSize);
		
		Task<JobResponseModel> GetJobById(int id);

		Task<Job> AddJob(JobRequestModel model);
		
		Task<List<SubmissionResponseModel>> GetJobSubmissions(int jobId);

		Task<Submission> ApplyJob(int jobId, SubmissionRequestModel model);

		Task<Job> CloseJob(int jobId, JobUpdateModel model);
		
	}
}

