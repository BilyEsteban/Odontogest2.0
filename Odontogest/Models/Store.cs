using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Odontogest.Models
{
    public class Store
    {
       
        public int IdStore { get; set; }

        [Display(Name="Nombre del Almacen")]
        public string NameStore { get; set; }

        [Required(ErrorMessage ="El campo esta vacio")]
        [StringLength(20,ErrorMessage ="El texto es muy largo")]
        [Display(Name ="Ubicacion")]
        public string Location { get; set; }

        [Display(Name ="Catidad de Articulos")]
        public decimal QuantityArticles { get; set; }

        [Display(Name ="Nuevos articulos")]
        public decimal NewArticles { get; set; }

        [Display(Name ="Estado")]
        public string State { get; set; }

        public  ICollection<Inventory> Inventories { get; set; }
    }
}
