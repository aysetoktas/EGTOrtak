using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        EduContext db = new EduContext();
        // GET: Admin/Category
        public ActionResult Index(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View(lessons);
        }
        public ActionResult Index2()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category data)
        {
            Category yeni = new Category();
            yeni.Name = data.Name;
            yeni.Hour = data.Hour;

            db.Categories.Add(yeni);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Category updCategory = db.Categories.Find(id);
            return View(updCategory);
        }
        [HttpPost]
        public ActionResult Update(Category data)
        {
            Category updCategory = db.Categories.Find(data.ID);          
            updCategory.Name = data.Name;
            updCategory.Hour = data.Hour;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Category delCategory = db.Categories.Find(id);
            db.Categories.Remove(delCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}