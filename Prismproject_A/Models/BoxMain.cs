namespace Prismproject_A.Models
{
    public partial class BoxMain
    {
        public int Id { get; set; }
        public string BoxNumber { get; set; } = null!;

        public string SampleType { get; set; } = null!;

        public string Boxlocation { get; set; } = null!;

        public string? F4 { get; set; }

        public string? F5 { get; set; }
    }
}
