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
                InstructorName = "Orlan Ventura", DateHired = DateTime.Now,
                InstructorEmail = "orlanventura@ust.edu.ph", Rank = Rank.Instructor

            },

            new Instructor()
            {
                InstructorName = "Gabriel Montano", DateHired = DateTime.Parse("20,2,2023"),
                InstructorEmail = "gdmontano@ust.edu.ph", Rank = Rank.AssistProf
                
            },

            new Instructor()
            {
                InstructorName = "Jed Hernandez", DateHired = DateTime.Parse("10,4,2021"),
                InstructorEmail = "jedhernandez@ust.edu.ph", Rank = Rank.Prof

            },
        };

        public IActionResult Index()
        {
            return View (InstructorList);
        }
    }
}
