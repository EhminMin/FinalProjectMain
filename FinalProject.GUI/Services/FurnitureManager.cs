using FinalProject.GUI.Models;
using FinalProject.GUI.Exceptions;

namespace FinalProject.GUI.Services
{
    public class FurnitureManager
    {
        public FurnitureSet CreateSet(List<Chair> chairs, List<Table> tables, string material, double width, double depth, int chairsAmount)
        {
            Table? table = tables.FirstOrDefault(t => t.Material == material && t.Width == width && t.Depth == depth);
            if (table == null)
            {
                throw new FurnitureShortageException($"No table found with material {material} and size {width}x{depth}.");
            }

            List<Chair> selectedChairs = chairs.Where(c => c.Material == material).Take(chairsAmount).ToList();

            if (selectedChairs.Count < chairsAmount)
            {
                throw new FurnitureShortageException($"Not enough chairs found with material {material}");
            }

            tables.Remove(table);
            foreach (var chair in selectedChairs)
            {
                chairs.Remove(chair);
            }

            FurnitureSet newSet  = new FurnitureSet{Name = $"{material} Set"};
            newSet.AddFurniture(table);
            foreach (var chair in selectedChairs)
            {
                newSet.AddFurniture(chair);
            }

            return newSet;
        }

        public List<FurnitureSet> CreateRemainingSets(List<Chair> chairs, List<Table> tables)
        {
            List<FurnitureSet> sets = new List<FurnitureSet>();

            List<Table> remainingTables = tables.ToList();
            List<Chair> remainingChairs = chairs.ToList();

            var materials = remainingTables.Select(t => t.Material).Distinct().ToList();

            foreach (string material in materials)
            {
                Table? table = remainingTables.FirstOrDefault(t => t.Material == material);
                List<Chair> matchingChairs = remainingChairs.Where(c => c.Material == material).ToList();

                if(table == null || matchingChairs.Count == 0)
                {
                    continue;
                }

                FurnitureSet set = new FurnitureSet{Name = $"{material} Set"};
                set.AddFurniture(table);
                foreach (var chair in matchingChairs)
                {
                    set.AddFurniture(chair);
                }

                sets.Add(set);

                remainingTables.Remove(table);
                remainingChairs.RemoveAll(c => c.Material == material);
            }
            return sets;
        }
    }
}
