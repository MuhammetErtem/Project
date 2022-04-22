using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("City")]
    public class City
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name = "Şehir Adı"),StringLength(30),Required(ErrorMessage ="Şehir Boş Geçilemez...")]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
