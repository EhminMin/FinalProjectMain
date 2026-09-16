using FinalProject.GUI.Models;
using System.Text.Json;
using FinalProject.GUI.Interfaces;

namespace FinalProject.GUI.Services
{
    public class JsonSerializerService : ISaveLoad
    {
        public List<FurnitureSet> Load(string path)
        {
            try
            {
                if(!File.Exists(path))
                {
                    return new List<FurnitureSet>();
                }

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string json = sr.ReadToEnd();
                    var data = JsonSerializer.Deserialize<List<FurnitureSet>>(json);

                    if (data == null)
                    {
                        Logger.LogException("Failed to read JSON data.");
                        return new List<FurnitureSet>();
                    }
                    return data;
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                return new List<FurnitureSet>();
            }
        }

        public void Save(string path, List<FurnitureSet> data)
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
