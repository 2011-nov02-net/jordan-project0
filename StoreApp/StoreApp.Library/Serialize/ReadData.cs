using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StoreApp.Library.Location.Serialize
{
    public class ReadData 
    {
        public static string GetConnectionString()
        {
            string path = "../../../../../../store-connection-string.json";
            string json;
            try  {
                json = File.ReadAllText(path);
            }
            catch (IOException)
            {
                Console.WriteLine($"File {path} Not Found");
                throw;
            }
            string connectionString = JsonSerializer.Deserialize<string>(json);
            return connectionString;

        }
    }
}
