using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Odontogest.Models
{
    public class Inventory
    {        
        public int IdInventory { get; set; }
        
        //[Required]
        [Display(Name ="Nombre del Inventario")]
        public string NameInventory { get; set; }

        //[Required(ErrorMessage ="El campo es obligatorio")]
        [Display(Name ="Categoria")]
        public int? FkCategory { get; set; }

        [Display(Name = "Almacen")]
        public int? FkStore { get; set; }

        [Display(Name ="Precio")]
        public decimal? Price { get; set; }

        [Display(Name ="Cantidad Disponible")]
        public decimal? QuantityAvailable { get; set; }

        [Display(Name ="Cantidad")]
        public int? Quantity { get; set; }

        [Display(Name ="Descripcion")]
        public string Description { get; set; }

        [Display(Name ="Estado")]
        public string State { get; set; }

        public string UserCreation { get; set; }
        public DateTime? CreationDate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime? DateUpdate { get; set; }

        [Display(Name ="Imagen")]
        public string Image { get; set; }   
        [Display(Name ="Categoria")]
        public  Category? FkCategoryNavigation { get; set; }
        [Display(Name = "Almacen")]
        public Store? FkStoreNavigation { get; set; }
    }
}
