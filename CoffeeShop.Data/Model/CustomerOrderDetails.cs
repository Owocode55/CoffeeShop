using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.Model
{
    public class CustomerOrderDetails
    {
        public long ID { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public double OrderAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaymentOnDelivery { get; set; }
        public double DeliveryAmount { get; set; }
        public double TotalAmount { get; set; }
        public string? OrderNumber { get; set; }
    }
}
