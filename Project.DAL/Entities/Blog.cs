using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Blog
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Başlık"), StringLength(50), Required(ErrorMessage = "Başlık Boş Geçilemez...")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Açıklama"), StringLength(150), Required(ErrorMessage = "Açıklama Boş Geçilemez...")]
        public string Description { get; set; }

        [Column(TypeName = "text"), Display(Name = "Blog Detayı"), Required(ErrorMessage = "Blog Detayı Boş Geçilemez...")]
        public string Detail { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Resim Dosyası"), StringLength(150)]
        public string Picture { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }

        [Display(Name = "Etkin")]
        public bool Enabled { get; set; }

        public ICollection<Comment> Comments { get; set; }


    }
}
