namespace FinalProject.Models
{
    public class Chair
    {
        public Chair(string material, decimal price)
        {
            Material = material;
            Price = price;
        }

        public string Material { get; set; }
        public decimal Price { get; set; }

        public Chair()
        {

        }
    }
}
