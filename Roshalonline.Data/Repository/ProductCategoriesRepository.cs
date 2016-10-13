using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using Roshalonline.Data.Repository;

namespace Roshalonline.Data.Repository
{
    public class ProductCategoriesRepository : ICategoryRepository<ProductCategory>
    {
        private ModelsContext _modelContext;

        public ProductCategoriesRepository(ModelsContext modelContext)
        {
            _modelContext = modelContext;
        }

        public void CreateCategory(ProductCategory category)
        {
            _modelContext.ProductCategories.Add(category);
        }

        public void DeleteCategory(int idCategory)
        {
            ProductCategory foundCategory = _modelContext.ProductCategories.Find(idCategory);
            if (foundCategory != null)
                _modelContext.ProductCategories.Remove(foundCategory);
        }

        public IEnumerable<ProductCategory> GetAllCategories()
        {
            return _modelContext.ProductCategories;
        }

        public ProductCategory GetCategory(int idCategory)
        {
            return _modelContext.ProductCategories.Find(idCategory);
        }
    }
}
