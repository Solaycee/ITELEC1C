using Microsoft.EntityFrameworkCore;
using DyITELEC1C.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DyITELEC1C.Data

{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    FirstName = "Ryan Christopher",
                    LastName = "Dy",
                    Course = Course.BSIT,
                    AdmissionDate = DateTime.Parse("2021-05-05"),
                    Email = "ryandy02@gmail.com"
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "John Paolo",
                    LastName = "Tan",
                    Course = Course.BSIS,
                    AdmissionDate = DateTime.Parse("2020-05-03"),
                    Email = "johnpaolotan@gmail.com"
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Kyla Angela",
                    LastName = "Montilla",
                    Course = Course.BSCS,
                    AdmissionDate = DateTime.Parse("2022-06-17"),
                    Email = "kylamontilla@gmail.com",
                });

            modelBuilder.Entity<Instructor>().HasData(new Instructor()
            {
                Id = 1,
                FirstName = "Orlan",
                LastName = "Ventura",
                IsTenured = IsTenured.Permanent,
                DateHired = DateTime.Now,
                Email = "orlanventura@ust.edu.ph",
                Rank = Rank.Instructor
            },

            new Instructor()
            {
                Id = 2,
                FirstName = "Gabriel",
                LastName = "Montano",
                IsTenured = IsTenured.Permanent,
                DateHired = DateTime.Parse("20,2,2023"),
                Email = "gdmontano@ust.edu.ph",
                Rank = Rank.AssistProf
            },

            new Instructor()
            {
                Id = 3,
                FirstName = "Jed",
                LastName = "Hernandez",
                IsTenured = IsTenured.Probationary,
                DateHired = DateTime.Parse("10,4,2021"),
                Email = "jedhernandez@ust.edu.ph",
                Rank = Rank.Prof
            });
        }
    }
}
