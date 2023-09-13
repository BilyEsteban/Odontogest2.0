using System;
using System.Collections.Generic;

#nullable disable

namespace Odontogest.Models
{
    public class Category
    {
        public Category()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
