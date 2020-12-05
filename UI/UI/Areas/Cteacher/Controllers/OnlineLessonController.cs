using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace UI.Areas.Cteacher.Controllers
{
    public class OnlineLessonController : Controller
    {
        // GET: Cteacher/OnlineLesson

        EduContext db = new EduContext();
        // GET: Cteacher/Lesson
        public ActionResult List(Category cat)
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
        public ActionResult Add(Lesson data, string[] students)
        {
            Teacher currentTeacher = Session["currentTeacher"] as Teacher;
            Lesson yeni = new Lesson();
            yeni.Students = new List<Entity.Student>();
            yeni.EducationID = data.EducationID;
            yeni.CategoryID = data.CategoryID;
            yeni.Name = data.Name;
            yeni.Logo = data.Logo;
            yeni.StartDate = data.StartDate;
            yeni.EndDate = data.EndDate;
            yeni.Path = data.Path;
            yeni.IsLive = true;
            yeni.TeacherID = currentTeacher.ID;
            foreach (string id in students)
            {
                int stdId = Convert.ToInt32(id);
                Entity.Student tmpStudent = db.Students.Where(x => x.ID == stdId).SingleOrDefault();
                yeni.Students.Add(tmpStudent);
            }
            db.Lessons.Add(yeni);
            db.SaveChanges();
            foreach (string id in students)
            {
                int stdId = Convert.ToInt32(id);
                Entity.Student tmpStudent = db.Students.Where(x => x.ID == stdId).SingleOrDefault();
                tmpStudent.Lessons.Add(yeni);
            }
            db.SaveChanges();
            return RedirectToAction("List3", "Lesson", new { area = "Cteacher" });
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
            updLesson.CategoryID = data.CategoryID;
            updLesson.Path = data.Path;
            updLesson.IsLive = true;

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