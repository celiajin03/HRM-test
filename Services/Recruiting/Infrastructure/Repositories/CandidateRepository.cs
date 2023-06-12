using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class CandidateRepository: BaseRepository<Candidate>, ICandidateRepository
	{
		private RecruitingDbContext _dbContext;
		public CandidateRepository(RecruitingDbContext dbContext): base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<Candidate>> GetAllCandidates()
		{
			var candidates = await _dbContext.Candidates.ToListAsync();
			return candidates;
		}

		public async Task<Candidate> GetCandidateById(int id)
		{
			var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(j => j.Id == id);
			return candidate;
		}
		
		public async Task<int> GetCandidateIdByEmail(string email)
		{
			var candidate = await _dbContext.Candidates
				.FirstOrDefaultAsync(c => c.Email == email);

			return candidate.Id;
		}

	}
}

