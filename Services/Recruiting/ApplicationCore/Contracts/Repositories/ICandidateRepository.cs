using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  ICandidateRepository:IBaseRepository<Candidate>
	{
		Task<List<Candidate>> GetAllCandidates();

		Task<Candidate> GetCandidateById(int id);

		Task<int> GetCandidateIdByEmail(string email);
	}
}

