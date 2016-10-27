using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roshalonline.Logic.Services;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using AutoMapper;
using Roshalonline.Web.Models;
using Roshalonline.Logic.Infrastructure;
using Roshalonline.Data.Models;
using Roshalonline.Data.Context;
using Roshalonline.Data.Repositories;

namespace Roshalonline.Web.Controllers
{
    public class ManagementController : Controller
    {
        private IEntry<NewsME> _newsService;
        //private IEntry<NoteME> _noteService;    
        
        public ManagementController(IEntry<NewsME> newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult News()
        {
            IList<NewsME> items = _newsService.GetAllItems();
            Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
            var allNews = Mapper.Map<IList<NewsME>, IList<NewsVM>>(items);
            return View(allNews.ToList());
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNews(NewsVM newsParam)
        {
            try
            {                
                newsParam.CreateDate = DateTime.Now;
                newsParam.Category = Relevance.Active;
                newsParam.ViewsCount = 0;
                var test = new DatabaseWorker(); //TEST
                newsParam.Author = test.Users.GetItem(1);   //TEST

                Mapper.Initialize(cfg => cfg.CreateMap<NewsVM, NewsME>());
                var item = Mapper.Map<NewsVM, NewsME>(newsParam);
                _newsService.Create(item);
                return RedirectToAction("News");
            }
            catch(ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View(newsParam);
        }
    }
}