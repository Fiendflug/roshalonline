using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Provider.Data_Objects
{
    public class TarifDTO
    {
        public int TarifID { get; set; }
        public string TarifName { get; set; }
        public string TarifDescription { get; set; }
        public decimal TarifPrice { get; set; }
    }
}
