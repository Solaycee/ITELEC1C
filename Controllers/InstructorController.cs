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
                IsTenured = "Permanent",
                DateHired = DateTime.Now,
                Email = "orlanventura@ust.edu.ph", 
                Rank = Rank.Instructor

            },

            new Instructor()
            {
                Id = 2,
                FirstName = "Gabriel",
                LastName = "Montano",
                IsTenured = "Permanent",
                DateHired = DateTime.Parse("20,2,2023"),
                Email = "gdmontano@ust.edu.ph", 
                Rank = Rank.AssistProf
                
            },

            new Instructor()
            {
                FirstName = "Jed", 
                LastName = "Hernandez",
                IsTenured = "Probationary",
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
    }
}
