using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;
using Roshalonline.Data.Context;

namespace Roshalonline.Data.Repository
{
    public class TarifsCategoriesRepository : ICategoryRepository<TarifCategory>
    {
        private ModelsContext _modelContext;
        
        public TarifsCategoriesRepository(ModelsContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void CreateCategory(TarifCategory category)
        {
            _modelContext.TarifCategories.Add(category);
        }

        public void DeleteCategory(int idCategory)
        {
            TarifCategory foundCategory = _modelContext.TarifCategories.Find(idCategory);
            if (foundCategory != null)
                _modelContext.TarifCategories.Remove(foundCategory);
        }

        public IEnumerable<TarifCategory> GetAllCategories()
        {
            return _modelContext.TarifCategories;
        }

        public TarifCategory GetCategory(int idCategory)
        {
            return _modelContext.TarifCategories.Find(idCategory);
        }
    }
}
