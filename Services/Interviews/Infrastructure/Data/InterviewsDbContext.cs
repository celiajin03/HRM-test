using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Data;

public class InterviewsDbContext:DbContext
{
    public InterviewsDbContext(DbContextOptions<InterviewsDbContext> options):base(options)
    {
        
    }

    public DbSet<Interview> Interviews { get; set; }
    public DbSet<InterviewTypeLookUp> InterviewTypeLookUps { get; set; }
    public DbSet<Interviewer> Interviewers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interview>(ConfigureInterview);
        modelBuilder.Entity<InterviewTypeLookUp>(ConfigureInterviewTypeLookUp);
        modelBuilder.Entity<Interviewer>(ConfigureInterviewer);
        
        // Interviews Mock Data
        // get location
        string LocationOfInterviewsJsonData = "../Infrastructure/Data/InterviewsMockData.json";
        // read all data(JSON TYPE)
        var InterviewsJsonData = File.ReadAllText(LocationOfInterviewsJsonData);
        // convert JSON type to DB type
        IList<Interview> Interviews = JsonConvert.DeserializeObject<IList<Interview>>(InterviewsJsonData);
        // Store to table in DB
        modelBuilder.Entity<Interview>().HasData(Interviews);
        
        // InterviewTypeLookUps  Mock Data
        string LocationOfInterviewTypeLookUpsJsonData = "../Infrastructure/Data/InterviewTypeLookUpsMockData.json";
        var InterviewTypeLookUpsJsonData = File.ReadAllText(LocationOfInterviewTypeLookUpsJsonData);
        IList<InterviewTypeLookUp> InterviewTypeLookUps = JsonConvert.DeserializeObject<IList<InterviewTypeLookUp>>(InterviewTypeLookUpsJsonData);
        modelBuilder.Entity<InterviewTypeLookUp>().HasData(InterviewTypeLookUps);

        // Interviewers Mock Data
        string LocationOfInterviewersJsonData = "../Infrastructure/Data/InterviewersMockData.json";
        var InterviewersJsonData = File.ReadAllText(LocationOfInterviewersJsonData);
        IList<Interviewer> Interviewers = JsonConvert.DeserializeObject<IList<Interviewer>>(InterviewersJsonData);
        modelBuilder.Entity<Interviewer>().HasData(Interviewers);

        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureInterview(EntityTypeBuilder<Interview> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.CandidateIdentityId).IsUnique();
    }

    private void ConfigureInterviewTypeLookUp(EntityTypeBuilder<InterviewTypeLookUp> builder)
    {
        builder.HasKey(i => i.Id);
    }

    private void ConfigureInterviewer(EntityTypeBuilder<Interviewer> builder)
    {
        builder.HasKey(i => i.Id);
        builder.HasIndex(i => i.EmployeeIdentityId).IsUnique();
    }
}