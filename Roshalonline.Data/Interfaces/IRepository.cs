using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAllItems();
        T GetItem(int? id);
        void Create(T item);
        void Edit(T item);
        void Delete(int? id);
    }
}
