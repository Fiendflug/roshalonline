using Roshalonline.Data.Context;
using Roshalonline.Data.Entities;
using Roshalonline.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repositories
{
    class PeriodicTarifRepository : IRepository<PeriodicTarif>
    {
        private DatabaseContext _database;

        public PeriodicTarifRepository(DatabaseContext database)
        {
            _database = database;
        }


        public void Create(PeriodicTarif item)
        {
            _database.PeriodicTarifs.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.PeriodicTarifs.Find(id);
            if (item != null)
            {
                _database.PeriodicTarifs.Remove(item);
            }
        }

        public void Edit(PeriodicTarif item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<PeriodicTarif> GetAllItems()
        {
            return _database.PeriodicTarifs.ToList();
        }

        public PeriodicTarif GetItem(int? id)
        {
            return _database.PeriodicTarifs.Find(id);
        }
    }
}
