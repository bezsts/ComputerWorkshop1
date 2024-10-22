namespace ApiDomain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public Genre Genre { get; set; } 
        public DateOnly ReleaseDate { get; set; }
    }
}
