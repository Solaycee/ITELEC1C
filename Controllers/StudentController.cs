using Microsoft.AspNetCore.Mvc;
using DyITELEC1C.Models;

namespace DyITELEC1C.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            Student st = new Student();
            st.StudentID = 1;
            st.StudentName = "Ryan Christopher Dy";
            st.DateEnrolled = DateTime.Parse("30/8/2023");
            st.Course = Course.BSIT;
            st.Email = "ryanchristopher.dy.cics@ust.edu.ph";

            ViewBag.student = st;
            return View();
        }

    }
}
