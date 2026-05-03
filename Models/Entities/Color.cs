namespace nkay_fabs_backend.Models.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;
        public ICollection<Fabric> Fabrics { get; set; } = new List<Fabric>();
    }
}
