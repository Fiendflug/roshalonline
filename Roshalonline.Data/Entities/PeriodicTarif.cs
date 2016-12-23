using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshalonline.Data.Entities
{
    public class PeriodicTarif
    {
        public enum TargetAudience
        {
            Individual,
            Corporation
        }

        public enum Technology
        {
            Telephone,
            Ethernet,
            ADSL
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TargetAudience Audience { get; set; }
        public string Description { get; set; }
        public Technology TarifTechnology { get; set; }
        public decimal Price { get; set; }

        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}
