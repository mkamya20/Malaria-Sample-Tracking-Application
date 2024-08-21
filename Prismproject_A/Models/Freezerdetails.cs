namespace Prismproject_A.Models
{
    public partial class FreezerDetails
    {
        public int Id { get; set; }
        public string Freezername { get; set; } = null!;

        public string Compartment { get; set; } = null!;

        public byte Rack { get; set; }

        public byte Position { get; set; }
    }
}
