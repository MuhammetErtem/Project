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
        [Column(TypeName = "varchar(150)"), Display(Name = "Ürün Resmi"), StringLength(150), Required(ErrorMessage = "Ürün Resmi Boş Geçilemez...")]
        public string Path { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
