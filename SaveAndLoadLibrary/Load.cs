using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace SaveAndLoadLibrary
{
    public class Load
    {
        public static object obj { get; set; }

        public Load()
        {
            string path = @"autosave.json";
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader st = new StreamReader(path))
            using(JsonReader jr = new JsonTextReader(st))
            {
                obj = deserializer.Deserialize(jr);
            }
        }
    }
}
