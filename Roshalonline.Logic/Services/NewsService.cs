using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using Roshalonline.Data.Repositories;
using Roshalonline.Logic.Infrastructure;
using Roshalonline.Data.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;

namespace Roshalonline.Logic.Services
{
    public class NewsService : IEntry<NewsME>
    {
        private DatabaseWorker _database;

        public NewsService()
        {
            _database = new DatabaseWorker(); 
        }

        public void Create(NewsME item)
        {
            News news = new News
            {
                Header = item.Header,
                Category = item.Category,
                Author = item.Author,
                PathToIcon = item.PathToIcon,
                CreateDate = item.CreateDate,
                Body = item.Body,
                ViewsCount = 0
            };
            _database.News.Create(news);
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }            
            _database.News.Delete(id);
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public void Edit(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            var item = _database.News.GetItem(id);
            if (item == null)
            {
                throw new ValidationException("Не удалось получить объект News по указанному id", "");
            }
            _database.News.Edit(item);
        }

        public IList<NewsME> GetAllItems()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<News, NewsME>());
            return Mapper.Map<IList<News>, List<NewsME>>(_database.News.GetAllItems());
        }

        public NewsME GetItem(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            var item = _database.News.GetItem(id);
            if (item == null)
            {
                throw new ValidationException("Не удалось получить объект News по указанному id", "");
            }
            Mapper.Initialize(cgf => cgf.CreateMap<News, NewsME>());
            return Mapper.Map<News, NewsME>(item);
        }

        public IList<NewsME> GetItems(Func<NewsME, bool> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<News, NewsME>());
            return Mapper.Map<IList<News>, List<NewsME>>(_database.News.GetAllItems()).Where(predicate).ToList();
        }
    }
}
