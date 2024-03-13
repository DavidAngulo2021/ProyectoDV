using System;
using System.Collections.Generic;

namespace ProyectoDV.Models
{
    public partial class Trace
    {
        public int Id { get; set; }
        public string? Identificador { get; set; }
        public DateTime? FechaYhora { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
        public string? Dispositivo { get; set; }
    }
}
