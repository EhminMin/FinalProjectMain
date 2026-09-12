using FinalProject.Models;

namespace FinalProject.Services
{
    public class FileService
    {
        public static void WriteSetToFile(string path, FurnitureSet set)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine($"Set: {set.Name}\n" +
                    $" Table size: {set.Table?.Size}\n" +
                    $" Table material: {set.Table?.Material}\n" +
                    $" Chairs count: {set.ChairsCount}\n" +
                    $" Total price: {set.TotalPrice}\n");
            }
        }

        public static void WriteSetsToFile(string path, List<FurnitureSet> sets)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (FurnitureSet set in sets)
                {
                    sw.WriteLine($"Set: {set.Name}\n" +
                    $" Table size: {set.Table?.Size}\n" +
                    $" Table material: {set.Table?.Material}\n" +
                    $" Chairs count: {set.ChairsCount}\n" +
                    $" Total price: {set.TotalPrice}\n");
                }
            }
        }
    }
}
