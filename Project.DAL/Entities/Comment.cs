using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Comment")]
    public class Comment
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)"), Display(Name = "Adı Soyadı"), StringLength(50),Required(ErrorMessage = "Adı Soyadı Alanı Boş Geçilemez...")]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi"), StringLength(80), Required(ErrorMessage = "Mail Adresi Alanı Boş Geçilemez...")]
        public string MailAddress { get; set; }

        [Column(TypeName = "varchar(250)"), Display(Name = "Yorum"), StringLength(250), Required(ErrorMessage = "Yorum Alanı Boş Geçilemez...")]
        public string Commentary { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "IP No"), StringLength(20)]
        public string IPNo { get; set; }

        [Display(Name = "Blog")]

        public int? BlogID { get; set; }

        public Blog Blog { get; set; }
    }
}
