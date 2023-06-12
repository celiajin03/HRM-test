using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class JobService : IJobService
	{
        private readonly IJobRepository _jobRepository;
        private readonly ISubmissionService _submissionService;
        private readonly ICandidateService _candidateService;

        public JobService(IJobRepository jobRepository, ISubmissionService submissionService, ICandidateService candidateService)
        {
            _jobRepository = jobRepository;
            _submissionService = submissionService;
            _candidateService = candidateService;
        }

        public async Task< List<JobResponseModel>> GetAllJobs()
        {
            /*
            //have some fummy data
            var jobs = new List<JobResponseModel>()
            {
                new JobResponseModel {Id = 1, Title=".NET Developer", Description = "Need to be good with C# and EF Core and .NET"},
                new JobResponseModel { Id = 2, Title = "Full Stack .NET Developer", Description = "Need to be good with Typescript, C# and EF Core and .NET" },
                new JobResponseModel {Id = 3, Title="Java Developer", Description = "Need to be good with Java"},
                new JobResponseModel {Id = 4, Title="JavaScript Developer", Description = "Need to be good with JavaScript"}
            };
            return jobs;
            */
            var jobs = await _jobRepository.GetAllJobs();
            
            var jobResponseModel = new List<JobResponseModel>();
            foreach (var job in jobs)
            {
                jobResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id, 
                    Description = job.Description, 
                    Title = job.Title, 
                    StartDate = job.StartDate.GetValueOrDefault(), 
                    NumberOfPositions = job.NumberOfPositions, 
                    JobCode = job.JobCode,
                    IsActive = job.IsActive,
                    CreatedOn = job.CreatedOn
                });
            }
            return jobResponseModel;
            
            /*
             // LINQ
            return jobs.Select(job => new JobResponseModel
                { Id = job.Id, Description = job.Description, Title = job.Title }).ToList();
            */
        }

        public async Task<List<JobResponseModel>> GetJobsByPagination(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;
            // Retrieve the jobs from the data source with pagination
            var jobs = await _jobRepository.GetJobsByPagination(skipCount, pageSize);
            
            var jobResponseModels = jobs.Select(job => new JobResponseModel
            {
                Id = job.Id, 
                Description = job.Description, 
                Title = job.Title, 
                StartDate = job.StartDate.GetValueOrDefault(), 
                NumberOfPositions = job.NumberOfPositions, 
                JobCode = job.JobCode,
                IsActive = job.IsActive,
                CreatedOn = job.CreatedOn
            }).ToList();

            return jobResponseModels;
        }

        public async Task<JobResponseModel> GetJobById(int id)
        {
            // return  new JobResponseModel { Id = 4, Title = "JavaScript Developer", Description = "Need to be good with JavaScript" };
            var job = await _jobRepository.GetJobById(id);
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id, 
                Title = job.Title, 
                StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description,
                NumberOfPositions = job.NumberOfPositions,
                JobCode = job.JobCode, 
                IsActive = job.IsActive,
                CreatedOn = job.CreatedOn
                
            };
            return jobResponseModel;
        }

        public async Task<Job> AddJob(JobRequestModel model)
        {
            // call the repository that will use EF Core to save the data
            var jobEntity = new Job
            {
                Title = model.Title, 
                StartDate = model.StartDate, 
                Description = model.Description,
                CreatedOn = DateTime.UtcNow, 
                NumberOfPositions = model.NumberOfPositions, 
                JobStatusLookUpId = 1, 
                JobCode = Guid.NewGuid()
            };

            var job = await _jobRepository.AddSync(jobEntity);
            return job;
        }
        

        public async Task<List<SubmissionResponseModel>> GetJobSubmissions(int jobId)
        {
            return await _submissionService.GetSubmissionsByJobId(jobId);
        }
        
        public async Task<Submission> ApplyJob(int jobId, SubmissionRequestModel model)
        {
            // Check if an submission already exists for that email
            int candidateId = await _candidateService.GetCandidateIdByEmail(model.Email);
            var existingSubmission = await _submissionService.GetSubmissionByCandidateId(candidateId);

            if (existingSubmission != null) // has Existing Submission
            {
                Console.WriteLine("An existing submission already exists for this candidate.");
                Console.WriteLine($"Existing Submission ID: {existingSubmission.Id}");
                Console.WriteLine($"Submission Date: {existingSubmission.SubmittedOn}");
                return null;
            }
            else
            {
                Submission submission = await _submissionService.AddSubmission(jobId, candidateId);
                return submission;
            }
        }


        public async Task<Job> CloseJob(int jobId, JobUpdateModel model)
        {
            var jobEntity = await _jobRepository.GetJobById(jobId);

            jobEntity.CloseOn = model.CloseOn;
            jobEntity.ClosedReason = model.ClosedReason;
            jobEntity.IsActive = false;
            jobEntity.JobStatusLookUpId = 3;

            var job = await _jobRepository.UpdateAsync(jobEntity);
            return job;
        }
        
    }
}

