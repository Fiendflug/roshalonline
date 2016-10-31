using Roshalonline.Logic.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Logic.Interfaces
{
    public interface IUser
    {
        UserME Login(string login, string password);
        IList<UserME> GetUsers(Func<UserME, bool> predicate);
        IList<UserME> GetAllUsers();
        void Create(UserME user);
        void Delete(int? id);
    }
}
