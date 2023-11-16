namespace KMF.Entities
{
    public class Concerto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string EncodedName { get; set; } = default!;
        public string Place { get; set; } = default!;
        public DateTime Time { get; set; } = default!;
        public string ConcertProgram { get; set; } = default!;
        public string Info { get; set; } = default!;

        public string EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    }
}
