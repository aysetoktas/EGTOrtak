using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace UI.Areas.Admin.Controllers
{
    public class LessonController : Controller
    {
        EduContext db = new EduContext();

        // GET: Admin/Lesson
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).ToList();
            return View(lessons);
        }
        public ActionResult Index2(Category cat)
        {
            List<Lesson> lessons = db.Lessons.Where(x => cat.ID == cat.ID).ToList();
            return View();
        }
        public ActionResult Index3(Category cat)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.CategoryID == cat.ID).ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Lesson data, HttpPostedFileBase Image, HttpPostedFileBase Pdf)
        {
            Lesson yeni = new Lesson();
            data.Logo = ImageUploader.UploadSingleImage("/Uploads/", Image);
            data.Content = PdfUploader.UploadPdf("UploadContent", Pdf);
            yeni.UnitID = data.UnitID;
            yeni.EducationID = data.EducationID;
            yeni.CategoryID = data.CategoryID;
            yeni.Name = data.Name;
            yeni.Logo = data.Logo;
            yeni.StartDate = data.StartDate;
            yeni.EndDate = data.EndDate;
            yeni.Path = data.Path;
       
            yeni.TeacherID = data.TeacherID;
            db.Lessons.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Lesson updLesson = db.Lessons.Find(id);
            return View(updLesson);
        }
        [HttpPost]
        public ActionResult Update(Lesson data, HttpPostedFileBase Image, HttpPostedFileBase Pdf)
        {
            data.Logo = ImageUploader.UploadSingleImage("/Uploads/", Image);
            data.Content = PdfUploader.UploadPdf("/UploadContent/", Pdf);

            Lesson updLesson = db.Lessons.Find(data.ID);
            if (data.Logo != "0" || data.Logo != "1" || data.Logo != "2")
            {
                updLesson.Logo = data.Logo;
            }

            updLesson.Name = data.Name;
            updLesson.TeacherID = data.TeacherID;
            updLesson.EducationID = data.EducationID;
            updLesson.StartDate = data.StartDate;
            updLesson.EndDate = data.EndDate;
            updLesson.Path = data.Path;
            updLesson.Content = data.Content;

            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult Delete(int id)
        {
            Lesson delLesson = db.Lessons.Find(id);
            db.Lessons.Remove(delLesson);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        public JsonResult GetUnitsByEducationId(int id)
        {
            Education education = db.Educations.Find(id);
            var jsonData = from u in education.Units
                           select new
                           {
                               ID = u.ID,
                               Name = u.Name
                           };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}