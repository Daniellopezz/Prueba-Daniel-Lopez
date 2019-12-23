using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaDaniel.Models.ViewModel
{
    public class ListPersonaViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
    }
}