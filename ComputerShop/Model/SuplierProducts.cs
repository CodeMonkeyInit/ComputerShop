using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model.Interfaces;

namespace ComputerShop.Model
{
    public class SuplierProducts : ISuplierProducts
    {
        public IEnumerable<Product> Products { get; }

        public SuplierProducts(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
