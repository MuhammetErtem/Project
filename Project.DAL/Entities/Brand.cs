using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Brand")]
    public class Brand
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name = "Marka Adı"),StringLength(30),Required(ErrorMessage ="Marka Boş Geçilemez...")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
