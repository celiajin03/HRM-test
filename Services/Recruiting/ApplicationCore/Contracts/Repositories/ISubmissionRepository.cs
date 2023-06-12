using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface ISubmissionRepository: IBaseRepository<Submission>
	{
		Task<List<Submission>> GetSubmissionsByJobId(int jobId);

		Task<Submission> GetSubmissionByCandidateId(int candidateId);
	}
}

