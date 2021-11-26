using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tutorias.Models;
namespace Tutorias.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Tutorship> Tutorships { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<TutorCategory> TutorCategories { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TutorSubject> TutorSubjects { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Tutor>().ToTable("Tutor");
        modelBuilder.Entity<Tutorship>().ToTable("Tutorship");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Category>().ToTable("Category");
        modelBuilder.Entity<TutorCategory>().ToTable("TutorCategory");
        modelBuilder.Entity<Subject>().ToTable("Subject");
        modelBuilder.Entity<TutorSubject>().ToTable("TutorSubject");
    }
}
