using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;
using Roshalonline.Data.Context;

namespace Roshalonline.Data.Repository
{
    public class PhoneBookRepository : IRepository<Phonebook>
    {
        private ModelsContext _modelsContext;

        public PhoneBookRepository(ModelsContext modelsContext)
        {
            _modelsContext = modelsContext;
        }

        public void Create(Phonebook item)
        {
            _modelsContext.PhonebookNotes.Add(item);
        }

        public void Delete(int idItem)
        {
            Phonebook foundPhonebook = _modelsContext.PhonebookNotes.Find(idItem);
            if (foundPhonebook != null)
                _modelsContext.PhonebookNotes.Remove(foundPhonebook);
        }

        public Phonebook Get(int idItem)
        {
            return _modelsContext.PhonebookNotes.Find(idItem);
        }

        public IEnumerable<Phonebook> GetIAll()
        {
            return _modelsContext.PhonebookNotes;
        }

        public void Udpate(Phonebook item)
        {
            _modelsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
