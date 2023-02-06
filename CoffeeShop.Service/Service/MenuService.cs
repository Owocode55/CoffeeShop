using CoffeeShop.CommonUtilities;
using CoffeeShop.Data.Model;
using CoffeeShop.Data.ViewModel;
using CoffeeShop.Repository.IRepository;
using CoffeeShop.Service.IService;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoffeeShop.Service.Service
{
    public class MenuService : IMenuService
    {
        IConfiguration _config;
        IMenuRepository _menuRepository;
        ILoggerManager _loggerManager;
        public MenuService(IConfiguration config, IMenuRepository menuRepository , ILoggerManager loggerManager)
        {
            _config = config;
            _menuRepository = menuRepository;
            _loggerManager = loggerManager;
        }
        public Task<List<Menu>> GetMenu()
        {
            try
            {
                return _menuRepository.GetMenu();
            }catch(Exception ex)
            {
                _loggerManager.LogError("Error getting Menu items" , ex);
                return null;
            }
            
        }

        public Task<List<MenuCategory>> GetMenuCategories()
        {
            try
            {
                return _menuRepository.GetMenuCategories();
            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Error getting Menu items", ex);
                return null;
            }
            
        }



        public async Task<GenericResponseVM<object>> TakeCustomersOrder(MenuCheckOutVM menuCheckOutVM)
        {
            try
            {
                _loggerManager.LogInformation($"Take Customer request ---  {JsonConvert.SerializeObject(menuCheckOutVM)}");
                var orderItemList = new List<CustomerDetailsOrderItems>();
                double totalPrice = 0;
                var menuList = await _menuRepository.GetMenu();

                if (menuCheckOutVM.OrderDetails == null)
                    return new GenericResponseVM<object>
                    {
                        IsSuccessful = false,
                        ResponseMessage = "Invalid request"
                    };

                foreach (var order in menuCheckOutVM.OrderDetails)
                {
                    var menu = menuList.FirstOrDefault(m => m.ID == order.ProductID);

                    if (menu == null)
                        return new GenericResponseVM<object>
                        {
                            IsSuccessful = false,
                            ResponseMessage = "Menu item not found"
                        };

                    var orderItem = new CustomerDetailsOrderItems
                    {
                        ItemName = order.Name,
                        MenuID = menu.ID,
                        Quantity = order.Quantity,
                        TotalPrice = order.Quantity * menu.Price,
                        UnitPrice = menu.Price
                    };
                    totalPrice = totalPrice + orderItem.TotalPrice;
                    orderItemList.Add(orderItem);
                }

                var customerOrderDetails = new MenuCheckOutCustDetailsVM
                {
                    OrderNumber = Helper.GetOrderNumber(),
                    DeliveryFee = Convert.ToDouble(_config["DeliveryFee"]),
                    OrderAmount = totalPrice,
                    TotalAmount = totalPrice + Convert.ToDouble(_config["DeliveryFee"]),
                    Address = menuCheckOutVM.Address,
                    Email = menuCheckOutVM.Email,
                    Mobile = menuCheckOutVM.Mobile,
                    Name = menuCheckOutVM.Name,
                };
                var orderItemDatatable = Helper.ConvertToDataTable(orderItemList);

                var resp = await _menuRepository.CreateMenuOrder(customerOrderDetails, orderItemDatatable);

                if (resp < 0)
                {
                    switch (resp)
                    {
                        case 0:
                            return new GenericResponseVM<object>
                            {
                                IsSuccessful = false,
                                ResponseMessage = "Order number already exist"
                            };
                        default:
                            return new GenericResponseVM<object>
                            {
                                IsSuccessful = false,
                                ResponseMessage = "Unknown Exception"
                            };
                    }

                }

                return new GenericResponseVM<object>
                {
                    IsSuccessful = true,
                    ResponseMessage = "Order created successfully"
                };

            }
            catch (Exception ex)
            {
                _loggerManager.LogError("Error Taking Customer Order", ex);
                return new GenericResponseVM<object>
                {
                    IsSuccessful = false,
                    ResponseMessage = "Unknown Exception"
                };
            }
            
        }
    }
}
