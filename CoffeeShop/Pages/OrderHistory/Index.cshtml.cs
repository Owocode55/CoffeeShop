using CoffeeShop.Data.Model;
using CoffeeShop.Data.ViewModel;
using CoffeeShop.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeShop.Pages.OrderHistory
{
    public class IndexModel : PageModel
    {
        private readonly IOrderHistoryService _orderHistoryService;
        public IndexModel(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }
        [BindProperty]
        public List<CustomerOrderDetails> DisplayData { get; set; }
        public async Task OnGet()
        {
            DisplayData = await _orderHistoryService.GetCustomerOrderDetails();
        }


        [BindProperty]
        public Data.ViewModel.MenuCheckOutVM MenuCheckOutVM { get; set; }
        public async Task OnPost(GetCustomerDetailsByDateVM getCustomerDetailsByDateVM)
        {
            DisplayData = await _orderHistoryService.GetCustomerOrderDetailsByDate(getCustomerDetailsByDateVM.DateFrom , getCustomerDetailsByDateVM.DateTo);
            
        }
    }
}
