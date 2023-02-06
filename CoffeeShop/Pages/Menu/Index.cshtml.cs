using CoffeeShop.Data.ViewModel;
using CoffeeShop.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CoffeeShop.Pages.Menu
{
    public class IndexModel : PageModel
    {
        
        private readonly IMenuService _menuService;
        public IndexModel(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [BindProperty]
        public Data.ViewModel.GetAllMenuVM DisplayData { get; set; }
        public async Task OnGet()
        {
            DisplayData = new Data.ViewModel.GetAllMenuVM();            
            DisplayData.CategoryList= await _menuService.GetMenuCategories();
            DisplayData.MenuList = await _menuService.GetMenu();
        }

        [BindProperty]
        public Data.ViewModel.MenuCheckOutVM MenuCheckOutVM { get; set; }
        public async  Task<JsonResult>  OnPost(MenuCheckOutVM data)
        {
            var resp = await _menuService.TakeCustomersOrder(data);
            return new JsonResult(resp);
            
        }
       
    }
}
