using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
namespace UI.Areas.Student.Controllers
{
    public class LessonController : Controller
    {
        // GET: Student/Lesson
        EduContext db = new EduContext();
        // GET: Lesson
        public ActionResult Index(int? id)
        {
            Lesson lesson = db.Lessons.Find(id);
            return View(lesson);
        }
    }
}