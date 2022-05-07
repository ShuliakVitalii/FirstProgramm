using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int NumberOrders { get; set; }

        public string? FullNameClients { get; set; }

        public decimal TotalAmount { get; set; }

        public string? ProductList { get; set; }
    }
}
