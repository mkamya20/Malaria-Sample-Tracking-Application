namespace Prismproject_A.Models
{
    public class ZumbaSamples
    {
        public int Id { get; set; }
        public string Barcode { get; set; } = null!;

        public string BoxNumber { get; set; } = null!;

        public byte BoxRow { get; set; }

        public byte BoxColumn { get; set; }

        public DateTime? dateAdded { get; set; } = null!;

        public byte Round { get; set; }

    }
}
