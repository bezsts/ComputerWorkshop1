using ApiDomain.Models;

namespace ApiDomain.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? Get(int Id);
        User Create(User user);
        bool Update(int id, User updatedUser);
        bool Delete(int Id);
        MovieStatistics? GetMovieStatistics(int userId);
    }
}
