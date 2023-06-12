using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface IInterviewService
	{
		Task<List<InterviewResponseModel>> GetAllInterviews();
		
		Task<List<InterviewResponseModel>> GetInterviewsByPagination(int page, int pageSize);
		
		Task<InterviewResponseModel> GetInterviewById(int id);

		Task<Interview> AddInterview(InterviewRequestModel model);

		Task<Interview> RescheduleInterview(int interviewId, InterviewRescheduleModel model);
		
		Task<int> DeleteInterview(int interviewId);

		Task<Interview> GiveFeedbackRating(int id, InterviewFeedbackModel model);

		Task<List<InterviewResponseModel>> GetInterviewsByInterviewer(int InterviewerId, int page, int pageSize);
	}
}

