using CoffeeShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository.IRepository
{
    public interface IOrderHistoryRepository
    {
        Task<List<CustomerOrderDetails>> GetCustomerOrderDetails();
        Task<List<CustomerOrderDetailItems>> GetCustomerOrderDetailItems(long customerOrderDetailsID);
        Task<List<CustomerOrderDetails>> GetCutomerOrderDetailsByDate(DateTime dateFrom, DateTime dateTo);

    }
}
