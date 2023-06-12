using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class InterviewRepository: BaseRepository<Interview>, IInterviewRepository
	{
		private InterviewsDbContext _dbContext;
		public InterviewRepository(InterviewsDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<List<Interview>> GetAllInterviews()
		{
			var interviews = await _dbContext.Interviews.ToListAsync();
			return interviews;
		}

		public async Task<List<Interview>> GetInterviewsByPagination(int skipCount, int pageSize)
		{
			return await _dbContext.Interviews
				.OrderByDescending(i => i.BeginTime)
				.Skip(skipCount)
				.Take(pageSize)
				.ToListAsync();
		}
		
		public async Task<Interview> GetInterviewById(int id)
		{
			var interview = await _dbContext.Interviews.FirstOrDefaultAsync(i => i.Id == id);
			return interview;
		}
		
		public async Task<Interview> RescheduleInterview(int id, InterviewRescheduleModel model)
		{
			var interview = await _dbContext.Interviews.FindAsync(id);
			if (interview == null)
			{
				return null;
			}

			interview.BeginTime = model.BeginTime;
			interview.EndTime = model.EndTime;
			await _dbContext.SaveChangesAsync();
			return interview;
		}
		
		public async Task<int> DeleteInterview(int id)
		{
			var interview = await _dbContext.Interviews.FindAsync(id);
			if (interview == null)
			{
				throw new InvalidOperationException("The Interview with the specified Id was not found.");
			}

			_dbContext.Interviews.Remove(interview);
			await _dbContext.SaveChangesAsync();
			return id;
		}
		
		public async Task<Interview> GiveFeedbackRating(int id, InterviewFeedbackModel model)
		{
			var interview = await _dbContext.Interviews.FindAsync(id);
			if (interview == null)
			{
				return null;
			}

			interview.Feedback = model.Feedback;
			interview.Rating = model.Rating; 
			await _dbContext.SaveChangesAsync();
			return interview;
		}

		public async Task<List<Interview>> GetInterviewsByInterviewer(int interviewerId, int skipCount, int pageSize)
		{
			var interviews = await _dbContext.Interviews
				.Where(i => i.InterviewerId == interviewerId)
				.OrderByDescending(i => i.BeginTime)
				.Skip(skipCount)
				.Take(pageSize)
				.ToListAsync();
			
			return interviews;
		}

	}
}

