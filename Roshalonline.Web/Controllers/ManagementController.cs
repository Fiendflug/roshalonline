using System;
using System.IO;
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
using Roshalonline.Web.Filters;

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
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult Index()
        {
            return View();
        }

        //Аутентификация

        [HttpGet]
        public ActionResult Login()
        {       
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginVM userParam)
        {            
            var user = _userService.GetUser(userParam.Login, userParam.Password);
            if (user.Name != "Failed" & user.UserRole == UserCategory.Administrator)
            {
                FormsAuthentication.SetAuthCookie(userParam.Login + "|" + user.UserRole.ToString(), true);                               
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Медиа-контент

        [HttpPost]
        public void Upload(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = Path.Combine(Server.MapPath("~/Content/Images"), ImageName);
                upload.SaveAs(path);
            }
        }

        public ActionResult UploadPartial()
        {
            var path = Server.MapPath("~/Content/Images");
            var allImages = Directory.GetFiles(path).Select(i => new ImageVM
            {
                Url = Url.Content("/Content/Images/" + Path.GetFileName(i))
            });
            return View(allImages);
        }

        //Новости

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult News()
        {
            IList<NewsME> items = _newsService.GetAllItems();
            Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
            var allNews = Mapper.Map<IList<NewsME>, IList<NewsVM>>(items);
            return View(allNews.ToList());
        }

        //[HttpGet]
        //public ActionResult FiltredNews(int filter)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (filter != 1 && filter != 2)
        //        {
        //            return View("Index"); //Добавить редирект на страницу ошибки
        //        }
        //        IList<NewsME> items = null;
        //        switch (filter)
        //        {
        //            case 1:
        //                items = _newsService.GetItems(u => u.Category == Relevance.Active);
        //                break;
        //            case 2:
        //                items = _newsService.GetItems(u => u.Category == Relevance.Archive);
        //                break;
        //            default:
        //                break;
        //        }
        //        Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
        //        var filtredItems = Mapper.Map<IList<NewsME>, IList<NewsVM>>(items);
        //        return View("News", filtredItems.ToList());
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        [ValidateInput(false)]
        public ActionResult CreateNews(NewsVM newsParam)
        {
            try
            {
                newsParam.CreateDate = DateTime.Now;
                newsParam.Category = Relevance.Active;
                switch (newsParam.Type)
                {
                    case BackgroundType.Info:
                        newsParam.PathToIcon = "/Assets/Logos/Home/ViewNews/info_news_128.png";
                        newsParam.PathToCover = "/Assets/Logos/Home/News/info_news.png";
                        break;
                    case BackgroundType.Break:
                        newsParam.PathToIcon = "/Assets/Logos/Home/ViewNews/take_a_break_128.png";
                        newsParam.PathToCover = "/Assets/Logos/Home/News/break.png";
                        break;
                    case BackgroundType.Sales:
                        newsParam.PathToIcon = "/Assets/Logos/Home/ViewNews/money_128.png";
                        newsParam.PathToCover = "/Assets/Logos/Home/News/sales.png";
                        break;
                    case BackgroundType.Impotant:
                        newsParam.PathToIcon = "/Assets/Logos/Home/ViewNews/impotant_news_128.png";
                        newsParam.PathToCover = "/Assets/Logos/Home/News/impotant_news.png";
                        break;
                    case BackgroundType.Holiday:
                        newsParam.PathToIcon = "/Assets/Logos/Home/ViewNews/holiday_128.png";
                        newsParam.PathToCover = "/Assets/Logos/Home/News/holiday.png";
                        break;
                }
                newsParam.ViewsCount = 0;

                var currUser = _userService.GetUsers(u => u.Name == User.Identity.Name);
                newsParam.AuthorID = currUser.First().ID;
                newsParam.AuthorName = currUser.First().Name;

                Mapper.Initialize(cfg => cfg.CreateMap<NewsVM, NewsME>());
                var item = Mapper.Map<NewsVM, NewsME>(newsParam);
                _newsService.Create(item);
                return RedirectToAction("News");
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View(newsParam);
        }

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
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
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
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
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult EditNews(NewsVM itemParam)
        {
            itemParam.CreateDate = DateTime.Now;
            var currUser = _userService.GetUsers(u => u.Name == User.Identity.Name);
            itemParam.AuthorID = currUser.First().ID;
            //var test = new DatabaseWorker(); //TEST
            //itemParam.Author = test.Users.GetItem(1);   //TEST

            Mapper.Initialize(cfg => cfg.CreateMap<NewsVM, NewsME>());
            var item = Mapper.Map<NewsVM, NewsME>(itemParam);
            _newsService.Edit(item);
            return RedirectToAction("News");
        }

        [HttpGet]       
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
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
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
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

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult Users()
        {
            var items = _userService.GetAllUsers();
            Mapper.Initialize(cfg => cfg.CreateMap<UserME, UserLoginVM>());
            var allUsers = Mapper.Map<IList<UserME>, IList<UserLoginVM>>(items);
            return View(allUsers.ToList());
        }

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [AuthenticationAdminFilter]
        [ValidateAntiForgeryToken]
        [AuthorizationAdminFilter]
        public ActionResult AddUser(UserAddVM userParam)
        {
            var user = _userService.GetUsers(u => u.Name == userParam.Name && u.Login == userParam.Login && u.Password == userParam.Password).FirstOrDefault();
            if (user == null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<UserAddVM, UserME>());
                _userService.Create(Mapper.Map<UserAddVM, UserME>(userParam));
                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("Users");
            }      
        }
    }
}