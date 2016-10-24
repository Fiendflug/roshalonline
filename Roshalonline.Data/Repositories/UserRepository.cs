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
    public class UserRepository : IRepository<User>
    {
        private DatabaseContext _database;

        public UserRepository(DatabaseContext database)
        {
            _database = database;
        }

        public void Create(User item)
        {
            _database.Users.Add(item);
        }

        public void Delete(int? id)
        {
            var item = _database.Users.Find(id);
            if (item != null)
            {
                _database.Users.Remove(item);
            }
        }

        public void Edit(User item)
        {
            _database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IList<User> GetAllItems()
        {
            return _database.Users.ToList();
        }

        public User GetItem(int? id)
        {
            return _database.Users.Find(id);
        }
    }
}
