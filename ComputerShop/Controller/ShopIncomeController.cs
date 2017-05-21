using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model.Interfaces;

[assembly:InternalsVisibleTo("ComputerShopTests")]
namespace ComputerShop.Controller
{
    public class ShopIncomeController
    {
        internal const string ShopIncomeName = "Shop Income";

        private readonly IComputerShopDbContext _dbContext;
        
        public ShopIncomeController(IComputerShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMoney(double amount)
        {
            Finance shopIncome = _dbContext.Financies.First(finance => finance.Name == ShopIncomeName);

            shopIncome.Amount += amount;
            _dbContext.SaveChanges();
        }
    }
}