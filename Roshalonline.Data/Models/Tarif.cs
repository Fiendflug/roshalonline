using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public class Tarif
    {
        public int TarifID { get; set; }
        public string TarifName { get; set; }
        public string TarifDescription { get; set; }
        public decimal TarifPrice { get; set; }

        public int CategoryID { get; set; }
        public virtual TarifCategory TarifCategory { get; set; }
    }
}
