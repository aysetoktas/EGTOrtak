using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UI.Areas.Admin.Controllers
{
    public class EducationController : Controller
    {
        EduContext db = new EduContext();
        
        // GET: Admin/Education
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Education data,HttpPostedFileBase Image)
        {
            Education yeni = new Education();
         
            //yeni.Categories = data.Categories;
            yeni.Name = data.Name;
            yeni.Note = data.Note;
            yeni.ImagePath = data.ImagePath;
            yeni.Hour = data.Hour;
            yeni.StartDate = data.StartDate;
            yeni.EndDate = data.EndDate;
            yeni.Certificate = data.Certificate;

            db.Educations.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            Education updEducation = db.Educations.Find(id);
            return View(updEducation);
        }
        [HttpPost]
        public ActionResult Update(Education data)
        {
            Education updEducation = db.Educations.Find(data.ID);
            updEducation.Name = data.Name;
            updEducation.Note = data.Note;
            updEducation.Hour = data.Hour;
            updEducation.StartDate = data.StartDate;
            updEducation.EndDate = data.EndDate;
            updEducation.Certificate = data.Certificate;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Education delEducation = db.Educations.Find(id);
            db.Educations.Remove(delEducation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}