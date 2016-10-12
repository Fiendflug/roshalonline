using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class TarifsRepository : IRepository<Tarif>
    {
        private ModelsContext _modelsContext;

        public TarifsRepository(ModelsContext modelsContext)
        {
            _modelsContext = modelsContext;
        }
        public void Create(Tarif item)
        {
            _modelsContext.Tarifs.Add(item);
        }

        public void Delete(int idItem)
        {
            Tarif foundTarif = _modelsContext.Tarifs.Find(idItem);
            if (foundTarif != null)
                _modelsContext.Tarifs.Remove(foundTarif);
        }

        public Tarif Get(int idItem)
        {
            return _modelsContext.Tarifs.Find(idItem);
        }

        public IEnumerable<Tarif> GetIAll()
        {
            return _modelsContext.Tarifs;
        }

        public void Udpate(Tarif item)
        {
            _modelsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
