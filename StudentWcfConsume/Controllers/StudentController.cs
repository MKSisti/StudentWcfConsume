using StudentWcfConsume.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWcfConsume.Controllers
{
    public class StudentController : Controller
    {
        Service1Client sc = new Service1Client();
        public ActionResult GetStudents()
        {
            ViewBag.List = sc.GetAllStudents().ToList<Student>();
            return View("GetStudents");
        }
        public ActionResult GetStudent(string cin)
        {
            ViewBag.st = sc.GetStudent(cin);
            return View();
        }
        public ActionResult CreateStudent( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStudent(Student st)
        {
            sc.CreateStudent(st);
            return GetStudents();
        }
        public ActionResult UpdateStudent(string cin)
        {
            if (!(cin is null)) ViewBag.st = sc.GetStudent(cin);
            else ViewBag.st = new { cin = "na" };
            return View();
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student st)
        {
            sc.UpdateStudent(st);
            return GetStudents();
        }

        public ActionResult DeleteStudent(string cin)
        {
            sc.DeleteStudent(cin);
            return GetStudents();
        }
    }
}