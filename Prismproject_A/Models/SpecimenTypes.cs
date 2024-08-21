namespace Prismproject_A.Models
{
    public partial class SpecimenTypes
    {
        public int Id { get; set; }
        public string SpecimenName { get; set; } = null!;

        public byte SpecimenType { get; set; }

        public string Prefix { get; set; } = null!;

        public byte NumRows { get; set; }

        public byte NumCols { get; set; }
    }
}
