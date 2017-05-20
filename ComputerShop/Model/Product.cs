using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Model
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int StockAmount { get; set; }

        public string Description { get; set; }
    }
}