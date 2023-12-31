﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using DyITELEC1C.Models;
using System.Reflection.Metadata.Ecma335;
using DyITELEC1C.Services;
using DyITELEC1C.Data;
using Microsoft.AspNetCore.Authorization;

namespace DyITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbData;
        private readonly IWebHostEnvironment _environment;
        public InstructorController(AppDbContext dbData, IWebHostEnvironment environment)
        {
            _dbData = dbData;
            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View (_dbData.Instructors);
        }
        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(qe => qe.Id == id);

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
            if (!ModelState.IsValid)
            {
                return View();
            }
            string folder = "instructor/images/";
            string serverFolder = Path.Combine(_environment.WebRootPath, folder);
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + newInstructor.UploadedPhoto.FileName;
            string filePath = Path.Combine(serverFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        newInstructor.UploadedPhoto.CopyTo(fileStream);
                    }
                    newInstructor.imagePath = folder + uniqueFileName;
                _dbData.Instructors.Add(newInstructor);
                _dbData.SaveChanges();
                return RedirectToAction("Index");
            }

        [HttpGet]
        
        public IActionResult UpdateInstructor(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        
        public IActionResult UpdateInstructor(Instructor UpdateInstructor)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == UpdateInstructor.Id);

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
            //return View("Index", _dbData.InstructorList);
        }
        public IActionResult DeleteInstructor()
        {
            return View();
        }


        [HttpGet]

        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == id);

            if (instructor != null)
                return View(instructor);

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(Student deleteInstructor)
        {
            Instructor? instructor = _dbData.Instructors.FirstOrDefault(st => st.Id == deleteInstructor.Id);

            if (instructor != null)
                _dbData.Instructors.Remove(instructor);
            return RedirectToAction("Index");
            //return View("Index", _dbData.InstructorList);
        }
    }
}
