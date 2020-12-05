using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        EduContext db = new EduContext();

        // GET: Admin/Home
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult UpdateProfil(int id)
        {
            Entity.Admin currentAdmin = Session["currentAdmin"] as Entity.Admin;
            id = currentAdmin.ID;
             return View();
        }
        [HttpPost]
        public ActionResult UpdateProfil(Entity.Admin data)
        {
           
            Entity.Admin updAdmin = db.Admins.Find(data.ID);
            updAdmin.ID = data.ID;
            updAdmin.Email = data.Email;
            updAdmin.FirstName = data.FirstName;
            updAdmin.LastName = data.LastName;
            updAdmin.Password = data.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Entity.Admin data)
        {
            Entity.Admin yeni = new Entity.Admin();
            yeni.FirstName = data.FirstName;
            yeni.LastName = data.LastName;
            yeni.Email = data.Email;
            yeni.Password = data.Password;
            db.Admins.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("AdminList");
        }

        public ActionResult AdminList()
        {
            return View();
        }

        public ActionResult AdminDelete(int id)
        {
            Entity.Admin delAdmin = db.Admins.Find(id);
            db.Admins.Remove(delAdmin);
            db.SaveChanges();
            return RedirectToAction("AdminList");
       
        }
             
    }
}