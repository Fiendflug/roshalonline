using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roshalonline.Web.Controllers
{
    public class AdministrationController : Controller
    {
        DatabaseContext database = new DatabaseContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            
            return View(database.AllNews.ToList());
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNews(News newsParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    newsParam.CreateDate = DateTime.Now;
                    newsParam.Category = Relevance.Active;
                    newsParam.ViewsCount = 0;
                    newsParam.PathToImages = null;
                    database.AllNews.Add(newsParam);
                    database.SaveChanges();
                    return RedirectToAction("News");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(newsParam);
        }

        [HttpGet]
        public ActionResult EditNews(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var news = database.AllNews.Find(id);
            if (news != null)
            {
                return View(news);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditNews(News newsParam)
        {
            newsParam.CreateDate = DateTime.Now;
            database.Entry(newsParam).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult ViewNews(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var news = database.AllNews.Find(id);
            if (news != null)
            {
                return View(news);
            }
            return HttpNotFound();
        }       
        
        [HttpGet]
        public ActionResult DeleteNews(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var news = database.AllNews.Find(id);
            if (news != null)
            {
                return View(news);
            }
            return HttpNotFound();
        } 
        [HttpPost, ActionName("DeleteNews")]
        public ActionResult ConfirmDeleteNews(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var news = database.AllNews.Find(id);
            if (news != null)
            {
                database.AllNews.Remove(news);
                database.SaveChanges();
                return RedirectToAction("News");
            }
            return HttpNotFound();
        }
    }
}