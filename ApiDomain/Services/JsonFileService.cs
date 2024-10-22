using Newtonsoft.Json;

namespace ApiDomain.Services
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

            var jsonText = File.ReadAllText(_filePath);
            var jsonList = JsonConvert.DeserializeObject<List<T>>(jsonText);
            return jsonList == null ? new List<T>() : jsonList;
        }

        public void SaveData(List<T> data)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, json);
        }
    }
}
