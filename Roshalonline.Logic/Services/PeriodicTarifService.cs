using AutoMapper;
using Roshalonline.Data.Entities;
using Roshalonline.Data.Repositories;
using Roshalonline.Logic.Infrastructure;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Logic.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Logic.Services
{
    public class PeriodicTarifService : IEntry<PeriodicTarifME>
    {
        private DatabaseWorker _database;

        public PeriodicTarifService()
        {
            _database = new DatabaseWorker();
        }

        public void Create(PeriodicTarifME item)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarif>());
            var news = Mapper.Map<PeriodicTarifME, PeriodicTarif>(item);
            _database.PeriodicTarifs.Create(news);
            _database.Save();
        }

        public void AddToArchive(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            var item = _database.PeriodicTarifs.GetItem(id);
            item.Category = Data.Models.Relevance.Archive;
            _database.Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            _database.PeriodicTarifs.Delete(id);
            _database.Save();
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public void Edit(PeriodicTarifME item)
        {
            if (item == null)
            {
                throw new ValidationException("Не удалось получить объект News по указанному id", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarifME, PeriodicTarif>());
            var itemME = Mapper.Map<PeriodicTarifME, PeriodicTarif>(item);
            _database.PeriodicTarifs.Edit(itemME);
            _database.Save();
        }

        public IList<PeriodicTarifME> GetAllItems()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarif, PeriodicTarifME>());
            return Mapper.Map<IList<PeriodicTarif>, List<PeriodicTarifME>>(_database.PeriodicTarifs.GetAllItems());
        }

        public PeriodicTarifME GetItem(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            var item = _database.PeriodicTarifs.GetItem(id);
            if (item == null)
            {
                throw new ValidationException("Не удалось получить объект News по указанному id", "");
            }
            Mapper.Initialize(cgf => cgf.CreateMap<PeriodicTarif, PeriodicTarifME>());
            return Mapper.Map<PeriodicTarif, PeriodicTarifME>(item);
        }

        public IList<PeriodicTarifME> GetItems(Func<PeriodicTarifME, bool> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<PeriodicTarif, PeriodicTarifME>());
            return Mapper.Map<IList<PeriodicTarif>, List<PeriodicTarifME>>(_database.PeriodicTarifs.GetAllItems()).Where(predicate).ToList();
        }
    }
}
