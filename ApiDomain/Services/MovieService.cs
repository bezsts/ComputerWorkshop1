using ApiDomain.Storage;
using ApiDomain.Models;

namespace ApiDomain.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IDataStorage dataStorage;

        public MovieService(IDataStorage dataStorage) => this.dataStorage = dataStorage;

        public IEnumerable<Movie> GetAll() => dataStorage.Movies;

        public Movie? Get(int id) => dataStorage.Movies.Find(x => x.Id == id);

        public Movie Create(Movie movie)
        {
            movie.Id = dataStorage.Movies.Any() ? dataStorage.Movies.Max(x => x.Id) + 1 : 1;
            dataStorage.Movies.Add(movie);
            dataStorage.SaveMoviesData();
            return movie;
        }

        public bool Update(int id, Movie updatedMovie)
        {
            var movieIndex = dataStorage.Movies.FindIndex(x => x.Id == id);

            if (movieIndex == -1)
            {
                return false;
            }

            dataStorage.Movies[movieIndex].Title = updatedMovie.Title;
            dataStorage.Movies[movieIndex].Director = updatedMovie.Director;
            dataStorage.Movies[movieIndex].Genre = updatedMovie.Genre;
            dataStorage.Movies[movieIndex].ReleaseDate = updatedMovie.ReleaseDate;
            dataStorage.SaveMoviesData();
            return true;
        }

        public bool Delete(int id)
        {
            int number = dataStorage.Movies.RemoveAll(x => x.Id == id);
            dataStorage.SaveMoviesData();
            return number != 0;
        }
    }
}
