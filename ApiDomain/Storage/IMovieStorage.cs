using ApiDomain.Models;

namespace ApiDomain.Storage
{
    public interface IMovieStorage
    {
        IEnumerable<Movie> GetAll();
        Movie? Get(int id);
        Movie Create(Movie movie);
        bool Update(int id, Movie updatedMovie);
        int Delete(int id);
    }
}
