namespace Cliente.Models
{
    public class TraceViewModel
    {
        public int Id { get; set; }
        public string? Identificador { get; set; }
        public DateTime? FechaYhora { get; set; }
        public decimal? Longitud { get; set; }
        public decimal? Latitud { get; set; }
        public string? Dispositivo { get; set; }
    }
}
