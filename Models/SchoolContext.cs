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
            // Load the grades
            var grades = LoadGrades(school);
            // for each grade, load the courses
            var coursesList = LoadCourses(grades);
            // for each grade, load the students
            var studentList = LoadStudents(grades);   

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Grade>().HasData(grades.ToArray());
            modelBuilder.Entity<Course>().HasData(coursesList.ToArray());
            modelBuilder.Entity<Student>().HasData(studentList.ToArray());

        }
        private static List<Grade> LoadGrades(School school)
        {
            return new List<Grade>{
                        new Grade() {
                            UniqueId = Guid.NewGuid().ToString(),
                            SchoolId = school.UniqueId,
                            Name = "Grade 101",
                            HourType = HourTypes.Morning,
                            Address = "2372 San Javier Street"
                            },
                        new Grade() {
                            UniqueId = Guid.NewGuid().ToString(),
                            SchoolId = school.UniqueId,
                            Name = "Grade 201",
                            HourType = HourTypes.Morning,
                            Address = "2372 San Javier Street"
                            },
                        new Grade() {
                            UniqueId = Guid.NewGuid().ToString(),
                            SchoolId = school.UniqueId,
                            Name = "Grade 301",
                            HourType = HourTypes.Morning,
                            Address = "2372 San Javier Street"
                            }
            };
        }

        private List<Course> LoadCourses(List<Grade> grades)
        {
            var coursesList = new List<Course>();

            foreach (var grade in grades)
            {
                var tmpList = new List<Course>(){
                            new Course{
                                UniqueId = Guid.NewGuid().ToString(),
                                GradeId = grade.UniqueId,
                                Name="Introduction 101"
                                },
                            new Course{
                                UniqueId = Guid.NewGuid().ToString(),
                                GradeId = grade.UniqueId,
                                Name="C# 101"
                                },
                            new Course{
                                UniqueId = Guid.NewGuid().ToString(),
                                GradeId = grade.UniqueId,
                                Name="Cyber-security 101"
                                },
                            new Course{
                                UniqueId = Guid.NewGuid().ToString(),
                                GradeId = grade.UniqueId,
                                Name="Crypto analysis 101"
                                }
                };
                coursesList.AddRange(tmpList);
                //grade.Courses = tmpList;
            }
            return coursesList;
        }

        private List<Student> LoadStudents(List<Grade> grades)
        {
            var studentList = new List<Student>();

            Random rnd = new Random();
            foreach (var grade in grades)
            {
                int randomAmount = rnd.Next(5, 20);
                var tmpList = GenerateRandomStudents(grade, randomAmount);
                studentList.AddRange(tmpList);
            }
            return studentList;
        }

        private List<Student> GenerateRandomStudents(Grade grade, int randomAmount)
        {
            string[] name1 = { "Michael", "Janice", "John", "George", "Donald", "Thomas", "Nichole", "Karen" };
            string[] surname1 = { "Adams", "Smith", "Johnson", "Parker", "Trump", "Brown", "Turner" };
            string[] name2 = { "William", "Laura", "Rick", "Leonard", "Silvie", "Ellen", "Bryan", "Bruce" };

            var studentList = from n1 in name1
                              from n2 in name2
                              from a1 in surname1
                              select new Student
                              {
                                  UniqueId = Guid.NewGuid().ToString(),
                                  Name = $"{n1} {n2} {a1}",
                                  GradeId = grade.UniqueId
                              };

            return studentList.OrderBy((al) => al.UniqueId).Take(randomAmount).ToList();
        }
    }
}