using ASP.net_MVC_3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Helpers;
using System.Data.Entity;
using System.Security.Policy;
using System.Web.UI;
using System.Xml.Linq;

namespace ASP.net_MVC_3.Controllers
{
    public class StudentsController : Controller
    {
        #region Connection
        db_WebTestEntities1 db = new db_WebTestEntities1();
        #endregion

        #region Index
        public ActionResult Index()
        {
            var students = db.T_Students;
            return View(students);
        }
        #endregion

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name , Family , NationalCode , Age , Phone , Password , Email , Gender , Image")] T_Students students, HttpPostedFileBase Image, string repassword)
        {
            if (ModelState.IsValid)
            {
                if (students.Password != repassword)
                {
                    ModelState.AddModelError("Password", "رمز عبور با تکرار آن مطابقت ندارد");
                    return View(students);
                }

                string newImage = "user.jpg";
                if (Image != null)
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
                    newImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Image.FileName);
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
        #endregion

        #region Details
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
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Family, Age, Phone, Email, RegisterDate, IsActive, Gender, Image, Password, NationalCode")] T_Students students, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    if (imageUpload.ContentType != "image/jpeg" && imageUpload.ContentType != "image/png" && imageUpload.ContentType != "image/jpg")
                    {
                        ModelState.AddModelError("Image", "تصویر شما باید با فرمت jpeg  یا png یا jpg باشد!");
                        return View(students);
                    }
                    if (imageUpload.ContentLength > 300000)
                    {
                        ModelState.AddModelError("Image", "حجم تصویر شما نباید بیشتر از 300 کیلوبایت باشد!");
                        return View(students);
                    }
                    string newImage = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imageUpload.FileName);
                    imageUpload.SaveAs(Server.MapPath("/Image/ProfileName/" + newImage));
                    students.Image = newImage;
                }
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(int? id)
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

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int? id)
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
            if (student != null) 
            {
                db.T_Students.Remove(student);
                db.SaveChanges();
                if (student.Image != "user")
                {
                    if (System.IO.File.Exists(Server.MapPath("/Image/ProfileName/") + student.Image))
                    {
                        System.IO.File.Delete(Server.MapPath("/Image/ProfileName/") + student.Image);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        } 
        #endregion
    }
}