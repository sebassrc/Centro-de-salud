namespace CiudadanosSanos.Models
{
    public class Hospitalizacion
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Product>? Products { get; set; } = default!;
    }
}
