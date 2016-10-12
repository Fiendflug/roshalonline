using Roshalonline.Data.Context;
using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    public class NotesRepository : IRepository<Note>
    {
        private ModelsContext _modelsContext;

        public NotesRepository(ModelsContext modelsContext)
        {
            _modelsContext = modelsContext;
        }

        public void Create(Note item)
        {
            _modelsContext.Notes.Add(item);
        }

        public void Delete(int idItem)
        {
            Note foundNote = _modelsContext.Notes.Find(idItem);
            if (foundNote != null)
                _modelsContext.Notes.Remove(foundNote);
        }

        public Note Get(int idItem)
        {
            return _modelsContext.Notes.Find(idItem);
        }

        public IEnumerable<Note> GetIAll()
        {
            return _modelsContext.Notes;
        }

        public void Udpate(Note item)
        {
            _modelsContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
