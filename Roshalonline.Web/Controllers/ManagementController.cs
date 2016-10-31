using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using AutoMapper;
using Roshalonline.Web.Models;
using Roshalonline.Logic.Infrastructure;
using Roshalonline.Data.Models;
using Roshalonline.Data.Repositories;

namespace Roshalonline.Web.Controllers
{
    public class ManagementController : Controller
    {
        private IEntry<NewsME> _newsService;
        private IUser _userService;
        //private IEntry<NoteME> _noteService;    
        
        public ManagementController(IEntry<NewsME> newsService, IUser userService)
        {
            _newsService = newsService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }     
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginVM userParam)
        {            
            var user = _userService.Login(userParam.Login, userParam.Password);
            if (user.Name != "Failed")
            {
                FormsAuthentication.SetAuthCookie(userParam.Login, true);                
            }
            return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult ViewNews(int? id)
        {
            try
            {
                var item = _newsService.GetItem(id);
                Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
                var itemVM = Mapper.Map<NewsME, NewsVM>(item);
                return View(itemVM);
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditNews(int? id)
        {
            try
            {
                var item = _newsService.GetItem(id);
                Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
                var itemVM = Mapper.Map<NewsME, NewsVM>(item);
                return View(itemVM);
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditNews(NewsVM itemParam)
        {
            itemParam.CreateDate = DateTime.Now;
            var test = new DatabaseWorker(); //TEST
            itemParam.Author = test.Users.GetItem(1);   //TEST

            Mapper.Initialize(cfg => cfg.CreateMap<NewsVM, NewsME>());
            var item = Mapper.Map<NewsVM, NewsME>(itemParam);
            _newsService.Edit(item);
            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult DeleteNews(int? id)
        {
            try
            {
                var item = _newsService.GetItem(id);
                Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
                var itemVM = Mapper.Map<NewsME, NewsVM>(item);
                return View(itemVM);
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }

        [HttpPost, ActionName("DeleteNews")]
        public ActionResult ConfirmDeleteNews(NewsVM itemParam)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<NewsVM, NewsME>());
                var item = Mapper.Map<NewsVM, NewsME>(itemParam);
                _newsService.Delete(item.ID);
                return RedirectToAction("News");
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }
    }
}