using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Model
{
    class Item
    {
        [Key]
        public int ID { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }

        public Item(int productID, int amount)
        {
            ProductID = productID;
            Amount = amount;
        }

        public Item() { }
    }
}
