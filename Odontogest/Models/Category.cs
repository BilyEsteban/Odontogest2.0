using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Display(Name ="Nombre de la Categoria")]
        public string NameCategory { get; set; }

        public ICollection<Inventory> Inventories { get; set; }
    }
}
