using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roshalonline.Data.Context;
using Roshalonline.Data.Models;

namespace Roshalonline.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            /*
            using (ModelsContext roshalDBContext = new ModelsContext())
            {
                roshalDBContext.AllNews.Add(new News
                {
                    NewsID = 0,
                    NewsHeader = "First news",
                    NewsAuthor = "Admin",
                    NewsCreateDate = DateTime.Now,
                    NewsPathToIcon = "None",
                    NewsViewsCount = 0,
                    NewsBody = "blablbalbalblalbalblabl"
                });
                roshalDBContext.Notes.Add(new Note
                {
                    NoteID = 0,
                    NoteHeader = "First note",
                    NoteCategory = "Construction note",
                    NoteCreateDate = DateTime.Now,
                    NotePathToIcon = "none",
                    NotePathToPhotos = "123121",
                    NoteBody = "blablabalballablab",
                    NoteViewsCount = 0
                });
                roshalDBContext.SaveChanges();
            }
            
            using (ModelsContext db = new ModelsContext())
            {
                NewsCategory breakingNews = new NewsCategory
                {
                    NewsCategoryID = 1,
                    NewsCategoryName = "Breaking"
                };
                NewsCategory dailyNews = new NewsCategory
                {
                    NewsCategoryID = 2,
                    NewsCategoryName = "Daily"
                };
                db.SaveChanges();
                News n = new News
                {
                    NewsID = 1,
                    NewsAuthor = "Admin",
                    NewsCategory = breakingNews,
                    NewsCreateDate = DateTime.Now,
                    NewsHeader = "Extra",
                    NewsPathToIcon = "none",
                    NewsBody = "babalbalblaalbalbl",
                    NewsViewsCount = 0
                };
                News n2 = new News
                {
                    NewsID = 1,
                    NewsAuthor = "Admin",
                    NewsCategory = dailyNews,
                    NewsCreateDate = DateTime.Now,
                    NewsHeader = "Daily",
                    NewsPathToIcon = "none",
                    NewsBody = "ddddddddddd",
                    NewsViewsCount = 0
                };
                db.AllNews.AddRange(new List<News> {
                    n, n2
                });
                db.SaveChanges();
            }
            */
            using (ModelsContext db = new ModelsContext())
            {
                Dictionary<int, string> d = new Dictionary<int, string>();
                foreach (NewsCategory nC in db.NewsCategories)
                {
                    d[nC.NewsCategoryID] = nC.NewsCategoryName;
                }
                return View(d);
            }
        }
    }
}