using ApiDomain.Models;

namespace ApiDomain.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie? Get(int id);
        Movie Create(Movie movie);
        bool Update(int id, Movie updatedMovie);
        bool Delete(int id);
    }
}
