using CoffeeShop.Data.Model;
using CoffeeShop.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Service.IService
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenu();
        Task<List<MenuCategory>> GetMenuCategories();

        Task<GenericResponseVM<object>> TakeCustomersOrder(MenuCheckOutVM menuCheckOutVM);
    }
}
