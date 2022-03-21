using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("BlogPicture")]
    public class BlogPicture
    {
        public int ID { get; set; }
        [Column(TypeName ="varchar(30)"),Display(Name = "Blog Adı"),StringLength(30),Required(ErrorMessage ="Blog İsim Alanı Boş Geçilemez...")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Blog Foroğrafı"), StringLength(150), Required(ErrorMessage = "Fotoğraf Alanı Boş Geçilemez...")]
        public string Path { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
