using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Slider")]
    public class Slider
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Slogan"), StringLength(50)]
        public string Slogan { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Başlık"), StringLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Açıklama"), StringLength(150)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası"), StringLength(150)]
        public string Picture { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Sayfa Adresi"), StringLength(150)]
        public string Link { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
    }
}
