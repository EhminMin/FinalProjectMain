namespace FinalProject.Models
{
    public class FurnitureSet
    {

        public string Name { get; set; }
        public Table? Table { get; set; }
        public List<Chair> Chairs { get; set; } = new();

        public int ChairsCount => Chairs.Count;

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                if (Table != null)
                {
                    total += Table.Price;
                }

                foreach (Chair chair in Chairs)
                {
                    total += chair.Price;
                }
                return total;
            }
        }

        public FurnitureSet()
        {

        }
    }
}
