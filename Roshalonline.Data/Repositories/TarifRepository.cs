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
    public class TarifRepository : IRepository<Tarif>
    {
        private DatabaseContext _database;

        public TarifRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(Tarif item)
        {
            _database.Tarifs.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.Tarifs.Find(id);
            if (item != null)
            {
                _database.Tarifs.Remove(item);
            }
        }

        public void Edit(Tarif item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<Tarif> GetAllItems()
        {
            return _database.Tarifs.ToList();
        }

        public Tarif GetItem(int? id)
        {
            return _database.Tarifs.Find(id);
        }
    }
}
