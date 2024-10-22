using ApiDomain.Models;

namespace ApiDomain.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie? Get(int id);
        Movie Create(Movie movie);
        bool Update(int id, Movie updatedMovie);
        bool Delete(int id);
    }
}
