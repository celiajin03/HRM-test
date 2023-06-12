using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Data;

public class RecruitingDbContext: DbContext
{
    public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
    {
        
    }
    
    // DbSet are properties of DbContext
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }
    public DbSet<Submission> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I can use this method to do Fluent API way to do any schema changes just like Data Annotation.
        modelBuilder.Entity<Candidate>(ConfigureCandidate);
        // Action<EntityTypeBuilder<TEntity>> buildAction)  
        
        // Jobs
        string LocationOfJobsJsonData = "../Infrastructure/Data/JobsMockData.json";
        var JobsJsonData = File.ReadAllText(LocationOfJobsJsonData);
        IList<Job> Jobs = JsonConvert.DeserializeObject<IList<Job>>(JobsJsonData);
        modelBuilder.Entity<Job>().HasData(Jobs);
        
        // JobStatusLookUps
        string LocationOfJobStatusLookUpsJsonData = "../Infrastructure/Data/JobStatusLookUpsMockData.json";
        var JobStatusLookUpsJsonData = File.ReadAllText(LocationOfJobStatusLookUpsJsonData);
        IList<JobStatusLookUp> JobStatusLookUps = JsonConvert.DeserializeObject<IList<JobStatusLookUp>>(JobStatusLookUpsJsonData);
        modelBuilder.Entity<JobStatusLookUp>().HasData(JobStatusLookUps);
        
        // Candidates
        string LocationOfCandidatesJsonData = "../Infrastructure/Data/CandidatesMockData.json";
        var CandidatesJsonData = File.ReadAllText(LocationOfCandidatesJsonData);
        IList<Candidate> Candidates = JsonConvert.DeserializeObject<IList<Candidate>>(CandidatesJsonData);
        modelBuilder.Entity<Candidate>().HasData(Candidates);
        
        // Submissions
        string LocationOfSubmissionsJsonData = "../Infrastructure/Data/SubmissionsMockData.json";
        var SubmissionsJsonData = File.ReadAllText(LocationOfSubmissionsJsonData);
        IList<Submission> Submissions = JsonConvert.DeserializeObject<IList<Submission>>(SubmissionsJsonData);
        modelBuilder.Entity<Submission>().HasData(Submissions);
        
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
    {
        // we can establish the rules for candidate table
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
    }
}