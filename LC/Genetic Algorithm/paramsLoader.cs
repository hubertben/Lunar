
using Newtonsoft.Json;
using _Functions;

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

        public T getItem<T>(string key){
            return Functions.getItem<T>(key, this.params_);
        }

    }

}
