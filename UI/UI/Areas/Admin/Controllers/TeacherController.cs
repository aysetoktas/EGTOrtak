using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace UI.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        EduContext db = new EduContext();
        // GET: Admin/Teacher
     
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
        public ActionResult Add(Teacher data, HttpPostedFileBase Image)
        {
            Teacher yeni = new Teacher();
            yeni.Detail = ImageUploader.UploadSingleImage("/Uploads/", Image);

            yeni.FirstName = data.FirstName;
            yeni.LastName = data.LastName;
            yeni.Email = data.Email;
            yeni.Password = data.Password;
            yeni.Phone = data.Phone;
            yeni.Address = data.Address;      
            yeni.Note = data.Note;

            db.Teachers.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Teacher updTeacher = db.Teachers.Find(id);
            return View(updTeacher);
        }
        [HttpPost]
        public ActionResult Update(Teacher data, HttpPostedFileBase Image)
        {
            data.Detail = ImageUploader.UploadSingleImage("/Uploads/", Image);

            Teacher updTeacher = db.Teachers.Find(data.ID);
            updTeacher.Detail = data.Detail;
            updTeacher.FirstName = data.FirstName;
            updTeacher.LastName = data.LastName;
            updTeacher.Email = data.Email;
            updTeacher.Password = data.Password;
            updTeacher.Phone = data.Phone;
            updTeacher.Address = data.Address;
            updTeacher.Note = data.Note;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Teacher delTeacher = db.Teachers.Find(id);
            db.Teachers.Remove(delTeacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}