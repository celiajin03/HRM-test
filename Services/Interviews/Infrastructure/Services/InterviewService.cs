using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class InterviewService : IInterviewService
	{
        private readonly IInterviewRepository _interviewRepository;

        public InterviewService(IInterviewRepository interviewRepository)
        {
            _interviewRepository = interviewRepository;
        }

        public async Task< List<InterviewResponseModel>> GetAllInterviews()
        {
            var interviews = await _interviewRepository.GetAllInterviews();
            
            var interviewResponseModel = new List<InterviewResponseModel>();
            foreach (var interview in interviews)
            {
                interviewResponseModel.Add(new InterviewResponseModel
                {
                    Id = interview.Id, 
                    BeginTime = interview.BeginTime, 
                    CandidateEmail = interview.CandidateEmail, 
                    CandidateFirstName = interview.CandidateFirstName, 
                    CandidateIdentityId = interview.CandidateIdentityId, 
                    CandidateLastName = interview.CandidateLastName,
                    EndTime = interview.EndTime,
                    Feedback = interview.Feedback,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                    Passed = interview.Passed,
                    Rating = interview.Rating,
                    SubmissionId = interview.SubmissionId
                });
            }
            return interviewResponseModel;
        }
        
        public async Task<List<InterviewResponseModel>> GetInterviewsByPagination(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;
            var interviews = await _interviewRepository.GetInterviewsByPagination(skipCount, pageSize);
            
            var interviewResponseModels = interviews.Select(interview => new InterviewResponseModel
            {
                Id = interview.Id, 
                BeginTime = interview.BeginTime, 
                CandidateEmail = interview.CandidateEmail, 
                CandidateFirstName = interview.CandidateFirstName, 
                CandidateIdentityId = interview.CandidateIdentityId, 
                CandidateLastName = interview.CandidateLastName,
                EndTime = interview.EndTime,
                Feedback = interview.Feedback,
                InterviewerId = interview.InterviewerId,
                InterviewTypeId = interview.InterviewTypeId,
                Passed = interview.Passed,
                Rating = interview.Rating,
                SubmissionId = interview.SubmissionId
            }).ToList();

            return interviewResponseModels;
        }

        public async Task<InterviewResponseModel> GetInterviewById(int id)
        {
            var interview = await _interviewRepository.GetInterviewById(id);
            var interviewResponseModel = new InterviewResponseModel
            {
                Id = interview.Id, 
                BeginTime = interview.BeginTime, 
                CandidateEmail = interview.CandidateEmail, 
                CandidateFirstName = interview.CandidateFirstName, 
                CandidateIdentityId = interview.CandidateIdentityId, 
                CandidateLastName = interview.CandidateLastName,
                EndTime = interview.EndTime,
                Feedback = interview.Feedback,
                InterviewerId = interview.InterviewerId,
                InterviewTypeId = interview.InterviewTypeId,
                Passed = interview.Passed,
                Rating = interview.Rating,
                SubmissionId = interview.SubmissionId
            };
            return interviewResponseModel;
        }

        public async Task<Interview> AddInterview(InterviewRequestModel model)
        {
            var interviewEntity = new Interview
            {
                BeginTime = model.BeginTime, 
                CandidateEmail = model.CandidateEmail, 
                CandidateFirstName = model.CandidateFirstName, 
                CandidateIdentityId = model.CandidateIdentityId, 
                CandidateLastName = model.CandidateLastName,
                EndTime = model.EndTime,
                InterviewerId = model.InterviewerId,
                InterviewTypeId = model.InterviewTypeId,
                SubmissionId = model.SubmissionId
            };

            var interview = await _interviewRepository.AddSync(interviewEntity);
            return interview;
        }
        
        public async Task<Interview> RescheduleInterview(int id, InterviewRescheduleModel model)
        {
            var interview = await _interviewRepository.RescheduleInterview(id, model);
            return interview;
        }

        public async Task<int> DeleteInterview(int id)
        {
            return await _interviewRepository.DeleteInterview(id);
        }

        public async Task<Interview> GiveFeedbackRating(int id, InterviewFeedbackModel model)
        {
            var interview = await _interviewRepository.GiveFeedbackRating(id, model);
            return interview;
        }
        
        public async Task<List<InterviewResponseModel>> GetInterviewsByInterviewer(int interviewerId, int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;
            var interviews = await _interviewRepository.GetInterviewsByInterviewer(interviewerId, skipCount, pageSize);
            
            var interviewResponseModel = new List<InterviewResponseModel>();
            foreach (var interview in interviews)
            {
                interviewResponseModel.Add(new InterviewResponseModel
                {
                    Id = interview.Id, 
                    BeginTime = interview.BeginTime, 
                    CandidateEmail = interview.CandidateEmail, 
                    CandidateFirstName = interview.CandidateFirstName, 
                    CandidateIdentityId = interview.CandidateIdentityId, 
                    CandidateLastName = interview.CandidateLastName,
                    EndTime = interview.EndTime,
                    Feedback = interview.Feedback,
                    InterviewerId = interview.InterviewerId,
                    InterviewTypeId = interview.InterviewTypeId,
                    Passed = interview.Passed,
                    Rating = interview.Rating,
                    SubmissionId = interview.SubmissionId
                });
            }
            return interviewResponseModel;
        }
    }
}

