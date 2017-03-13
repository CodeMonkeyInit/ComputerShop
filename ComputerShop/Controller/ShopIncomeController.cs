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
        public void AddMoney(int amount)
        {
            using (var dbContext = new ComputerShopDbContext())
            {
                Finance shopIncome = dbContext.Financies.First(finance => finance.ID == 1);

                shopIncome.Amount += amount;
                dbContext.SaveChanges();
            }
        }
    }
}
