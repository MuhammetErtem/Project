using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public enum EPayment
    {
        [Display(Name = "Kredi Kartı")]
        KrediKartı=1,

        [Display(Name = "Havale")]
        Havale,

        [Display(Name = "Kapıda Ödeme")]
        KapıdaÖdeme
    }
}
