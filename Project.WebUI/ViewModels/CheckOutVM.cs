using Project.DAL.Entities;
using Project.WebUI.Models;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class CheckOutVM
    {
        public Order Order { get; set; }
        public List<Cart> Carts { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
