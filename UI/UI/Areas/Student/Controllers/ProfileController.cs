using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;

namespace UI.Areas.Student.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Student/Profile
        EduContext db = new EduContext();

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAccount(Entity.Student student)
        {
            
            Entity.Student currentUsers = db.Students.Find(student.ID);
            currentUsers.FirstName = student.FirstName;
            currentUsers.LastName = student.LastName;
            currentUsers.School = student.School;
            currentUsers.PhoneNumber = student.PhoneNumber;
            currentUsers.Email = student.Email;
            db.SaveChanges();
            Session["CurrentUser"] = null;
            Session["currentUser"] = currentUsers;
            return RedirectToAction("Index", "Home");
        }
    }
}