using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories
{
	public interface  IJobRepository:IBaseRepository<Job>
	{
		// List<Job> GetAllJobs();
		Task<List<Job>> GetAllJobs();
		
		Task<List<Job>> GetJobsByPagination(int skipCount, int pageSize);

		Task<Job> GetJobById(int id);
	}
}

