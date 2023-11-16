namespace KMF.Models
{
    public class ConcertoDto
    {
        public string Name { get; set; } = default!;
        public string EncodedName { get; set; } = default!;
        public string Place { get; set; } = default!;
        public DateTime Time { get; set; } = default!;
        public string ConcertProgram { get; set; } = default!;
        public string Info { get; set; } = default!;
        public bool IsEditable { get; set; }
    }
}
