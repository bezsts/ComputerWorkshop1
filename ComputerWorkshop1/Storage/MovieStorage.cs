using ComputerWorkshop1.Models;

namespace ComputerWorkshop1.Storage
{
    public class MovieStorage
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

            return true;
        }

        public void Delete(int id) => data.RemoveAll(x => x.Id == id);

        public void SaveData() => jsonFileService.SaveData(data);
    }
}
