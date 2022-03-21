using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Product> LatestProducts { get; set; }
        public IEnumerable<Product> BestSellerProducts { get; set; }

    }
}
