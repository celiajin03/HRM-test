using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task< List<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await _candidateRepository.GetAllCandidates();
            if (candidates == null) throw new ArgumentNullException(nameof(candidates));

            var candidateResponseModel = new List<CandidateResponseModel>();
            foreach (var candidate in candidates)
            {
                candidateResponseModel.Add(new CandidateResponseModel
                {
                    Id = candidate.Id,
                    FirstName = candidate.FirstName,
                    MiddleName = candidate.MiddleName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    ResumeURL = candidate.ResumeURL,
                    CreatedOn = candidate.CreatedOn
                });
            }
            return candidateResponseModel;
        }

        public async Task<CandidateResponseModel> GetCandidateById(int id)
        {
            var candidate = await _candidateRepository.GetCandidateById(id);
            var candidateResponseModel = new CandidateResponseModel
            {
                Id = candidate.Id,
                FirstName = candidate.FirstName,
                MiddleName = candidate.MiddleName,
                LastName = candidate.LastName,
                Email = candidate.Email,
                ResumeURL = candidate.ResumeURL,
                CreatedOn = candidate.CreatedOn,
            };
            return candidateResponseModel;
        }

        public async Task<Candidate> AddCandidate(CandidateRequestModel model)
        {
            var candidateEntity = new Candidate
            {
                Id = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                ResumeURL = model.ResumeURL,
                CreatedOn = DateTime.UtcNow,
            };

            var candidate = await _candidateRepository.AddSync(candidateEntity);
            return candidate;
        }

        public async Task<int> GetCandidateIdByEmail(string email)
        {
            return await _candidateRepository.GetCandidateIdByEmail(email);
        }
        
        public async Task<Candidate> UpdateResume(int candidateId, CandidateUpdateModel model)
        {
            var candidateEntity = await _candidateRepository.GetCandidateById(candidateId);

            candidateEntity.ResumeURL = model.ResumeURL;

            var candidate = await _candidateRepository.UpdateAsync(candidateEntity);
            return candidate;
        }

    }
}

