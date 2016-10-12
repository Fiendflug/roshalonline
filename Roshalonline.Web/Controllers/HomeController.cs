using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using Roshalonline.Data.Repository;

namespace Roshalonline.Web.Controllers
{
    public class HomeController : Controller
    {
        private AccessToRepositories _accessToDatabase;

        public HomeController()
        {
            _accessToDatabase = new AccessToRepositories();
        }
        // GET: Home
        public ActionResult Index()
        {
            var news = _accessToDatabase.NewsRepository.GetIAll();
            return View(news);
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
        }
    }
}