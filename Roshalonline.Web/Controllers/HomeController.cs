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
                    NotePathToPhotos = new List<string>()
                    {
                        "none","none"
                    },
                    NoteBody = "blablabalballablab",
                    NoteViewsCount = 0
                });
                roshalDBContext.SaveChanges();
            } 
            return View();
        }
    }
}