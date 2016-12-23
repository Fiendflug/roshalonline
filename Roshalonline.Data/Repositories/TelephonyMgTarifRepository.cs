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
    class TelephonyMgTarifRepository : IRepository<TelephonyMgTarif>
    {
        private DatabaseContext _database;

        public TelephonyMgTarifRepository(DatabaseContext database)
        {
            _database = database;
        }


        public void Create(TelephonyMgTarif item)
        {
            _database.TelephonyMgTarifs.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.TelephonyMgTarifs.Find(id);
            if (item != null)
            {
                _database.TelephonyMgTarifs.Remove(item);
            }
        }

        
        public void Edit(TelephonyMgTarif item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<TelephonyMgTarif> GetAllItems()
        {
            return _database.TelephonyMgTarifs.ToList();
        }

        public TelephonyMgTarif GetItem(int? id)
        {
            return _database.TelephonyMgTarifs.Find(id);
        }
    }
}
