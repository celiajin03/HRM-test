using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  IInterviewRepository:IBaseRepository<Interview>
	{
		Task<List<Interview>> GetAllInterviews();
		
		Task<List<Interview>> GetInterviewsByPagination(int skipCount, int pageSize);

		Task<Interview> GetInterviewById(int id);

		Task<Interview> RescheduleInterview(int id, InterviewRescheduleModel model);

		Task<int> DeleteInterview(int id);

		Task<Interview> GiveFeedbackRating(int id, InterviewFeedbackModel model);

		Task<List<Interview>> GetInterviewsByInterviewer(int interviewerId, int skipCount, int pageSize);
	}
}

