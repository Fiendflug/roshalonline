using Roshalonline.Logic.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Logic.Interfaces
{
    interface IEntry<T> where T : class
    {
        IList<T> GetAllItems();
        IList<T> GetItems(Func<T, bool> predicate);
        T GetItem(int? id);
        void Create(T item);
        void Edit(int? id);
        void Delete(int? id);
        void Dispose();
    }
}
