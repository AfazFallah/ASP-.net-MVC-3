using ASP.net_MVC_3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

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
        public ActionResult Create([Bind(Include = "Name , Family , NationalCode , Age , Phone , Password , Email , Gender , Image")]T_Students students , HttpPostedFileBase Image)
        {
         if (ModelState.IsValid)
            {
                string newImage = "user.jpg";

                if (Image!=null)
                {
                    if (Image.ContentType != "image/jpeg" && Image.ContentType != "image/png" && Image.ContentType != "image/jpg")
                    {
                        ModelState.AddModelError("Image", "تصویر شما باید با فرمت jpeg  یا png یا jpg باشد!");
                        return View();
                    }
                    if (Image.ContentLength > 300000)
                    {
                        ModelState.AddModelError("Image", "حجم تصویر شما نباید بیشتر از 300 کیلوبایت باشد!");
                        return View();
                    }
                    newImage = Guid.NewGuid().ToString().Replace("-","")+Path.GetExtension(Image.FileName);
                    Image.SaveAs(Server.MapPath("/Image/ProfileName/" + newImage));
                }



                students.Image = newImage;
                students.IsActive = true;
                students.RegisterDate = DateTime.Now;
                db.T_Students.Add(students);
                db.SaveChanges();
                return Redirect("Index");
            }
         else { return View(); }
        }
        [HttpGet]
        public ActionResult Details(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var student = db.T_Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

    }
}