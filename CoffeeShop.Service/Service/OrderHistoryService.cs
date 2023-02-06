using CoffeeShop.CommonUtilities;
using CoffeeShop.Data.Model;
using CoffeeShop.Repository.IRepository;
using CoffeeShop.Service.IService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service.Service
{
    public class OrderHistoryService : IOrderHistoryService
    {
        IConfiguration _config;
        IOrderHistoryRepository _orderHistoryRepository;
        ILoggerManager _loggerManager;
        public OrderHistoryService(IConfiguration config , IOrderHistoryRepository orderHistoryRepository , ILoggerManager loggerManager)
        {
            _config = config;
            _orderHistoryRepository = orderHistoryRepository;
            _loggerManager = loggerManager;
        }
        public Task<List<CustomerOrderDetailItems>> GetCustomerOrderDetailItems(long customerOrderDetailsID)
        {
            try
            {
                return _orderHistoryRepository.GetCustomerOrderDetailItems(customerOrderDetailsID);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("GetCustomerOrderDetailItems", ex);
                return null;
            }
        }

        public Task<List<CustomerOrderDetails>> GetCustomerOrderDetails()
        {
            try
            {
                return _orderHistoryRepository.GetCustomerOrderDetails();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("GetCustomerOrderDetails", ex);
                return null;
            }
        }

        public Task<List<CustomerOrderDetails>> GetCustomerOrderDetailsByDate(DateTime dateFrom , DateTime dateTo)
        {
            try
            {
                return _orderHistoryRepository.GetCutomerOrderDetailsByDate(dateFrom, dateTo);
            }catch(Exception ex)
            {
                _loggerManager.LogError("GetCutomerOrderDetailsByDate", ex);
                return null;
            }
        }
    }
}
