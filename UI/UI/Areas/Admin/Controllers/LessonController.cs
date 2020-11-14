using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Lesson data)
        {
            Lesson yeni = new Lesson(); 
            yeni.EducationID = data.EducationID;
            yeni.Name = data.Name;
            yeni.StartDate = data.StartDate;
            yeni.EndDate = data.EndDate;
            yeni.ProjectLink = data.ProjectLink;
            yeni.DocumentLink = data.DocumentLink;
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
        public ActionResult Update(Lesson data)
        {
            Lesson updLesson = db.Lessons.Find(data.ID);
            updLesson.Name = data.Name;
            updLesson.TeacherID = data.TeacherID;
            updLesson.EducationID = data.EducationID;
            updLesson.StartDate = data.StartDate;
            updLesson.EndDate = data.EndDate;
            updLesson.Content = data.Content;
            updLesson.Logo = data.Logo;
            updLesson.Path = data.Path;
            updLesson.ProjectLink = data.ProjectLink;
            updLesson.DocumentLink = data.DocumentLink;

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
    }
}