using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Cteacher.Controllers
{
    public class HomeController : Controller
    {
        EduContext db = new EduContext();
        // GET: Cteacher/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profil()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProfil(Entity.Teacher teacher)
        {
            Entity.Teacher currentTeacher = db.Teachers.Find(teacher.ID);
            currentTeacher.FirstName = teacher.FirstName;
            currentTeacher.LastName = teacher.LastName;
            currentTeacher.Email = teacher.Email;
            currentTeacher.Password = teacher.Password;
            currentTeacher.Phone = teacher.Phone;
            currentTeacher.Address = teacher.Address;
            currentTeacher.Note = teacher.Note;
            db.SaveChanges();
            Session["currentTeacher"] = null;
            Session["currentTeacher"] = currentTeacher;
            return RedirectToAction("Profil","Home");
        }

        public ActionResult Ders(int? id)
        {
            Lesson lesson = db.Lessons.Find(id);
            return View(lesson);
        }

        public ActionResult EducationList(int? id)
        {
            Teacher currentTeacher = Session["currentTeacher"] as Teacher;
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).ToList();
            return View(lessons);
        }

    }
}