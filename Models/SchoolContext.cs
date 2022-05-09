using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<School> Schools { get; set; } 
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Student> Students { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var school = new School("George's Institute", 2020, SchoolType.High,
                        "Argentina", "Córdoba", "2372 San Javier Street");
            school.UniqueId = Guid.NewGuid().ToString();

            modelBuilder.Entity<School>().HasData(school);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    UniqueId = Guid.NewGuid().ToString(),
                    Name = "Introduction 101"
                },
                            new Course
                            {
                                UniqueId = Guid.NewGuid().ToString(),
                                Name = "C# 101"
                            },
                            new Course
                            {
                                UniqueId = Guid.NewGuid().ToString(),
                                Name = "Cyber-security 101"
                            },
                            new Course
                            {
                                UniqueId = Guid.NewGuid().ToString(),
                                Name = "Crypto analysis 101"
                            }
            );

            modelBuilder.Entity<Student>()
                        .HasData(GenerateRandomStudents().ToArray());

        }

        private List<Student> GenerateRandomStudents()
        {
            string[] name1 = { "Michael", "Janice", "John", "George", "Donald", "Thomas", "Nichole", "Karen" };
            string[] surname1 = { "Adams", "Smith", "Johnson", "Parker", "Trump", "Brown", "Turner" };
            string[] name2 = { "William", "Laura", "Rick", "Leonard", "Silvie", "Ellen", "Bryan", "Bruce" };

            var studentList = from n1 in name1
                              from n2 in name2
                              from a1 in surname1
                              select new Student { Name = $"{n1} {n2} {a1}" };

            return studentList.OrderBy((al) => al.UniqueId).ToList();
        }
    }
}