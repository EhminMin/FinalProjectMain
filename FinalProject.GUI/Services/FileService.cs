using FinalProject.GUI.Interfaces;
using FinalProject.GUI.Models;

namespace FinalProject.GUI.Services
{
    public class FileService : ISaveLoad
    {
        public void Save(string path, List<FurnitureSet> sets)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (FurnitureSet set in sets)
                {
                    var table = set.GetAllFurniture().OfType<Table>().FirstOrDefault();

                    sw.WriteLine($"Set: {set.Name}");

                    if (table != null)
                    {
                        sw.WriteLine($"Table size: {table.Width} x {table.Depth}");
                        sw.WriteLine($"Table material: {table.Material}");
                    }

                    sw.WriteLine($"Chairs count: {set.ChairsCount}");
                    sw.WriteLine($"Total price: {set.TotalPrice}\n");
                }
            }
        }

        public List<FurnitureSet> Load(string path)
        {
            throw new NotImplementedException("FileService supports only export.");
        }
    }
}