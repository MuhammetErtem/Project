using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("SubCategory")]
    public class SubCategory
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name ="Alt Kategori Adı"),StringLength(30),Required(ErrorMessage ="Alt Kategori Boş Geçilemez...")]
        public string Name { get; set; }

        [Display(Name = "Kategori")]
        public int? CategoryID { get; set; }

        public Category Category { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
