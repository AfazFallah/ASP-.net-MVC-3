using ASP.net_MVC_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.net_MVC_3.Controllers
{
    public class StudentsController : Controller
    {
        db_WebTestEntities db = new db_WebTestEntities();
        public ActionResult Index()
        {
           var students = db.T_Students;
            return View(students);
        }
    }
}