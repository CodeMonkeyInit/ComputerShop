using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerShop.Model
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int Amount { get; set; }

        public Item(int productID, int amount)
        {
            ProductID = productID;
            Amount = amount;
        }

        public Item() { }
    }
}
