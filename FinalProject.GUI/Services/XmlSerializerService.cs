using FinalProject.GUI.Models;
using FinalProject.GUI.Interfaces;
using System.Xml.Serialization;

namespace FinalProject.GUI.Services
{
    public class XmlSerializerService : ISaveLoad
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
                    XmlSerializer serializer = new XmlSerializer(typeof(List<FurnitureSet>));
                    var data = serializer.Deserialize(sr) as List<FurnitureSet>;

                    if (data == null)
                    {
                        Logger.LogException("Failed to read XML data.");
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
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<FurnitureSet>));
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
