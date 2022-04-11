using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    [Table("Order")]
    public class Order
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Sipariş Numarası"), StringLength(20)]
        public string OrderNumber { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Adı Soyadı"), StringLength(50)]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "TC Kimlik/Vergi Numarası"), StringLength(50)]
        public string TaxNumber { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Vergi Dairesi"), StringLength(50)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "varchar(80)"), Display(Name = "Mail Adresi"), StringLength(80)]
        public string MailAddress { get; set; }

        [Column(TypeName = "varchar(100)"), Display(Name = "Teslimat Adresi"), StringLength(100)]
        public string DeliveryAddress { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Teslimat Şehri"), StringLength(50)]
        public string DeliveryCity { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Teslimat İlçesi"), StringLength(50)]
        public string DeliveryDistinct { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Zip Kodu"), StringLength(20)]
        public string DeliveryZipCode { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Telefon"), StringLength(20)]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(100)"), Display(Name = "Fatura Adresi"), StringLength(100)]
        public string BilingAddress { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Fatura Şehri"), StringLength(50)]
        public string BilingCity { get; set; }

        [Column(TypeName = "varchar(50)"), Display(Name = "Fatura İlçesi"), StringLength(50)]
        public string BilingDistinct { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Fatura Kodu"), StringLength(20)]
        public string BilingZipCode { get; set; }

        [Display(Name ="Ödeme Türü")]
        public EPayment Payment { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public EOrderStatus OrderStatus { get; set; }

        [Display(Name ="Sipariş Tarihi")]
        public DateTime RecDate { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "IP No"), StringLength(20)]
        public string IPNo { get; set; }

        [Display(Name = "Sipariş Detayları")]
        public ICollection<OrderDetail> OrderDetails { get; set; }

        [NotMapped]
        public bool DeliveryBilingSimilar { get; set; }
    }
}
