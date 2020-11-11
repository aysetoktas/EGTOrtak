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
                User currentUser = db.Users.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
                if (currentUser != null)
                {
                    if (currentUser.Role == Role.Admin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (currentUser.Role == Role.Member)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                    else if (currentUser.Role == Role.Teacher)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Register");
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
            return RedirectToAction("Login", "Account");

        }
        //[HttpGet]
        //public ActionResult RegisterTeacher()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult RegisterTeacher(User newUser)
        //{
        //    newUser.Role = Role.Teacher;
        //    db.Users.Add(newUser);
        //    return RedirectToAction("Login", "Account");
        //}

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Member" });
        }

    }
}