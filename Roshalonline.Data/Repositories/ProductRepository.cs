using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Context;
using Roshalonline.Data.Interfaces;
using Roshalonline.Data.Models;

namespace Roshalonline.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private DatabaseContext _database;

        public ProductRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(Product item)
        {
            _database.Products.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.Products.Find(id);
            if (item != null)
            {
                _database.Products.Remove(item);
            }
        }

        public void Edit(Product item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<Product> GetAllItems()
        {
            return _database.Products.ToList();
        }

        public Product GetItem(int? id)
        {
            return _database.Products.Find(id);
        }
    }
}
