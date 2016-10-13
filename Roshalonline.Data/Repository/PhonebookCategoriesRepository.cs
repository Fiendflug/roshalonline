using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;
using Roshalonline.Data.Repository;
using Roshalonline.Data.Context;

namespace Roshalonline.Data.Repository
{
    public class PhonebookCategoriesRepository : ICategoryRepository<PhonebookCategory>
    {
        private ModelsContext _modelContext;

        public PhonebookCategoriesRepository (ModelsContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void CreateCategory(PhonebookCategory category)
        {
            _modelContext.PhonebookCategories.Add(category);
        }

        public void DeleteCategory(int idCategory)
        {
            PhonebookCategory foundCategory = _modelContext.PhonebookCategories.Find(idCategory);
            if (foundCategory != null)
                _modelContext.PhonebookCategories.Remove(foundCategory);
        }

        public IEnumerable<PhonebookCategory> GetAllCategories()
        {
            return _modelContext.PhonebookCategories;
        }

        public PhonebookCategory GetCategory(int idCategory)
        {
            return _modelContext.PhonebookCategories.Find(idCategory);
        }
    }
}
