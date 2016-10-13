using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class NewsCategoriesRepository : ICategoryRepository<NewsCategory>
    {
        private ModelsContext _modelContext;

        public NewsCategoriesRepository(ModelsContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void CreateCategory(NewsCategory category)
        {
            _modelContext.NewsCategories.Add(category);
        }

        public void DeleteCategory(int idCategory)
        {
            NewsCategory foundCategory = _modelContext.NewsCategories.Find(idCategory);
            if (foundCategory != null)
                _modelContext.NewsCategories.Remove(foundCategory);
        }

        public IEnumerable<NewsCategory> GetAllCategories()
        {
            return _modelContext.NewsCategories;
        }

        public NewsCategory GetCategory(int idCategory)
        {
            return _modelContext.NewsCategories.Find(idCategory);
        }
    }
}
