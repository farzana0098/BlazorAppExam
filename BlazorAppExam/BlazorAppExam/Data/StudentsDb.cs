using BlazorAppExam.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppExam.Data
{
    public class StudentsDb:DbContext
    {
        public StudentsDb(DbContextOptions options)
: base(options)
        {
        }

        public DbSet<Students> Students { get; set; } = default!;
        public DbSet<StudentsMarks> StudentsMarks { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Exam1StudentsDBBlazor;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasData(new Students[]
                {

                new Students
                {
                    StudentId = 1,
                    Name = "Bikes",
					//Regular = true,
					Class = 6
                },


                new Students
                {
                    StudentId = 2,
                    Name = "Abdullah",
					//Regular = true,
					Class = 6
                },

                new Students
                {
                    StudentId = 3,
                    Name = "Jannat",
					//Regular = true,
					Class = 7
                },

                new Students
                {
                    StudentId = 4,
                    Name = "Bikes",
					//Regular = true,
					Class = 7
                },

                new Students
                {
                    StudentId = 5,
                    Name = "Farzana",
					//Regular = true,
					Class = 7
                },

                new Students
                {
                    StudentId = 6,
                    Name = "Hasib",
					//Regular = true,
					Class = 7
                }



                });



            modelBuilder.Entity<StudentsMarks>().HasData(new StudentsMarks[]
        {

            new StudentsMarks
                {
                    ID = 1,
                    ExamName = "Final",
                    TotalNumber=800,
                    ObtainedNumber=600,

                    StudentId = 1,
                },
        new StudentsMarks
                {
                    ID = 2,
                    ExamName = "External",
                    TotalNumber=800,
                    ObtainedNumber=600,

                    StudentId = 2,
                },
        new StudentsMarks
                {
                    ID = 3,
                    ExamName = "Evidence",
                    TotalNumber=800,
                    ObtainedNumber=600,

                    StudentId = 3,
                }







        });
        }
    }
}
