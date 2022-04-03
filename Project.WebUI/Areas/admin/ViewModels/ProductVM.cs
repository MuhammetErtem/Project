using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
