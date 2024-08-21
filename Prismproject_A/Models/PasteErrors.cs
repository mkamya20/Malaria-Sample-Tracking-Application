namespace Prismproject_A.Models
{
    public partial class PasteErrors
    {
        public int Id { get; set; }
        public string F1 { get; set; } = null!;

        public string F2 { get; set; } = null!;

        public TimeSpan F3 { get; set; }

        public TimeSpan F4 { get; set; }

        public DateTime F5 { get; set; }
    }
}
