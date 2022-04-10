using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("ProductPicture")]
    public class ProductPicture 
    {
        public int ID { get; set; }
        [Column(TypeName ="varchar(30)"),Display(Name ="Kategori Adı"),StringLength(30),Required(ErrorMessage ="Ürün Resim Adı Boş Geçilemez...")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Kategori Adı"), StringLength(150), Required(ErrorMessage = "Ürün Resmi Boş Geçilemez...")]
        public string Path { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
