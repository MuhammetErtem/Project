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

        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MinLength(5, ErrorMessage = "{0} 5 karakterden az olamaz."), MaxLength(50, ErrorMessage = "{0} 50 karakterden fazla olamaz.")]
        [Column(TypeName = "varchar(50)"), Display(Name = "Başlık")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası"), StringLength(150)]
        public string Picture { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Column(TypeName = "varchar(150)"), Display(Name = "Sayfa Adresi"), StringLength(150)]
        public string Link { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "Etkin")]
        public bool Enabled { get; set; }
    }
}
