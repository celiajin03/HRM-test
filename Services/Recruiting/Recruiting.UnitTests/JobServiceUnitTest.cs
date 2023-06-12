using System.Linq.Expressions;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Moq;

namespace Recruiting.UnitTests;

[TestClass]
public class JobServiceUnitTest
{
    private JobService _sut;
    private static List<Job> _jobs;
    private Mock<IJobRepository> _mockJobRepository;

    [TestInitialize]
    // [OneTimeSetup] in nUnit
    public void OnetimeSetup()
    {
        _mockJobRepository = new Mock<IJobRepository>();
        
        _sut = new JobService(_mockJobRepository.Object, new SubmissionService(new MockSubmissionRepository()), new CandidateService(new MockCandidateRepository()));
        _mockJobRepository.Setup(m => m.GetAllJobs()).ReturnsAsync(_jobs);
    }
    
    [ClassInitialize]
    public static void SetUp(TestContext context)
    {
        _jobs = new List<Job>
        {
            new Job
            {
                Id = 1, Title = ".NET Developer", Description = "Need to be good with C# and EF Core and .NET"
            },
            new Job
            {
                Id = 2, Title = "Full Stack .NET Developer",
                Description = "Need to be good with Typescript, C# and EF Core and .NET"
            },
            new Job { Id = 3, Title = "Java Developer", Description = "Need to be good with Java" },
            new Job { Id = 4, Title = "JavaScript Developer", Description = "Need to be good with JavaScript" }
        };
    }
    
    
    [TestMethod]
    public async Task TestAllJobsFromFakeData()
    {
        // SUT = System under Test; JobService => GetAllJobs
        
        // Arrange
        // create mock objects, data, methods etc
        // _sut = new JobService(new MockJobRepository(), new SubmissionService(new MockSubmissionRepository()), new CandidateService(new MockCandidateRepository()));

        // Act
        var jobs = await _sut.GetAllJobs();
        
        // check the actual output with expected data.
        // AAA
        // Arrange, Act, and Asset
        
        // Assert
        Assert.IsNotNull(jobs);
        Assert.IsInstanceOfType(jobs, typeof(IEnumerable<JobResponseModel>));
        Assert.AreEqual(4,jobs.Count());
    }

    /*
    public class MockJobRepository: IJobRepository
    {
        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<Job, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> AddSync(Job entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> UpdateAsync(Job entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> GetAllJobs()
        {
            // this method will get the fake data
            var _jobs = new List<Job>
            {
                new Job
                {
                    Id = 1, Title = ".NET Developer", Description = "Need to be good with C# and EF Core and .NET"
                },
                new Job
                {
                    Id = 2, Title = "Full Stack .NET Developer",
                    Description = "Need to be good with Typescript, C# and EF Core and .NET"
                },
                new Job { Id = 3, Title = "Java Developer", Description = "Need to be good with Java" },
                new Job { Id = 4, Title = "JavaScript Developer", Description = "Need to be good with JavaScript" }
            };

            return _jobs;
        }

        public async Task<List<Job>> GetJobsByPagination(int skipCount, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Job> GetJobById(int id)
        {
            throw new NotImplementedException();
        }
    }
    */
    
    public class MockSubmissionRepository:ISubmissionRepository
    {
        public async Task<IEnumerable<Submission>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Submission> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<Submission, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Submission> AddSync(Submission entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Submission> UpdateAsync(Submission entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Submission>> GetSubmissionsByJobId(int jobId)
        {
            throw new NotImplementedException();
        }

        public async Task<Submission> GetSubmissionByCandidateId(int candidateId)
        {
            throw new NotImplementedException();
        }
    }
    
    public class MockCandidateRepository:ICandidateRepository
    {
        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<Candidate, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> AddSync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> UpdateAsync(Candidate entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetCandidateIdByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}