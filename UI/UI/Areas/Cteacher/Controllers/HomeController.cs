using Entity;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet]
        public ActionResult UpdateProfil(int id)
        {
            Entity.Teacher currentTeacher = Session["currentTeacher"] as Entity.Teacher;
            id = currentTeacher.ID;
            return View();
        }
        [HttpPost]
        public ActionResult UpdateProfil(Entity.Teacher teacher)
        {
            Entity.Teacher updTeacher = db.Teachers.Find(teacher.ID);
            updTeacher.ID = teacher.ID;
            updTeacher.FirstName = teacher.FirstName;
            updTeacher.LastName = teacher.LastName;
            updTeacher.Email = teacher.Email;
            updTeacher.Password = teacher.Password;
            updTeacher.Phone = teacher.Phone;
            updTeacher.Address = teacher.Address;
            updTeacher.Note = teacher.Note;
            db.SaveChanges();
            return RedirectToAction("Index");
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