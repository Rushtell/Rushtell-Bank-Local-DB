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
    public class Save
    {
        public Save(object db)
        {
            string path = @"autosave.json";
            using(FileStream st = new FileStream(path, FileMode.OpenOrCreate)) { }
            JsonSerializer serializer = new JsonSerializer();
            using(StreamWriter st = new StreamWriter(path))
            using(JsonWriter wr = new JsonTextWriter(st))
            {
                st.Write("");
                serializer.Serialize(wr, db);
            }
        }
    }
}
