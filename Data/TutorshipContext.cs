using Tutorias.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutorias.Data
{
    public class TutorshipContext : DbContext
    {
        public TutorshipContext(DbContextOptions<TutorshipContext> options) : base(options)
        {
        }

        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Tutorship> Tutorships { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TutorCategory> TutorCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tutor>().ToTable("Tutor");
            modelBuilder.Entity<Tutorship>().ToTable("Tutorship");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}