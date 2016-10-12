using Roshalonline.Data.Models;
using Roshalonline.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class NewsRepository : IRepository<News>
    {
        private ModelsContext _modelsContext;

        public NewsRepository(ModelsContext modelsContext)
        {
            _modelsContext = modelsContext;
        }

        public void Create(News item)
        {
            _modelsContext.AllNews.Add(item);
        }

        public void Delete(int idItem)
        {
            News foundNews = _modelsContext.AllNews.Find(idItem);
            if (foundNews != null)
                _modelsContext.AllNews.Remove(foundNews);
        }

        public News Get(int idItem)
        {
            return _modelsContext.AllNews.Find(idItem);
        }

        public IEnumerable<News> GetIAll()
        {
            return _modelsContext.AllNews;
        }

        public void Udpate(News item)
        {
            _modelsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
