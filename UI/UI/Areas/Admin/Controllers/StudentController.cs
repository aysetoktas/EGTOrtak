using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        EduContext db = new EduContext();
        // GET: Admin/Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Entity.Student data)
        {
            db.Students.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Entity.Student updStudent = db.Students.Find(id);
            return View(updStudent);
        }
        [HttpPost]
        public ActionResult Update(Entity.Student data)
        {
            Entity.Student updStudent = db.Students.Find(data.ID);
            updStudent.FirstName = data.FirstName;
            updStudent.LastName = data.LastName;
            updStudent.Email = data.Email;
            updStudent.Password = data.Password;
            updStudent.PhoneNumber = data.PhoneNumber;
            updStudent.School = data.School;
            updStudent.Grade = data.Grade;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Entity.Student delStudent = db.Students.Find(id);
            db.Students.Remove(delStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}