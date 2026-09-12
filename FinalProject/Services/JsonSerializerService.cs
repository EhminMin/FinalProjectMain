using FinalProject.Models;
using System.Text.Json;

namespace FinalProject.Services
{
    public class JsonSerializerService
    {
        public FurnitureData? DeserializeFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string json = sr.ReadToEnd();
                    FurnitureData? data = JsonSerializer.Deserialize<FurnitureData>(json);
                    if (data == null)
                    {
                        Logger.LogException("Failed to read JSON data.");
                        return null;
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                return null;
            }
        }

        public void SerializeToFile<T>(string path, T data)
        {
            try
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.Write(json);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
            }
        }

    }
}
