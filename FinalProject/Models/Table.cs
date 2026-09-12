namespace FinalProject.Models
{
    public class Table
    {
        public Table(string size, string material, decimal price)
        {
            Size = size;
            Material = material;
            Price = price;
        }

        public string Size { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }

        public Table()
        {

        }

    }
}
