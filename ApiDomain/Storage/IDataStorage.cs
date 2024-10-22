using ApiDomain.Models;

namespace ApiDomain.Storage
{
    public interface IDataStorage
    {
        List<User> Users { get; }
        List<Movie> Movies { get; }

        void SaveUsersData();
        void SaveMoviesData();
    }
}
