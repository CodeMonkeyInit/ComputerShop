using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Model
{
    class Order
    {
        public int ID { get; set; }
        
        public List<Item> Products { get; set; }
        
        public double Total { get; set; }

        public DateTime Time { get; set; }

        public bool IsPaid { get; set; }

        public Order()
        {
            Products = new List<Item>();
            Time = DateTime.Now;
        }
    }
}
