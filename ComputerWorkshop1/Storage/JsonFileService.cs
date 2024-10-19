using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ComputerWorkshop1.Storage
{
    public class JsonFileService<T> where T : class
    {
        private readonly string _filePath;

        public JsonFileService(string filePath)
        {
            _filePath = filePath;
        }

        public List<T> LoadData()
        {
            if (!File.Exists(_filePath))
            { 
                return new List<T>();
            }

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void SaveData(List<T> data) 
        { 
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, json);
        }
    }
}
