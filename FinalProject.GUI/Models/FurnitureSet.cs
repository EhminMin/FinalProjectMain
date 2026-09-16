namespace FinalProject.GUI.Models
{
    public class FurnitureSet
    {
        public string Name { get; set; }
        public List<Furniture> Items { get; private set; } = new();

        public Furniture this[int index]
        {
            get
            {
                if (index < 0 || index >= Items.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return Items[index];
            }
            set
            {
                if (index < 0 || index >= Items.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                Items[index] = value;
            }
        }

        public int ChairsCount => Items.OfType<Chair>().Count();

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (Furniture item in Items)
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
            Items.Add(item);
        }

        public IReadOnlyList<Furniture> GetAllFurniture()
        {
            return Items.AsReadOnly();
        }

        public void RemoveFurniture(Furniture item)
        {
            Items.Remove(item);
        }

        public void RemoveFurnitureAt(int index)
        {
            if (index < 0 || index >= Items.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            Items.RemoveAt(index);
        }
    }
}
