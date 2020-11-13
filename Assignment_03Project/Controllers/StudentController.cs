using Assignment_03Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_03Project.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //Get:/Student/List
        //Acquire information about the Students and send it to the List.cshtml
        public ActionResult List()
        {
            //We will get the information from ListStudents method
            StudentDataController controller = new StudentDataController();
            IEnumerable<student> StudentInfo = controller.ListStudents();
            return View(StudentInfo);
        }
        //Get:Student/Show
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            student NewStudent = controller.FindStudent(id);
            return View(NewStudent);
            
        }
    }
}