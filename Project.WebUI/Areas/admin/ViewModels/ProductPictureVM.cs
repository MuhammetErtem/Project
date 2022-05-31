using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class ProductPictureVM
    {
        public Product Product { get; set; }
        public ProductPicture ProductPicture { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductPicture> ProductPictures { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
