using FinalProject.Models;
using FinalProject.Exceptions;

namespace FinalProject.Services
{
    public class FurnitureManager
    {
        public FurnitureSet CreateSet(List<Chair> chairs, List<Table> tables, string material, string size, int chairsAmount)
        {
            Table? table = tables.FirstOrDefault(t => t.Material == material && t.Size == size);
            if (table == null)
            {
                throw new FurnitureShortageException($"No table found with material {material} and size {size}.");
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

            return new FurnitureSet
            {
                Name = $"{material} Set",
                Table = table,
                Chairs = selectedChairs
            };
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

                FurnitureSet set = new FurnitureSet
                {
                    Name = $"{material} Set",
                    Table = table,
                    Chairs = matchingChairs
                };

                sets.Add(set);

                remainingTables.Remove(table);

                remainingChairs.RemoveAll(c => c.Material == material);
            }
            return sets;
        }
    }
}
