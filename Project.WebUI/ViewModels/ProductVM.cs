using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class ProductVM
    {
        public IEnumerable<Product> SimilarProducts { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Product> ListProduct { get; set; }

        public ProductPicture ProductPicture { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public Brand Brand { get; set; }

    }
}
