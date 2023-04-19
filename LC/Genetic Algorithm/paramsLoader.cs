
using Newtonsoft.Json;

namespace _ParamsLoader {

    public class ParamsLoader {

        private Dictionary<string, object> params_ = new Dictionary<string, object>();
        public ParamsLoader(string path) {
            ReadJsonFile(path);
        }

        public void ReadJsonFile(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            this.params_ = data;
        }

        public T getItem<T>(string key)
{
            if (!this.params_.ContainsKey(key))
            {
                throw new ArgumentException("Key not found in dictionary.");
            }
            object value = this.params_[key];
            if (value == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(value, typeof(T));
        }

    }

}
