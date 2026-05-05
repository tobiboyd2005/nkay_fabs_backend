using nkay_fabs_backend.Helpers;

namespace nkay_fabs_backend.Models.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = TimeHelper.NowWAT();
        public DateTime UpdatedAt { get; set; } = TimeHelper.NowWAT();
        public ICollection<Fabric> Fabrics { get; set; } = new List<Fabric>();
    }
}
