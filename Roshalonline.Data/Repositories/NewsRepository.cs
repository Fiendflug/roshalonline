using Roshalonline.Data.Context;
using Roshalonline.Data.Interfaces;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private DatabaseContext _database;

        public NewsRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(News item)
        {
            _database.AllNews.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.AllNews.Find(id);
            if (item != null)
            {
                _database.AllNews.Remove(item);
            }
        }

        public void Edit(News item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<News> GetAllItems()
        {
            return _database.AllNews.ToList();
        }

        public News GetItem(int? id)
        {
            return _database.AllNews.Find(id);
        }
    }
}
