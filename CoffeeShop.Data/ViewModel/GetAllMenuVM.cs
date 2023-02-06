using CoffeeShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data.ViewModel
{
    public class GetAllMenuVM
    {
        public List<Menu> MenuList { get; set; }
        public List<MenuCategory> CategoryList {get;set;}
    }
}
