namespace FinalProject.GUI.Models
{
    public class FurnitureSet
    {
        public string Name { get; set; }
        private List<Furniture> _furnitures = new();

        public int ChairsCount => _furnitures.OfType<Chair>().Count();

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (Furniture item in _furnitures)
                {
                    total += item.Price;
                }
                return total;
            }
        }

        public FurnitureSet()
        {
        }

        public void AddFurniture(Furniture item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null.");
            }
            _furnitures.Add(item);
        }

        public IReadOnlyList<Furniture> GetAllFurniture()
        {
            return _furnitures.AsReadOnly();
        }

        public void RemoveFurniture(Furniture item)
        {
            _furnitures.Remove(item);
        }

        public void RemoveFurnitureAt(int index)
        {
            if (index < 0 || index >= _furnitures.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            _furnitures.RemoveAt(index);
        }
    }
}
