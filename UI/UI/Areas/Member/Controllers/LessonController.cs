using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Member.Controllers
{
    public class LessonController : Controller
    {
        EduContext db = new EduContext();
        // GET: Member/Lesson
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }
    }
}