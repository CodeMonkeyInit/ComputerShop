using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Model
{
    class Finance
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }
    }
}
