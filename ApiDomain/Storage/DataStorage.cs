using ApiDomain.Models;
using ApiDomain.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiDomain.Storage
{
    public class DataStorage : IDataStorage
    {
        private readonly JsonFileService<Movie> movieFileService = new JsonFileService<Movie>("Data/movies.json");
        private readonly JsonFileService<User> userFileService = new JsonFileService<User>("Data/users.json");

        public List<User> Users { get; private set; }
        public List<Movie> Movies { get; private set; }

        public DataStorage()
        {
            Movies = movieFileService.LoadData();
            Users = userFileService.LoadData();
        }

        public void SaveUsersData() => userFileService.SaveData(Users);
        public void SaveMoviesData() => movieFileService.SaveData(Movies);

    }
}
