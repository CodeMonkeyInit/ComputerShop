using ComputerShop.Controller;
using ComputerShop.Interfaces;
using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerShop.View
{
    class CashierUserInterface : IUserInterface
    {
        private ShopIncomeController incomeController;

        protected void UserInputHandler(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    AddMoney();
                    break;

                case ConsoleKey.D2:
                    PrintReciept();
                    break;
            }
        }

        protected void AddMoney()
        {
            bool moneyRecieved = false;
            string moneyAmountUserInput = String.Empty;
            double moneyAmount = double.MinValue;
            while (!moneyRecieved)
            {
                Console.WriteLine("Ввести кол-во денег которые вы получили от покупателя(или введите ноль чтобы выйти): ");
                moneyAmountUserInput = Console.ReadLine();
                moneyRecieved = double.TryParse(moneyAmountUserInput, out moneyAmount);
                
                if (moneyRecieved)
                {
                    if (moneyAmount < 0)
                    {
                        moneyRecieved = false;
                        Console.WriteLine("Число не может быть отрицательным!");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте еще раз!");
                }
            }

            if (moneyAmount > 0)
            {
                incomeController.AddMoney(moneyAmount);
                Console.WriteLine("Операция заверщена успешно. Нажмите любую кнопку для продолжения");
                Console.ReadKey(false);
            }
        }

        protected Order ChooseOrder()
        {
            OrdersController ordersController = new OrdersController();
            IEnumerable<Order> orders = ordersController.Orders;
            Order choosenOrder = null;
            int chosenOrderId;

            foreach(Order order in orders.Where(o => o.IsFinished == false))
            {
                Console.WriteLine(order);
            }

            if (orders.Count() == 0)
            {
                Console.WriteLine("Нет заказов!Нажмите любую кнопку для продолжения.");
                Console.ReadKey(true);
            }
            else
            {
                bool userInputCorrect = false;
                while (!userInputCorrect)
                {
                    Console.WriteLine("Введите id нужного заказа");
                    chosenOrderId = Convert.ToInt32(Console.ReadLine());
                    choosenOrder = orders.FirstOrDefault(o => o.ID == chosenOrderId);

                    if (choosenOrder != null)
                    {
                        userInputCorrect = true;
                    }
                    else
                    {
                        Console.WriteLine("ID введен неверно! Повторите попытку");
                        Console.ReadKey(true);
                    }
                    
                }
            }
            return choosenOrder;
        }

        protected void PrintReciept()
        {
            Order chosenOrder = ChooseOrder();
            SaleRecieptController saleRecieptController;

            if (chosenOrder != null)
            {
                saleRecieptController = new SaleRecieptController();
                Console.WriteLine(saleRecieptController.Form(chosenOrder));
                Console.ReadKey(true);
            }
        }

        public void Render()
        {
            ConsoleKeyInfo userInput;

            do
            {
                Console.Clear();
                Console.WriteLine("Нажмите кнопку:");
                Console.WriteLine("1 - для того чтобы добавить деньги");
                Console.WriteLine("2 - для того чтобы распечатать чек");
                Console.WriteLine("Escape - для того чтобы выйти");

                userInput = Console.ReadKey(true);
                UserInputHandler(userInput.Key);

            } while (userInput.Key != ConsoleKey.Escape);

        }

        public CashierUserInterface()
        {
            incomeController = new ShopIncomeController();
        }
    }
}
