using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Member.Controllers
{
    public class TeacherController : Controller
    {
        EduContext db = new EduContext();
        // GET: Member/Teacher
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.TeacherID==id).OrderBy(x=>x.TeacherID).ToList();
            return View(lessons);
        }
    }
}