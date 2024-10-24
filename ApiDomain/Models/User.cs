namespace ApiDomain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<int> WatchedMovies { get; set; } = new List<int>();
    }
}
