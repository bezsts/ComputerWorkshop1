using ComputerWorkshop1.Models;

namespace ComputerWorkshop1.Storage
{
    public class UserStorage
    {
        private readonly JsonFileService<User> jsonFileService = new JsonFileService<User>("Data/users.json");
        private readonly List<User> data = [];

        public UserStorage() 
        {
            data = jsonFileService.LoadData();
        }

        public IEnumerable<User> GetAll() => data;

        public User? Get(int Id) => data.Find(x => x.Id == Id);

        public User Add(User user)
        {
            user.Id = data.Any() ? data.Max(x => x.Id) + 1 : 1;
            data.Add(user);

            return user;
        }

        public bool Update(int id, User updatedUser)
        { 
            var userIndex = data.FindIndex(x => x.Id == id);

            if (userIndex == -1)
            {
                return false;
            }

            data[userIndex].Name = updatedUser.Name;
            data[userIndex].Email = updatedUser.Email;
            data[userIndex].Password = updatedUser.Password;
            data[userIndex].WatchedMovies = updatedUser.WatchedMovies;

            return true;
        }
        public int Delete(int Id) => data.RemoveAll(x => x.Id == Id);

        public void SaveData() => jsonFileService.SaveData(data);
    }
}
