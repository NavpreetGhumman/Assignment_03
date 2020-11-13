using Assignment_03Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;



namespace Assignment_03Project.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/Index
        public ActionResult Index()
        {
            return View();
        }

        //Get:/Teacher/List
        //Acquire information about the teachers and send it to the List.cshtml
        public ActionResult List()
        {
            //We will get the information from ListTeachers method
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> TeacherInfo = controller.ListTeachers();
            return View(TeacherInfo);
        }
        
        //Get:/Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
        
    }
}