using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace FinalProject.GUI.Models
{
    [JsonDerivedType(typeof(Table), typeDiscriminator: "table")]
    [JsonDerivedType(typeof(Chair), typeDiscriminator: "chair")]
    [XmlInclude(typeof(Table))]
    [XmlInclude(typeof(Chair))]
    public abstract class Furniture
    {
        private string _material;
        private decimal _price;

        public string Material { 
            get 
            { 
                return _material; 
            } 
            set 
            { 
                _material = value.ToLower(); 
            } 
        }
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                _price = value;
            }
        }

        protected Furniture(string material, decimal price)
        {
            Material = material;
            Price = price;
        }

        protected Furniture() { }
    }
}
