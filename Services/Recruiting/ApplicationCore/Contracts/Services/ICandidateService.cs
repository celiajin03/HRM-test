using System;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
	public interface ICandidateService
	{
		Task<List<CandidateResponseModel>> GetAllCandidates();
		
		Task<CandidateResponseModel> GetCandidateById(int id);

		Task<Candidate> AddCandidate(CandidateRequestModel model);

		Task<int> GetCandidateIdByEmail(string email);

		Task<Candidate> UpdateResume(int candidateId, CandidateUpdateModel model);
	}
}

