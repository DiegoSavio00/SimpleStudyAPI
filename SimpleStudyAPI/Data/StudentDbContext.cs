using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleStudyAPI.Models;

namespace SimpleStudyAPI.Data
{
    public class StudentDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Student> Students { get; set; }

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "Jose Henrique",
                    Email = "joseh@email.com",
                    Age = 27
                },
                new Student
                {
                    Id = 2,
                    Name = "Ana Maria",
                    Email = "ana@email.com",
                    Age = 31
                });
        }
    }
}
