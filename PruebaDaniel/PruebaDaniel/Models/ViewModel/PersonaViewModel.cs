using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaDaniel.Models.ViewModel
{
    public class PersonaViewModel
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Fecha_Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}