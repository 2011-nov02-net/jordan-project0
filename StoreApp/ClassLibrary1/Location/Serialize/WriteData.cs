using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StoreApp.Library.Location.Serialize
{
    public class WriteData
    {
        public WriteData(DataBase db, string filePath)
        {
            string json = JsonSerializer.Serialize(db);
            File.WriteAllText(filePath, json);
        }

    }
}
