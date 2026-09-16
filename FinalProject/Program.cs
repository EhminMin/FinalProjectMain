using FinalProject.Models;
using FinalProject.Services;

namespace FinalProject
{
    public class Program
    {
        public static void Main()
        {
            {
                try
                {
                    JsonSerializerService jsonService = new JsonSerializerService();
                    FurnitureData? data = jsonService.DeserializeFromFile(Path.Combine("input", "furniture.json"));

                    FurnitureManager manager = new FurnitureManager();

                    FurnitureSet firstSet = manager.CreateSet(
                        data.Chairs,
                        data.Tables,
                        "Дерево",
                        "120x80",
                        2);

                    List<FurnitureSet> remainingSets = manager.CreateRemainingSets(data.Chairs, data.Tables);

                    string set1Path = Path.Combine("..", "..", "..", "output", "set1.txt");
                    string set2Path = Path.Combine("..", "..", "..", "output", "set2.txt");

                    FileService.WriteSetToFile(set1Path, firstSet);
                    FileService.WriteSetsToFile(set2Path, remainingSets);

                    Console.WriteLine($"Set created: {firstSet.Name}");
                    Console.WriteLine($"Price: {firstSet.TotalPrice}\n");

                    foreach (var set in remainingSets)
                    {
                        Console.WriteLine($"Remaining set created: {set.Name}");
                        Console.WriteLine($"Price: {set.TotalPrice}\n");
                    }

                    jsonService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set1Json.json"), firstSet);
                    jsonService.SerializeToFile(Path.Combine("..", "..", "..", "output", "set2Json.json"),
                        remainingSets);


                }
                catch (Exception ex)
                {
                    Logger.LogException(ex.Message);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
