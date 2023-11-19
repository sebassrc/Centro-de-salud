namespace CiudadanosSanos.Models
{
    public class Urgencia
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? TipoU { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
