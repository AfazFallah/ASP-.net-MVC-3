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
        db_WebTestEntities1 db = new db_WebTestEntities1();
        public ActionResult Index()
        {
           var students = db.T_Students;
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name , Family , NationalCode , Age , Phone , Password , Email , Gender , Image")]T_Students students)
        {
         if (ModelState.IsValid)
            {
                students.IsActive = true;
                students.RegisterDate = DateTime.Now;
                db.T_Students.Add(students);
                db.SaveChanges();
                return Redirect("Index");
            }
         else { return View(); }
        }

    }
}