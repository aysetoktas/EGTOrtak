using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Utility;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        EduContext db = new EduContext();
        // GET: Account

        public ActionResult First()
        {
			
            return RedirectToAction("Index", "Home", new { area = "Member" });
        }
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
                Student currentStudent = db.Students.Where(x => x.FirstName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Teacher currentTeacher = db.Teachers.Where(x => x.FirstName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Admin currentAdmin = db.Admins.Where(x => x.FirstName == data.UserName && x.Password == data.Password).FirstOrDefault();

                if (currentStudent != null || currentTeacher != null || currentAdmin != null)
                {
                    if (currentStudent != null)
                    {
                        Session["currentUsers"] = currentStudent;
                        return RedirectToAction("Index", "Home", new { area = "Member" });
                    }
                    else if (currentAdmin != null)
                    {
                        Session["currentAdmin"] = currentAdmin;
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (currentTeacher != null)
                    {
                        Session["currentTeacher"] = currentTeacher;
                        return RedirectToAction("Index", "Home", new { area = "Cteacher" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Cteacher" });
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
        public ActionResult Register(Student newUser)
        {
            //newUser.Role = Role.Member;
            db.Students.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Login", "Account");

        }
        [HttpGet]
        public ActionResult RegisterTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterTeacher(Teacher newUser, HttpPostedFileBase Image)
        {
            Teacher yeni = new Teacher();
            newUser.Detail= ImageUploader.UploadSingleImage("/Uploads/", Image);

            yeni.FirstName = newUser.FirstName;
            yeni.LastName = newUser.LastName;
            yeni.Email = newUser.Email;
            yeni.Password = newUser.Password;
            yeni.Phone = newUser.Detail;
            yeni.Address = newUser.Address;
            yeni.Detail = newUser.Detail;
            
            db.Teachers.Add(newUser);
            db.SaveChanges();
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