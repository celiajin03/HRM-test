using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Data;

public class OnBoardingDbContext:DbContext
{
    public OnBoardingDbContext(DbContextOptions<OnBoardingDbContext> options):base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeStatusLookUp> EmployeeStatusLookUps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(ConfigureEmployees);
        modelBuilder.Entity<EmployeeStatusLookUp>(ConfigureEmployeeStatusLookUps);
        
        // Employees Mock Data
        string LocationOfEmployeesJsonData = "../Infrastructure/Data/EmployeesMockData.json";
        var EmployeesJsonData = File.ReadAllText(LocationOfEmployeesJsonData);
        IList<Employee> Employees = JsonConvert.DeserializeObject<IList<Employee>>(EmployeesJsonData);
        modelBuilder.Entity<Employee>().HasData(Employees);
        
        // EmployeeStatusLookUps Mock Data
        string LocationOfEmployeeStatusLookUpsJsonData = "../Infrastructure/Data/EmployeeStatusLookUpsMockData.json";
        var EmployeeStatusLookUpsJsonData = File.ReadAllText(LocationOfEmployeeStatusLookUpsJsonData);
        IList<EmployeeStatusLookUp> EmployeeStatusLookUps = JsonConvert.DeserializeObject<IList<EmployeeStatusLookUp>>(EmployeeStatusLookUpsJsonData);
        modelBuilder.Entity<EmployeeStatusLookUp>().HasData(EmployeeStatusLookUps);
        
        base.OnModelCreating(modelBuilder);
    }

    private void ConfigureEmployees(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.EmployeeIdentityId).IsUnique();
        builder.HasOne(e => e.EmployeeStatusLookUp)
            .WithMany()
            .HasForeignKey(e => e.EmployeeStatusId);
    }
    
    private void ConfigureEmployeeStatusLookUps(EntityTypeBuilder<EmployeeStatusLookUp> builder)
    {
        builder.HasKey(e => e.Id);
    }

}