using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using DyITELEC1C.Models;
using System.Reflection.Metadata.Ecma335;

namespace DyITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>()
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

            },
        };

        public IActionResult Index()
        {
            return View (InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(qe => qe.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }

        [HttpGet]
        
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        
        public IActionResult UpdateInstructor(Instructor UpdateInstructor)
        {
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == UpdateInstructor.Id);

            if(instructor != null)
            {
                instructor.FirstName = UpdateInstructor.FirstName;
                instructor.LastName = UpdateInstructor.LastName;
                instructor.Rank = UpdateInstructor.Rank; 
                instructor.Email = UpdateInstructor.Email; 
                instructor.IsTenured = UpdateInstructor.IsTenured;  
                instructor.DateHired = UpdateInstructor.DateHired;
            }
                return View("Index", InstructorList);
        }
    }  
}
