using Microsoft.AspNetCore.Mvc;
using DyITELEC1C.Models;

namespace DyITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        List<Student> StudentList = new List<Student>
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
        public IActionResult Index()
        {

            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);                                                   

            return NotFound();
        }

    }
}