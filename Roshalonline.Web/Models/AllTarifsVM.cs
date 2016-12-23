using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roshalonline.Web.Models
{
    public class AllTarifsVM
    {
        public PeriodicTarifVM PeriodicTarif { get; set; }
        public TelephonyMgTarifVM TelephonyMgTarifVM { get; set; }
    }
}