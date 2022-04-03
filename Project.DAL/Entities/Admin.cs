using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Admin")]
    public class Admin
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar(30)"),Display(Name = "Adı Soyadı"),StringLength(30),Required(ErrorMessage ="Admin Adı Soyadı Boş Geçilemez...")]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi"), StringLength(80), Required(ErrorMessage = "Mail Adresi Boş Geçilemez..."),DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [Column(TypeName = "char(32)"), Display(Name = "Şifre"), StringLength(32), Required(ErrorMessage = "Şifre Boş Geçilemez...")]
        public string Password { get; set; }

        [Display(Name = "Son Giriş Tarihi")]
        public DateTime LastDate { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Son IP No"), StringLength(20)]
        public string LastIPNo { get; set; }

    }
}
