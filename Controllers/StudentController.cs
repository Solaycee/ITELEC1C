using Microsoft.AspNetCore.Mvc;
using DyITELEC1C.Models;
using System.Reflection.Metadata.Ecma335;
using DyITELEC1C.Services;

namespace DyITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _dummyData;
        
        public StudentController(IMyFakeDataService dummyData) 
        {
            _dummyData = dummyData;
        }
       
        public IActionResult Index()
        {

            return View(_dummyData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);                                                   

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddStudent()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent) 
        { 
            _dummyData.StudentList.Add(newStudent);
            return RedirectToAction("Index");
            //return View("Index", _dummyData.StudentList);
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student updateStudent)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == updateStudent.Id);
            
            if (student != null)
            {
                student.FirstName = updateStudent.FirstName;
                student.LastName = updateStudent.LastName;  
                student.Email = updateStudent.Email;    
                student.Course = updateStudent.Course;  
                student.AdmissionDate = updateStudent.AdmissionDate;
            }
            return RedirectToAction("Index");
            //return View("Index", _dummyData.StudentList);
        }

        public IActionResult DeleteStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteStudent(Student deleteStudent)
        {
            Student? student = _dummyData.StudentList.FirstOrDefault(st => st.Id == deleteStudent.Id);

            if (student != null)
                _dummyData.StudentList.Remove(student);
            return RedirectToAction("Index");
            //return View("Index", _dummyData.StudentList);
        }
    }
} 