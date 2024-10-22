using ApiDomain.Models;

namespace ApiDomain.Storage
{
    public interface IUserStorage
    {
        IEnumerable<User> GetAll();
        User? Get(int Id);
        User Add(User user);
        bool Update(int id, User updatedUser);
        int Delete(int Id);
    }
}
