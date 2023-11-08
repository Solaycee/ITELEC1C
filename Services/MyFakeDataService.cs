using DyITELEC1C.Models;
using DyITELEC1C.Services;

namespace DyITELEC1C.Services

{

    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Instructor> InstructorList { get; }
        public List<Student> StudentList { get; }
        public MyFakeDataService()//constructor
        {
            StudentList = new List<Student>
            {
                new Student()
                {
                    Id= 1,FirstName = "Ryan Christopher",LastName = "Dy", Course = Course.BSIT, AdmissionDate = DateTime.Parse("2021-05-05"), Email = "ryandy02@gmail.com"
                },
                new Student()
                {
                    Id= 2,FirstName = "John Paolo",LastName = "Tan", Course = Course.BSIS, AdmissionDate = DateTime.Parse("2020-05-03"), Email = "johnpaolotan@gmail.com"
                },
                new Student()
                {
                    Id= 3,FirstName = "Kyla Angela",LastName = "Montilla", Course = Course.BSCS, AdmissionDate = DateTime.Parse("2022-06-17"), Email = "kylamontilla@gmail.com"
                }
            };

            InstructorList = new List<Instructor>()
            {
            new Instructor()
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
                FirstName = "Jed",
                LastName = "Hernandez",
                IsTenured = IsTenured.Probationary,
                DateHired = DateTime.Parse("10,4,2021"),
                Email = "jedhernandez@ust.edu.ph",
                Rank = Rank.Prof

            }
        };
        }
    }
}