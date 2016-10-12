using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetIAll();
        T Get(int idItem);
        void Create(T item);
        void Udpate(T item);
        void Delete(int idItem);
    }
}
