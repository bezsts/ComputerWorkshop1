using ApiDomain.Models;
using ApiDomain.Services;

namespace ApiDomain.Storage
{
    internal class MovieStorage : IMovieStorage
    {
        private readonly JsonFileService<Movie> jsonFileService = new JsonFileService<Movie>("Data/movies.json");
        private List<Movie> data = [];

        public MovieStorage()
        {
            data = jsonFileService.LoadData();
        }

        public IEnumerable<Movie> GetAll() => data;

        public Movie? Get(int id) => data.Find(x => x.Id == id);

        public Movie Add(Movie movie)
        {
            movie.Id = data.Any() ? data.Max(x => x.Id) + 1 : 1;
            data.Add(movie);
            SaveData();
            return movie;
        }

        public bool Update(int id, Movie updatedMovie)
        {
            var movieIndex = data.FindIndex(x => x.Id == id);

            if (movieIndex == -1)
            {
                return false;
            }

            data[movieIndex].Title = updatedMovie.Title;
            data[movieIndex].Director = updatedMovie.Director;
            data[movieIndex].Genre = updatedMovie.Genre;
            data[movieIndex].ReleaseDate = updatedMovie.ReleaseDate;
            SaveData();
            return true;
        }

        public int Delete(int id)
        {
            int number = data.RemoveAll(x => x.Id == id);
            SaveData();
            return number;
        }

        private void SaveData() => jsonFileService.SaveData(data);
    }
}
