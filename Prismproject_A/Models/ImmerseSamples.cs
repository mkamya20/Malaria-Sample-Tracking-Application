namespace Prismproject_A.Models
{
    public class ImmerseSamples
    {
        public int Id { get; set; }

        public string BoxNumber { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public byte BoxRow { get; set; }

        public byte BoxColumn { get; set; }

        public DateTime? TbldateAdded { get; set; }

        public string? PlateNumber { get; set; }

        public string? PcrplateLayout { get; set; }

        public string? AliquotePlateNumber { get; set; }

        public string? AliquotePlatePosition { get; set; }
    }

}
