using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public enum EOrderStatus
    {
        [Display(Name = "Hazırlanıyor")]
        Hazırlanıyor=1,

        [Display(Name = "Paketlendi")]
        Paketlendi,

        [Display(Name = "Kargoya Verildi")]
        KargoyaVerildi,

        [Display(Name = "Teslim Edildi")]
        TeslimEdildi,

        [Display(Name = "İptal Edildi")]
        İptalEdildi,
    }
}
