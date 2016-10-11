using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class TarifCategory
    {
        public int TarifCategoryID { get; set; }
        public string TarifCategoryName { get; set; }

        public virtual ICollection<Tarif> Tarifs { get; set; }
        public TarifCategory()
        {
            Tarifs = new List<Tarif>();
        }
    }
}
