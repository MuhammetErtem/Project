using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("AnimalPicture")]
    public class AnimalPicture
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(150)"), Display(Name = "Görsel Dosyası"), StringLength(150), Required(ErrorMessage = "Görsel Boş Geçilemez...")]
        public string Picture { get; set; }
        public int AnimalID { get; set; }
        public Animal Animal { get; set; }
    }
}
