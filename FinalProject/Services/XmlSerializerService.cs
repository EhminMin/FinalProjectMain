using FinalProject.Models;
using System.Xml.Serialization;

namespace FinalProject.Services
{
    public class XmlSerializerService
    {
        public FurnitureData? DeserializeFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FurnitureData));
                    FurnitureData? data = serializer.Deserialize(sr) as FurnitureData;
                    if (data == null)
                    {
                        Logger.LogException("Failed to read XML data.");
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
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(sw, data);
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
