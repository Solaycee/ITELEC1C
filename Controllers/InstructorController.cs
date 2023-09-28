using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using DyITELEC1C.Models;
using System.Reflection.Metadata.Ecma335;
using DyITELEC1C.Services;

namespace DyITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _dummyData;
        public InstructorController(IMyFakeDataService dummyData)
        {
            _dummyData = dummyData;
        }

        public IActionResult Index()
        {
            return View (_dummyData.InstructorList);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(qe => qe.Id == id);

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
            _dummyData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
            //return View("Index", InstructorList);
        }

        [HttpGet]
        
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        
        public IActionResult UpdateInstructor(Instructor UpdateInstructor)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == UpdateInstructor.Id);

            if(instructor != null)
            {
                instructor.FirstName = UpdateInstructor.FirstName;
                instructor.LastName = UpdateInstructor.LastName;
                instructor.Rank = UpdateInstructor.Rank; 
                instructor.Email = UpdateInstructor.Email; 
                instructor.IsTenured = UpdateInstructor.IsTenured;  
                instructor.DateHired = UpdateInstructor.DateHired;
            }
            return RedirectToAction("Index");
            //return View("Index", _dummyData.InstructorList);
        }
        public IActionResult DeleteInstructor()
        {
            return View();
        }


        [HttpGet]

        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(Student deleteInstructor)
        {
            Instructor? instructor = _dummyData.InstructorList.FirstOrDefault(st => st.Id == deleteInstructor.Id);

            if (instructor != null)
                _dummyData.InstructorList.Remove(instructor);
            return RedirectToAction("Index");
            //return View("Index", _dummyData.InstructorList);
        }
    }
}
