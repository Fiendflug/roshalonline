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
        private IEntry<PeriodicTarifME> _PeriodicTarifService;
        private IUser _userService;
        //private IEntry<NoteME> _noteService;    

        public ManagementController(IEntry<NewsME> newsService, IEntry<PeriodicTarifME> internetPeriodicTarifService, IUser userService)
        {
            _newsService = newsService;
            _PeriodicTarifService = internetPeriodicTarifService;
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

        //Media content section

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

        //News section

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
                        newsParam.PathToIcon = "/Assets/Logos/News/View/info_news_128.png";
                        newsParam.PathToCover = "/Assets/Logos/News/Index/info_news.png";
                        break;
                    case BackgroundType.Break:
                        newsParam.PathToIcon = "/Assets/Logos/News/View/take_a_break_128.png";
                        newsParam.PathToCover = "/Assets/Logos/News/Index/break.png";
                        break;
                    case BackgroundType.Sales:
                        newsParam.PathToIcon = "/Assets/Logos/News/View/money_128.png";
                        newsParam.PathToCover = "/Assets/Logos/News/Index/sales.png";
                        break;
                    case BackgroundType.Impotant:
                        newsParam.PathToIcon = "/Assets/Logos/News/View/impotant_news_128.png";
                        newsParam.PathToCover = "/Assets/Logos/News/Index/impotant_news.png";
                        break;
                    case BackgroundType.Holiday:
                        newsParam.PathToIcon = "/Assets/Logos/News/View/holiday_128.png";
                        newsParam.PathToCover = "/Assets/Logos/News/Index/holiday.png";
                        break;
                }
                newsParam.ViewsCount = 0;

                var currUser = _userService.GetUsers(u => u.Name == User.Identity.Name.Split('|')[0]);
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

        // All tarifs action

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult Tarifs()
        {
            return View();
        }
        
        // Periodical tarif section

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult PeriodicTarifs()
        {
            IList<PeriodicTarifME> items = _PeriodicTarifService.GetAllItems();
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarifVM>());
            var allInternetTarifs = Mapper.Map<IList<PeriodicTarifME>, IList<PeriodicTarifVM>>(items);
            return View(allInternetTarifs.ToList());
        }

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult CreatePeriodicTarif()
        {
            return View();
        }

        [HttpPost]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        [ValidateInput(false)]
        public ActionResult CreatePeriodicTarif(PeriodicTarifVM tarifParam)
        {
            try
            {
                var currUser = _userService.GetUsers(u => u.Name == User.Identity.Name.Split('|')[0]);
                tarifParam.AuthorID = currUser.First().ID;
                tarifParam.AuthorName = currUser.First().Name;
                tarifParam.Category = Relevance.Active;    
                Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifVM, PeriodicTarifME>());
                var item = Mapper.Map<PeriodicTarifVM, PeriodicTarifME>(tarifParam);
                _PeriodicTarifService.Create(item);
                return RedirectToAction("Index");
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View(tarifParam);
        }

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult ViewPeriodicTarif(int? id)
        {
            try
            {
                var item = _PeriodicTarifService.GetItem(id);
                Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarifVM>());
                var itemVM = Mapper.Map<PeriodicTarifME, PeriodicTarifVM>(item);
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
        public ActionResult EditPeriodicTarif(PeriodicTarifVM itemParam)
        {
            var currUser = _userService.GetUsers(u => u.Name == User.Identity.Name);
            itemParam.AuthorID = currUser.First().ID;
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifVM, PeriodicTarifME>());
            var item = Mapper.Map<PeriodicTarifVM, PeriodicTarifME>(itemParam);
            _PeriodicTarifService.Edit(item);
            return RedirectToAction("PeriodicTarifs");
        }

        [HttpGet]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult DeletePeriodicTarif(int? id)
        {
            try
            {
                var item = _PeriodicTarifService.GetItem(id);
                Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarifVM>());
                var itemVM = Mapper.Map<PeriodicTarifME, PeriodicTarifVM>(item);
                return View(itemVM);
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }

        [HttpPost, ActionName("DeletePeriodicTarif")]
        [AuthenticationAdminFilter]
        [AuthorizationAdminFilter]
        public ActionResult ConfirmDeletePeriodicTarif(PeriodicTarifVM itemParam)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifVM, PeriodicTarifME>());
                var item = Mapper.Map<PeriodicTarifVM, PeriodicTarifME>(itemParam);
                _newsService.Delete(item.ID);
                return RedirectToAction("PeriodicTarifs");
            }
            catch (ValidationException exc)
            {
                ModelState.AddModelError(exc.Property, exc.Message);
            }
            return View();
        }

        // User section

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