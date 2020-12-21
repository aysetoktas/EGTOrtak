using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Member.Controllers
{
    public class EducationController : Controller
    {
        EduContext db = new EduContext();
        // GET: Member/Education
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }
        public ActionResult List(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.CategoryID).ToList();
            return View(lessons);
        }
        public ActionResult List1(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.CategoryID == id).ToList();
            return View(lessons);
        }
        public ActionResult LessonList(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x=>x.EducationID).ToList();
            return View(lessons);
        }
    }
}