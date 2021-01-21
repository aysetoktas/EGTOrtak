using Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

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
        public ActionResult UpdateProfil(Teacher data, HttpPostedFileBase Image)
        {
            Entity.Teacher updTeacher = db.Teachers.Find(data.ID);

            if (Image!=null)
            {
                data.Detail = ImageUploader.UploadSingleImage("/Uploads/", Image);
            }
            else
            {
                data.Detail = updTeacher.Detail;
            }
            updTeacher.Detail = data.Detail;
            updTeacher.FirstName = data.FirstName;
            updTeacher.LastName = data.LastName;
            updTeacher.Email = data.Email;
            updTeacher.Password = data.Password;
            updTeacher.Phone = data.Phone;
            updTeacher.Address = data.Address;
            updTeacher.Note = data.Note;
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