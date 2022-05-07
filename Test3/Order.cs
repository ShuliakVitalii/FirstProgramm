using System.ComponentModel.DataAnnotations.Schema;

namespace Test3
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int NumberOrders { get; set; }

        public string? FullNameClients { get; set; }

        public decimal TotalAmount { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
