using BSTreeSubmitProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSTreeSubmitProject.Utils
{
    internal static class JsonUtil
    {
        public static List<T> GetObjectsFromJson<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json)!;
        }

        public static void SetDefenceStrategiesJson(List<DefenceStrategy> list, string path)
        {
            string jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }
    }
}
