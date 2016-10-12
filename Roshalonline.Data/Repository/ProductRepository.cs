using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class ProductsRepository : IRepository<Product>
    {
        private ModelsContext _modelsContext;

        public ProductsRepository(ModelsContext modelsContext)
        {
            _modelsContext = modelsContext;
        }

        public void Create(Product item)
        {
            _modelsContext.Products.Add(item);
        }

        public void Delete(int idItem)
        {
            Product foundProduct = _modelsContext.Products.Find(idItem);
            if (foundProduct != null)
                _modelsContext.Products.Remove(foundProduct);
        }

        public Product Get(int idItem)
        {
            return _modelsContext.Products.Find(idItem);
        }

        public IEnumerable<Product> GetIAll()
        {
            return _modelsContext.Products;
        }

        public void Udpate(Product item)
        {
            _modelsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
