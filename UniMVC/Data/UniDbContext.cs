using Microsoft.EntityFrameworkCore;
using UniMVC.Models;

namespace UniMVC.Data
{
    public class UniDbContext : DbContext
    {
        public UniDbContext(DbContextOptions<UniDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudentGrades> StudentGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentGrades>()
                .HasKey(e => new { e.StudentId, e.DisciplineId });

            base.OnModelCreating(modelBuilder);
        }
    }
}