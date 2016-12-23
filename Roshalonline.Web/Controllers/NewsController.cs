using AutoMapper;
using PagedList;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using Roshalonline.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roshalonline.Web.Controllers
{
    public class NewsController : Controller
    {
        private IEntry<NewsME> _newsService;

        public NewsController(IEntry<NewsME> newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            IList<NewsME> items = _newsService.GetItems(n => n.Category == Data.Models.Relevance.Active);
            Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
            var allNews = Mapper.Map<IList<NewsME>, IList<NewsVM>>(items).ToList();
            allNews.Reverse();
            var pageSize = 8;
            var pageNumber = (page ?? 1);

            return View(allNews.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult View(int currId, int step)
        {
            try
            {
                IList<NewsME> items = _newsService.GetItems(n => n.Category == Data.Models.Relevance.Active);
                Mapper.Initialize(cfg => cfg.CreateMap<NewsME, NewsVM>());
                var allNews = Mapper.Map<IList<NewsME>, IList<NewsVM>>(items).ToList();
                allNews.Reverse();
                var currNewsIndex = allNews.IndexOf(allNews.Find(n => n.ID == currId));
                NewsVM itemVM = null;
                if (step == -1)
                {
                    itemVM = allNews[currNewsIndex];
                }

                if (step == 0 & currNewsIndex != 0)
                {
                    itemVM = allNews[currNewsIndex - 1];
                }
                else if (step == 1 & currNewsIndex != allNews.Count - 1)
                {
                    itemVM = allNews[currNewsIndex + 1];
                }
                else if (step < -1 || step > 1)
                {
                    return RedirectToAction("Error", "Home", new { message = "Что-то пошло не так: например кто-то указал неверные параметры для действия" });
                }

                int positionIndex;

                if (allNews.IndexOf(itemVM) == 0)
                {
                    positionIndex = 0;
                }
                else if (allNews.IndexOf(itemVM) == allNews.Count - 1)
                {
                    positionIndex = 1;
                }
                else
                {
                    positionIndex = -1;
                }

                var steppedNews = new Dictionary<int, NewsVM>();
                steppedNews[positionIndex] = itemVM;
                return View(steppedNews);
            }
            catch (Exception exc)
            {
                return RedirectToAction("Error", "Home", new { message = exc.Message });
            }
        }
    }
}