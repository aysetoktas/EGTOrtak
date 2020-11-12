using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        EduContext db = new EduContext();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                //User currentUser = db.Users.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Student currentUsers = db.Students.Where(x => x.FirstName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Teacher currentTeacher = db.Teachers.Where(x => x.FirstName == data.UserName && x.Password == data.Password).FirstOrDefault();

                if (currentUsers != null || currentTeacher != null)
                {

                    if (currentUsers != null)
                    {
                        Session["currentUsers"] = currentUsers;
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                    else if (currentTeacher != null)
                    {
                        Session["currentTeacher"] = currentTeacher;
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }

                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User newUser)
        {
            newUser.Role = Role.Member;
            db.Users.Add(newUser);
            //db.SaveChanges();
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public ActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterTeacher(User newUser)
        {
            newUser.Role = Role.Teacher;
            db.Users.Add(newUser);
            //db.SaveChanges();
            return RedirectToAction("Login", "Account");
        }

        //[HttpGet]
        public ActionResult Logout()
        {
            Session["currentUsers"] = null;
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Member" });
        }

    }
}