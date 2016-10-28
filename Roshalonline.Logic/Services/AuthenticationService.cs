using Roshalonline.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roshalonline.Logic.MiddleEntities;
using Roshalonline.Data.Repositories;
using AutoMapper;
using Roshalonline.Data.Models;
using Roshalonline.Logic.Infrastructure;

namespace Roshalonline.Logic.Services
{
    public class AuthenticationService : IUser
    {
        private DatabaseWorker _database;

        public AuthenticationService()
        {
            _database = new DatabaseWorker();
        }

        public void Create(UserME user)
        {
            if (user == null)
            {
                throw new ValidationException("Не удалось получить объект User", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<UserME, User>());
            var item = Mapper.Map<UserME, User>(user);
            _database.Users.Create(item);
            _database.Save();
        }

        public IList<UserME> GetAllUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserME>());
            return Mapper.Map<IList<User>, IList<UserME>>(_database.Users.GetAllItems()).ToList();
        }

        public UserME GetUser(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            var item = _database.Users.GetItem(id);
            if (item == null)
            {
                throw new ValidationException("Не удалось получить объект News по указанному id", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserME>());
            return Mapper.Map<User, UserME>(item);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не указан id", "");
            }
            _database.Users.Delete(id);
            _database.Save();
        }

        public IList<UserME> GetUsers(Func<UserME, bool> predicate)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserME>());
            return Mapper.Map<IList<User>, List<UserME>>(_database.Users.GetAllItems()).Where(predicate).ToList();
        }
    }
}
