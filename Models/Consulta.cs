namespace CiudadanosSanos.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}