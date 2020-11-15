﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;

namespace UI.Areas.Student.Controllers
{
    public class EducationController : Controller
    {
        EduContext db = new EduContext();

        // GET: Student/Education
        public ActionResult Index(int? id)
        {
            Entity.Student currentUsers = Session["currentUsers"] as Entity.Student;
            List<Lesson> lessons = currentUsers.Lessons.Where(x => x.EducationID == id).ToList();
            return View(lessons);
        }
    }
}