using ApiPractice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiPractice.Infrastructure;

public class UniversityManagementContext : DbContext
{
    public UniversityManagementContext() {}
    
    public UniversityManagementContext(DbContextOptions<UniversityManagementContext> options) : base(options)
    {
    }
    /// <summary>
    /// Get a connection string from appsettings.json
    /// </summary>
    /// <returns>the connection string</returns>
    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
        string strConn = config.GetConnectionString("DefaultConnection");
        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Major> Majors { get; set; }
    public DbSet<ClubRegistration> ClubRegistrations { get; set; }
    public DbSet<StudentMajor> StudentMajors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentMajor>()
            .Property(sm => sm.No)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<StudentMajor>()
            .HasKey(sm => sm.No);

        modelBuilder.Entity<StudentMajor>()
            .HasOne(sm => sm.Student)
            .WithMany(s => s.StudentMajors)
            .HasForeignKey(sm => sm.StudentId);

        modelBuilder.Entity<StudentMajor>()
            .HasOne(sm => sm.Major)
            .WithMany(m => m.StudentMajors)
            .HasForeignKey(sm => sm.MajorId);
        
        modelBuilder.Entity<ClubRegistration>()
            .Property(cr => cr.No)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<ClubRegistration>()
            .HasKey(cr => cr.No);

        modelBuilder.Entity<ClubRegistration>()
            .HasOne(cr => cr.Student)
            .WithMany(s => s.ClubRegistrations)
            .HasForeignKey(cr => cr.StudentId);

        modelBuilder.Entity<ClubRegistration>()
            .HasOne(cr => cr.Club)
            .WithMany(c => c.ClubRegistrations)
            .HasForeignKey(cr => cr.ClubId);
    }
}