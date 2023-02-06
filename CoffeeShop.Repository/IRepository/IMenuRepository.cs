using CoffeeShop.Data.Model;
using CoffeeShop.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Repository.IRepository
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetMenu();
        Task<List<MenuCategory>> GetMenuCategories();
        Task<long> CreateMenuOrder(MenuCheckOutCustDetailsVM request, DataTable dataTable);
    }
}
