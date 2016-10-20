using Roshalonline.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roshalonline.Data.Models;

namespace Roshalonline.Web.Controllers
{
    public class HomeController : Controller
    {     
        public ActionResult Index()
        {
            DatabaseContext context = new DatabaseContext();            
            return View(context.AllNews.ToList());
        }
    }
}