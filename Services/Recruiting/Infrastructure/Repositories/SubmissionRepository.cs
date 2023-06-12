using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
{
    private readonly RecruitingDbContext _dbContext;

    public SubmissionRepository(RecruitingDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Submission>> GetSubmissionsByJobId(int jobId)
    {
        return await _dbContext.Submissions
            .Where(s => s.JobId == jobId)
            .ToListAsync();
    }
    
    public async Task<Submission> GetSubmissionByCandidateId(int candidateId)
    {
        return await _dbContext.Submissions
            .FirstOrDefaultAsync(s => s.CandidateId == candidateId);
    }
}