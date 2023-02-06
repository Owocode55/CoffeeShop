using CoffeeShop.Data.Model;
using CoffeeShop.Repository.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository.Repository
{
    public class OrderHistoryRepository :IOrderHistoryRepository
    {
        private readonly IDapper _dapper;
        public OrderHistoryRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<CustomerOrderDetails>> GetCustomerOrderDetails()
        {
            string sqlQuery = @"select top 50 *  from [CustomerOrderDetails] Order By OrderDate desc";
            return await _dapper.GetAll<CustomerOrderDetails>(sqlQuery, null, commandType: CommandType.Text);
        }

        public async Task<List<CustomerOrderDetailItems>> GetCustomerOrderDetailItems(long customerOrderDetailsID)
        {
            string sqlQuery = @"select * from [dbo].[CustomerOrderDetailsItem] where CustomerOrderDetailsID = @CustomerOrderDetailsID";
            var dbPara = new DynamicParameters();
            dbPara.Add("CustomerOrderDetailsID", customerOrderDetailsID);
            return await _dapper.GetAll<CustomerOrderDetailItems>(sqlQuery, dbPara, commandType: CommandType.Text);
        }

        public async Task<List<CustomerOrderDetails>> GetCutomerOrderDetailsByDate(DateTime dateFrom , DateTime dateTo)
        {
            string sqlQuery = @"select * from CustomerOrderDetails where OrderDate >= @DateFrom and OrderDate <= @DateTo";
            var dbPara = new DynamicParameters();
            dbPara.Add("DateFrom", dateFrom);
            dbPara.Add("DateTo", dateTo);
            return await _dapper.GetAll<CustomerOrderDetails>(sqlQuery, dbPara, commandType: CommandType.Text);
        }
    }
}
