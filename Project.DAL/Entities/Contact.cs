using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Contact")]
    public class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Adı Soyadı"), StringLength(50)]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi"), StringLength(80)]
        public string MailAddress { get; set; }

        [Column(TypeName = "varchar(100)"), Display(Name = "Mesajın Konusu"), StringLength(100)]
        public string Subject { get; set; }

        [Column(TypeName = "varchar(250)"), Display(Name = "Mesaj"), StringLength(250)]
        public string Message { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime RecDate { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "IP No"), StringLength(20)]
        public string IPNo { get; set; }
    }
}
