using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.ViewModel
{
    public class MenuCheckOutVM
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public List<OrderVM>? OrderDetails { get; set; }

    }

    public class MenuCheckOutCustDetailsVM
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public double OrderAmount { get; set; }
        public double DeliveryFee { get; set; }
        public double TotalAmount { get; set; }
        public string? OrderNumber { get; set; }

    }

    public class OrderVM
    {
        public string? Name { get; set; }
        public long ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
