using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Model
{
   public class CustomerOrderDetailItems
    {
        public long ID { get; set; }
        public long CustomerOrderDetailsID { get; set; }
        public string? OrderNumber { get; set; }
        public string? ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitePrice { get; set; }
        public double TotalAmount { get; set; }
    }
}
