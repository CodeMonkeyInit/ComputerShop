using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Controller
{
    class ShopIncomeController
    {
        public void AddMoney(double amount)
        {
            using (var dbContext = new ComputerShopDbContext())
            {
                Finance shopIncome = dbContext.Financies.First(finance => finance.Name == "Shop Income");

                shopIncome.Amount += amount;
                dbContext.SaveChanges();
            }
        }
    }
}
