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

            var users = new List<User>
            {
                new User
                {
                    Login = "Admin",
                    Name = "Admin",
                    Password = "Admin"
                },
                new User
                {
                    Login = "Lena",
                    Name = "Lena",
                    Password = "Lena"
                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var news = new List<News>
            {
                new News
                {
                    Header = "Просто новость",
                    Category = Relevance.Active,
                    PathToIcon = "/images/logo.png",
                    PathToImages = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/galya.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 1,
                    Body = "Это просто новость. Новость о новости. Больше ничего нет.",
                    ViewsCount = 0
                },
                new News
                {
                    Header = "Еще одна новость",
                    Category = Relevance.Active,
                    PathToIcon = "/images/logo.png",
                    PathToImages = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/borodavka.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 2,
                    Body = "Еще одна новость. Так как в Альтесе ничего не происходит. Пусть будет так как есть",
                    ViewsCount = 0
                },
                new News
                {
                    Header = "Удаленная новость",
                    Category = Relevance.Archive,
                    PathToIcon = "/images/deleted.png",
                    PathToImages = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/zapach.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 1,
                    Body = "Эту новость удалили",
                    ViewsCount = 16
                }
            };
            news.ForEach(n => context.AllNews.Add(n));
            context.SaveChanges();

            var notes = new List<Note>
            {
                new Note
                {
                    Header = "Первая статья",
                    Category = Relevance.Active,
                    PathToIcon = "/images/note_main_logo.png",
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/galya.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 1,
                    Body = "В этой статье мы поговрим о ниочем. Спасибо за внимание",
                    ViewsCount = 0
                },
                new Note
                {
                    Header = "Вторая статья. Очень важная",
                    Category = Relevance.Active,
                    PathToIcon = "/images/note_logo.png",
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/galya.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 2,
                    Body = "Эта статья полностью дополняет первую. Важная информации о ничегонеделнье. Не пропустите.",
                    ViewsCount = 0
                },
                new Note
                {
                    Header = "Удаленная статья",
                    Category = Relevance.Archive,
                    PathToIcon = "/images/note_deleted.png",
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage { Path = "/images/small_logo.png" },
                        new PathToImage { Path = "/images/common_logo.png" },
                        new PathToImage { Path = "/images/galya.png" }
                    },
                    CreateDate = DateTime.Now,
                    AuthorID = 1,
                    Body = "Эта статья не прошла модерацию. Увы и ах",
                    ViewsCount = 0
                }
            };
            notes.ForEach(n => context.Notes.Add(n));
            context.SaveChanges();

            var tarifs = new List<Tarif>
            {
                new Tarif
                {
                    Name = "Internet 500",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Internet,
                    AuthorID = 1,
                    Description = "Мега офигенный тариф. Сполщное удовольствие",
                    Price = 500M
                },
                new Tarif
                {
                    Name = "Internet 800",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Internet,
                    AuthorID = 1,
                    Description = "Улетный тариф. Ценник почти не конский",
                    Price = 800M
                },
                new Tarif
                {
                    Name = "Internet 1200",
                    Category = Relevance.Archive,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Internet,
                    AuthorID = 1,
                    Description = "Не пошел тарифчик. Удалили",
                    Price = 1200M
                },
                new Tarif
                {
                    Name = "Corporative Mega-1000",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Corporation,
                    Type = TypeOfTarif.Internet,
                    AuthorID = 1,
                    Description = "Ваше предприятие закроется, если не будет пользоваться этим тарифом",
                    Price = 1000M
                },
                new Tarif
                {
                    Name = "Tepephony 335",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Telephony,
                    AuthorID = 1,
                    Description = "Абонентская плата за безлимитные звонки соседеке напротив",
                    Price = 335M
                },
                new Tarif
                {
                    Name = "Telephony MG - Beeline Mobile",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Telephony,
                    AuthorID = 1,
                    Description = "Код направления - 7903",
                    Price = 1.5M,
                    DiscountPrices = new List<DiscountPricesForTelephonyTarif>
                    {
                        new DiscountPricesForTelephonyTarif { DiscountValue = 1.3M },
                        new DiscountPricesForTelephonyTarif { DiscountValue = 1.1M }
                    }
                },
                new Tarif
                {
                    Name = "Telephony MG - MTC Mobile",
                    Category = Relevance.Active,
                    Audience = TargetAudience.Individual,
                    Type = TypeOfTarif.Telephony,
                    AuthorID = 1,
                    Description = "Код направления - 7916",
                    Price = 1.6M,
                    DiscountPrices = new List<DiscountPricesForTelephonyTarif>
                    {
                        new DiscountPricesForTelephonyTarif { DiscountValue = 1.4M},
                        new DiscountPricesForTelephonyTarif { DiscountValue = 1.22M }
                    }
                },
                new Tarif
                {
                    Name = "Архивный 333",
                    Category = Relevance.Archive,
                    Audience = TargetAudience.Corporation,
                    Type = TypeOfTarif.Telephony,
                    AuthorID = 1,
                    Description = "Не зашел тарифчик. Пришлось удалить.",
                    Price = 333M
                },
            };
            tarifs.ForEach(t => context.Tarifs.Add(t));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Роутер. Просто роутер",
                    AuthorID = 2,
                    Description = "Самый лучший на свете роутер",
                    Category = Relevance.Active,
                    Type = TypeProduct.Router,
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage {  Path = "/images/products/router.png" },
                        new PathToImage { Path = "/images/products/router_1.png" }
                    },
                    Price = 1500M
                },
                new Product
                {
                    Name = "Модем. Мечта мазохиста.",
                    AuthorID = 2,
                    Description = "2-х мегабитный модечик. Окунись в прошлое",
                    Category = Relevance.Active,
                    Type = TypeProduct.Modem,
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage {  Path = "/images/products/modem.png" },
                        new PathToImage { Path = "/images/products/modem_big.png" }
                    },
                    Price = 1000M
                },
                new Product
                {
                    Name = "Куча мусорв",
                    AuthorID = 1,
                    Description = "Самая бесценная куча мусора в мире.",
                    Category = Relevance.Archive,
                    Type = TypeProduct.Router,
                    PathToPhotos = new List<PathToImage>
                    {
                        new PathToImage {  Path = "/images/products/trash.png" },
                        new PathToImage { Path = "/images/products/trash-3.png" }
                    },
                    Price = 5000M
                }
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var feedbacks = new List<Feedback>
            {
                new Feedback
                {
                    Header = "Интернет гавно",
                    Category = Relevance.Active,
                    ClientName = "Вася",
                    ClientAddress = "Дом Васи",
                    ClientPhone = "89032504787",
                    CreateDate = DateTime.Now,
                    Body = "Самый худший интернет на планете"
                },
                new Feedback
                {
                    Header = "Отличная связь",
                    Category = Relevance.Active,
                    ClientName = "Химтех-Р",
                    ClientAddress = "Косякова 13",
                    ClientPhone = "88005553535",
                    CreateDate = DateTime.Now,
                    Body = "Все отлично звонит"
                },
                new Feedback
                {
                    Header = "Альтес-Р отстой",
                    Category = Relevance.Archive,
                    ClientName = "Виталя",
                    ClientAddress = "Под мостом",
                    ClientPhone = "89161402188",
                    CreateDate = DateTime.Now,
                    Body = "Худшая контора на свете"
                }
            };
            feedbacks.ForEach(f => context.Feedbacks.Add(f));
            context.SaveChanges();

            return View(context.AllNews.ToList());
        }
    }
}