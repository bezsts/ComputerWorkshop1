using ApiDomain.Storage;
using ApiDomain.Models;

namespace ApiDomain.Services
{
    internal class UserService : IUserService
    {
        private readonly IDataStorage dataStorage;

        public UserService(IDataStorage dataStorage) => this.dataStorage = dataStorage;

        public IEnumerable<User> GetAll() => dataStorage.Users;

        public User? Get(int Id) => dataStorage.Users.Find(x => x.Id == Id);

        public User Create(User user)
        {
            user.Id = dataStorage.Users.Any() ? dataStorage.Users.Max(x => x.Id) + 1 : 1;
            dataStorage.Users.Add(user);
            dataStorage.SaveUsersData();
            return user;
        }

        public bool Update(int id, User updatedUser)
        {
            var userIndex = dataStorage.Users.FindIndex(x => x.Id == id);

            if (userIndex == -1)
            {
                return false;
            }

            dataStorage.Users[userIndex].Name = updatedUser.Name;
            dataStorage.Users[userIndex].Email = updatedUser.Email;
            dataStorage.Users[userIndex].Password = updatedUser.Password;
            dataStorage.Users[userIndex].WatchedMovies = updatedUser.WatchedMovies;
            dataStorage.SaveUsersData();
            return true;
        }
        public bool Delete(int Id)
        {
            int number = dataStorage.Users.RemoveAll(x => x.Id == Id);
            dataStorage.SaveUsersData();
            return number != 0;
        }
    }
}
