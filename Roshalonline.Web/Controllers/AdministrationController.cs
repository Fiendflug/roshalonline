using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roshalonline.Web.Controllers
{
    public class AdministrationController : Controller
    {
        DatabaseContext database = new DatabaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News()
        {
            
            return View(database.AllNews.ToList());
        }

        [HttpPost]
        public ActionResult CreateNews(News newsParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    database.AllNews.Add(newsParam);
                    database.SaveChanges();
                    return RedirectToAction("News");
                }
            }
            catch
            {

            }
            return View(newsParam);
        }

        public ActionResult ViewNews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(502); 
            }
            var news = database.AllNews.Find(id);
            return View(news);
        }
    }
}