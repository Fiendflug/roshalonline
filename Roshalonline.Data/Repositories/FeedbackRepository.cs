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
    public class FeedbackRepository : IRepository<Feedback>
    {
        private DatabaseContext _database;

        public FeedbackRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(Feedback item)
        {
            _database.Feedbacks.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.Feedbacks.Find(id);
            if (item != null)
            {
                _database.Feedbacks.Remove(item);
            }
        }

        public void Edit(Feedback item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<Feedback> GetAllItems()
        {
            return _database.Feedbacks.ToList();
        }

        public Feedback GetItem(int? id)
        {
            return _database.Feedbacks.Find(id);
        }
    }
}
