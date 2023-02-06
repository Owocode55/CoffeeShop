using CoffeeShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service.IService
{
    public interface IOrderHistoryService
    {
        Task<List<CustomerOrderDetails>> GetCustomerOrderDetails();
        Task<List<CustomerOrderDetailItems>> GetCustomerOrderDetailItems(long customerOrderDetailsID);
        Task<List<CustomerOrderDetails>> GetCustomerOrderDetailsByDate(DateTime dateFrom, DateTime dateTo);
    }
}
