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

        [Column(TypeName = "text"), Display(Name = "Hayvan Açıklaması"), StringLength(150)]
        public string Description { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Sahiplendirecek Kişinin Adı")]
        public string Information { get; set; }
        [Column(TypeName = "varchar(11)"), Display(Name = "Sahiplendirecek Kişinin Telefon Numarası")]
        public string Number { get; set; }
        public List<AnimalPicture> AnimalPictures { get; set; }
    }
}
