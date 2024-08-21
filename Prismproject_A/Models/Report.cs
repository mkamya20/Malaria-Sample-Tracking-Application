namespace Prismproject_A.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public string? Site { get; set; }

        public string BoxNumber { get; set; } = null!;

        public string SampleType { get; set; } = null!;

        public string Barcode { get; set; } = null!;

        public byte BoxRow { get; set; }

        public byte BoxColumn { get; set; }

        public DateTime? TbldateAdded { get; set; }
    }
}
