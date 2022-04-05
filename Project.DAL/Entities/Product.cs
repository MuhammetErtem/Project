using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project.DAL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı"), StringLength(100), Required(ErrorMessage = "Ürün Boş Geçilemez...")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Ürün Açıklaması"), StringLength(150)]
        public string Description { get; set; }
        [Column(TypeName = "text"), Display(Name = "Ürün Detayı")]
        public string Detail { get; set; }

        [Column(TypeName ="decimal(18,2)"), Display(Name = "Satış Fiyatı")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "İndirimsiz Fiyatı")]
        public decimal DiscountPrice { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        public List<ProductPicture> ProductPictures { get; set; }

        [Display(Name = "Marka")]

        public int? BrandID { get; set; }
        [Display(Name = "Marka")]

        public Brand Brand { get; set; }

        public int? SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }

    }
}
