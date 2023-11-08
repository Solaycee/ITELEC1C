using Microsoft.AspNetCore.Mvc;
using DyITELEC1C.Models;
using System.Reflection.Metadata.Ecma335;
using DyITELEC1C.Services;
using DyITELEC1C.Data;

namespace DyITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbData;
        
        public StudentController(AppDbContext dbData) 
        {
            _dbData = dbData;
        }
       
        public IActionResult Index()
        {

            return View(_dbData.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

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
            if (!ModelState.IsValid)
            {
                return View();
                _dbData.Students.Add(newStudent);
                return RedirectToAction("Index");
            }
            _dbData.Students.Add(newStudent);
            return RedirectToAction("Index");
            //return View("Index", _dbData.StudentList);
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student updateStudent)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == updateStudent.Id);
            
            if (student != null)
            {
                student.FirstName = updateStudent.FirstName;
                student.LastName = updateStudent.LastName;  
                student.Email = updateStudent.Email;    
                student.Course = updateStudent.Course;  
                student.AdmissionDate = updateStudent.AdmissionDate;
            }
            return RedirectToAction("Index");
            //return View("Index", _dbData.StudentList);
        }

        public IActionResult DeleteStudent()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == id);

            if (student != null)
                return View(student);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteStudent(Student deleteStudent)
        {
            Student? student = _dbData.Students.FirstOrDefault(st => st.Id == deleteStudent.Id);

            if (student != null)
                _dbData.Students.Remove(student);
            return RedirectToAction("Index");
            //return View("Index", _dbData.StudentList);
        }
    }
} 