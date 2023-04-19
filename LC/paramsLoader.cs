
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

        public string getType(Object obj) {
            return obj.GetType().ToString();
        }

        public Object getItem(string name){
            return this.params_[name];
        }

    }

}
