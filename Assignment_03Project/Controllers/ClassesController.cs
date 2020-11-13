using Assignment_03Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_03Project.Controllers
{
    public class ClassesController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        //Get:/Teacher/List
        //Acquire information about the teachers and send it to the List.cshtml
        public ActionResult Table()
        {
            //We will get the information from ListClasses method
            ClassesDataController controller = new ClassesDataController();
            IEnumerable<Classes> ClassesInfo = controller.ListClasses();
            return View(ClassesInfo);
            
        }
        public ActionResult Show(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            Classes Subject = controller.FindSubject(id);
            return View(Subject);
            
        }
    }
}