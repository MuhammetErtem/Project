using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project.DAL.Entities
{
    [Table("Animal")]
    public class Animal
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)"), Display(Name = "Hayvan Adı"), StringLength(100), Required(ErrorMessage = "Hayvan Adı Boş Geçilemez...")]
        public string Name { get; set; }

        [Column(TypeName = "text"), Display(Name = "Hayvan Açıklaması"), Required(ErrorMessage = "Hayvan Açıklaması Boş Geçilemez..."), StringLength(150)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Sahiplendirecek Kişinin Adı"), Required(ErrorMessage = "Sahiplendirecek Kişinin Adı Boş Geçilemez...")]
        public string Information { get; set; }
        [Column(TypeName = "varchar(11)"), Display(Name = "Sahiplendirecek Kişinin Telefon Numarası"), Required(ErrorMessage = "Sahiplendirecek Kişinin Telefon Numarası Boş Geçilemez...")]
        public string Number { get; set; }

        public List<AnimalPicture> AnimalPictures { get; set; }

        [Display(Name = "Etkin")]
        public bool Enabled { get; set; }
    }
}
