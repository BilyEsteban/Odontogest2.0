using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

#nullable disable

namespace Odontogest.Models
{
    public class Inventory
    {        
        public int IdInventory { get; set; }
        public string NameInventory { get; set; }
        public int? FkCategory { get; set; }
        public int? FkStore { get; set; }
        public decimal? Price { get; set; }
        public decimal? QuantityAvailable { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string UserCreation { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string Image { get; set; }
        
        public  Category FkCategoryNavigation { get; set; }
        public  Store FkStoreNavigation { get; set; }
    }
}
