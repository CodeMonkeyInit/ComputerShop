using System.Collections.Generic;

namespace ComputerShop.Model
{
    public interface ISuplierProducts
    {
        IEnumerable<Product> Products { get; }
    }
}