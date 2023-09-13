using System;
using System.Collections.Generic;

#nullable disable

namespace Odontogest.Models
{
    public class Store
    {
       
        public int IdStore { get; set; }
        public string NameStore { get; set; }
        public string Location { get; set; }
        public decimal QuantityArticles { get; set; }
        public decimal NewArticles { get; set; }
        public string State { get; set; }

        public  ICollection<Inventory> Inventories { get; set; }
    }
}
