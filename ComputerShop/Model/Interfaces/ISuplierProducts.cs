using System.Collections.Generic;

namespace ComputerShop.Model.Interfaces
{
    public interface ISuplierProducts
    {
        IEnumerable<Product> Products { get; }
    }
}