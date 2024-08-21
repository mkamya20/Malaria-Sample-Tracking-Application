namespace Prismproject_A.Models
{
    public partial class BoxLocations
    {
        public int Id { get; set; }
        public string BoxNumber { get; set; } = null!;

        public string Freezername { get; set; } = null!;

        public string Compartment { get; set; } = null!;

        public byte Rack { get; set; }

        public byte Position { get; set; }
    }
}
