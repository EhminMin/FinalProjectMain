namespace FinalProject.GUI.Models
{
    public class Table : Furniture
    {
        private double _width;
        private double _depth;

        public double Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be greater than zero.");
                }
                _width = value;
            }
        }

        public double Depth
        {
            get { return _depth; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Depth must be greater than zero.");
                }
                _depth = value;
            }
        }

        public Table(string material, decimal price, double width, double depth) : base(material, price)
        {
            Width = width;
            Depth = depth;
        }

        public Table() : base()
        {

        }
    }
}
