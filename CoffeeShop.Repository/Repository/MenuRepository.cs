using CoffeeShop.Data.Model;
using CoffeeShop.Data.ViewModel;
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
    public class MenuRepository : IMenuRepository
    {
        private readonly IDapper _dapper;

        public MenuRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public async Task<List<Menu>> GetMenu()
        {
            string sqlQuery  = @"Select * from Menu";
            return await _dapper.GetAll<Menu>(sqlQuery, null, commandType: CommandType.Text);
        }

        public async Task<List<MenuCategory>> GetMenuCategories()
        {
            string sqlQuery = @"select * from MenuCategory";
            return await _dapper.GetAll<MenuCategory>(sqlQuery, null, commandType: CommandType.Text);
        }

        public async Task<long> CreateMenuOrder(MenuCheckOutCustDetailsVM request, DataTable dataTable)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("OrderDetails", dataTable.AsTableValuedParameter("[dbo].[OrderDetailsType]"));
            dbPara.Add("TotalAmount", request.TotalAmount);
            dbPara.Add("OrderAmount", request.OrderAmount);
            dbPara.Add("DeliveryFee", request.DeliveryFee);
            dbPara.Add("Name", request.Name);
            dbPara.Add("Email", request.Email);
            dbPara.Add("Address", request.Address);
            dbPara.Add("Mobile", request.Mobile);
            dbPara.Add("OrderNumber", request.OrderNumber);
            dbPara.Add("DateCreated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            dbPara.Add("Resp", dbType: DbType.Int64, direction: ParameterDirection.Output);
            await _dapper.BulkInsert<int>(dataTable, dbPara, "[sp_CreateOrderRequest]");
            return dbPara.Get<long>("Resp");
        }

    }
}
