using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Data.Models;
using Roshalonline.Data.Interfaces;
using Roshalonline.Data.Context;

namespace Roshalonline.Data.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private DatabaseContext _database;

        public NoteRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(Note item)
        {
            _database.Notes.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.Notes.Find(id);
            if (item != null)
            {
                _database.Notes.Remove(item);
            }
        }

        public void Edit(Note item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<Note> GetAllItems()
        {
            return _database.Notes.ToList();
        }

        public Note GetItem(int? id)
        {
            return _database.Notes.Find(id);
        }
    }
}
