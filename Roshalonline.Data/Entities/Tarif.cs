using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Models
{
    public enum TargetAudience
    {
        Individual,
        Corporation
    }

    public enum TypeOfTarif
    {
        Internet,
        Telephony
    }

    public class DiscountPricesForTelephonyTarif
    {
        public int ID { get; set; }
        public decimal DiscountValue { get; set; }
    }

    public class Tarif
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TargetAudience Audience { get; set; }
        public TypeOfTarif Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IList<DiscountPricesForTelephonyTarif> DiscountPrices { get; set; }

        public int AuthorID { get; set; }
        public User Author { get; set; }
    }
}
