using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Controller;
using ComputerShop.Model;
using ComputerShop.Model.Interfaces;
using Moq;

namespace ComputerShopTests.Mocks
{
    internal class ComputerShopDbContextMock : IComputerShopDbContext
    {
        private List<Finance> _finances;

        private List<Order> _orders;

        private List<Product> _products;

        public DbSet<Finance> Financies { get; }

        public DbSet<Order> Orders { get; }

        public DbSet<Product> Products { get; }

        public Order UnregisteredOrder { get; }

        public const string Product = "Macbook";

        public const int ProductAmountSold = 13;

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();

            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public ComputerShopDbContextMock()
        {
            var macbook = new Product
            {
                Description = Product,
                ID = 1,
                Name = Product,
                Price = 200_312,
                StockAmount = 4
            };
            var processor = new Product
            {
                Description = "Processor",
                ID = 2,
                Name = "Core i5",
                Price = 14_000,
                StockAmount = 22
            };
            var mouse = new Product
            {
                Description = "Mouse",
                ID = 3,
                Name = "Mouse A4",
                Price = 4000,
                StockAmount = 10
            };

            _finances = new List<Finance>
            {
                new Finance()
                {
                    Amount = 20_000,
                    ID = 1,
                    Name = ShopIncomeController.ShopIncomeName
                }
            };
            _orders = new List<Order>
            {
                new Order
                {
                    ID = 0,
                    IsFinished = false,
                    IsPaid = true,
                    Products = new List<Item>
                    {
                        new Item
                        {
                            Amount = 10,
                            ID = 0,
                            Product = mouse
                        },
                        new Item
                        {
                            Amount = 3,
                            ID = 2,
                            Product = macbook
                        }
                    }
                },
                new Order
                {
                    ID = 1,
                    IsFinished = false,
                    IsPaid = true,
                    Products = new List<Item>
                    {
                        new Item
                        {
                            Amount = 10,
                            ID = 0,
                            Product = macbook
                        },
                        new Item
                        {
                            Amount = 3,
                            ID = 2,
                            Product = processor
                        }
                    }
                }
            };

            UnregisteredOrder = new Order
            {
                ID = 3,
                IsFinished = false,
                IsPaid = true,
                Products = new List<Item>
                {
                    new Item
                    {
                        Amount = 44,
                        ID = 0,
                        Product = processor
                    }
                }
            };

            _products = new List<Product>
            {
                mouse, macbook, processor
            };

            Financies = GetQueryableMockDbSet(_finances);

            Orders = GetQueryableMockDbSet(_orders);

            Products = GetQueryableMockDbSet(_products);
        }
    }
}