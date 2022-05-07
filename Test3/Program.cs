using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace Test3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CreateDB();
            PopulatingDatabase();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        public static void CreateDB()
        {
            using var dbContext = new ApplicationDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        public static void PopulatingDatabase()
        {
            using var dbContext = new ApplicationDbContext();

            var order1 = new Order
            {
                Date = new DateTime(2021, 3, 24),
                NumberOrders = 1,
                FullNameClients = "Филип Николай Валерьевич",
                TotalAmount = 124.5M,
                ProductList = "1, 2, 3, 4"
            };
            var order2 = new Order
            {
                Date = new DateTime(2021, 3, 24),
                NumberOrders = 2,
                FullNameClients = "Галкин Виктор Бориславович",
                TotalAmount = 145.5M,
                ProductList = "1, 3, 4"
            };
            var order3 = new Order
            {
                Date = new DateTime(2021, 3, 25),
                NumberOrders = 3,
                FullNameClients = "Зверенцов Олег Самойлович",
                TotalAmount = 15M,
                ProductList = "4"
            };
            var product1 = new Product
            {
                Price = 15M,
                Quantity = 3,
                Value = 45M,
            };
            var product2 = new Product
            {
                Price = 20M,
                Quantity = 4,
                Value = 80M,
            };
            var product3 = new Product
            {
                Price = 102M,
                Quantity = 1,
                Value = 102M,
            };
            var product4 = new Product
            {
                Price = 15M,
                Quantity = 5,
                Value = 75M,
            };
            dbContext.Add(order1);
            dbContext.Add(order2);
            dbContext.Add(order3);
            dbContext.Add(product1);
            dbContext.Add(product2);
            dbContext.Add(product3);
            dbContext.Add(product4);

            dbContext.SaveChanges();
        }
    }
}