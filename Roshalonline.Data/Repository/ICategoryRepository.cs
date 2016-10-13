using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Repository
{
    interface ICategoryRepository<T>
    {
        IEnumerable<T> GetAllCategories();
        T GetCategory(int idCategory);
        void CreateCategory(T category);
        void DeleteCategory(int idCategory);
    }
}
