using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace UI.Areas.Cteacher.Controllers
{
    public class LessonController : Controller
    {
        EduContext db = new EduContext();
        // GET: Cteacher/Lesson
        public ActionResult List(int? id)
        {
            Teacher currentTeacher = Session["currentTeacher"] as Teacher;
            List<Lesson> lessons= db.Lessons.Where(x => x.EducationID== id).ToList();
            return View(lessons);
        }

        public ActionResult List2(int? id)
        {
            Teacher currentTeacher = Session["currentTeacher"] as Teacher;
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).ToList();
            return View(lessons);
        }
        public ActionResult List3()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Lesson data, HttpPostedFileBase Image)
        {
            Lesson yeni = new Lesson();
            data.Logo = ImageUploader.UploadSingleImage("/Uploads/", Image);

            yeni.EducationID = data.EducationID;
            yeni.Name = data.Name;
            yeni.Logo = data.Logo;
            yeni.StartDate = data.StartDate;
            yeni.EndDate = data.EndDate;
            yeni.Path = data.Path;
            yeni.ProjectLink = "0";
            yeni.DocumentLink = data.DocumentLink;
            yeni.TeacherID = data.TeacherID;

            db.Lessons.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Lesson updLesson = db.Lessons.Find(id);
            return View(updLesson);
        }
        [HttpPost]
        public ActionResult Update(Lesson data, HttpPostedFileBase Image)
        {
            data.Logo = ImageUploader.UploadSingleImage("/Uploads/", Image);

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
            updLesson.Content = data.Content;

            updLesson.Path = data.Path;
            updLesson.ProjectLink = "0";
            updLesson.DocumentLink = data.DocumentLink;

            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            Lesson delLesson = db.Lessons.Find(id);
            db.Lessons.Remove(delLesson);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}