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
            };
            var order2 = new Order
            {
                Date = new DateTime(2021, 3, 24),
                NumberOrders = 2,
                FullNameClients = "Галкин Виктор Бориславович",
                TotalAmount = 145.5M,
            };
            var order3 = new Order
            {
                Date = new DateTime(2021, 3, 25),
                NumberOrders = 3,
                FullNameClients = "Зверенцов Олег Самойлович",
                TotalAmount = 15M,
            };
            var product1 = new Product
            {
                Price = 15M,
                Quantity = 3,
            };
            var product2 = new Product
            {
                Price = 20M,
                Quantity = 4,
            };
            var product3 = new Product
            {
                Price = 102M,
                Quantity = 1,
            };
            var product4 = new Product
            {
                Price = 15M,
                Quantity = 5,
            };

            order1.Product=product1;
            order2.Product=product2;
            order3.Product=product3;

            dbContext.Add(order1);
            dbContext.Add(order2);
            dbContext.Add(order3);

            dbContext.SaveChanges();
        }
    }
}