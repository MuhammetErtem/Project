using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfCommerce.DAL.Entities
{
    public enum ECurrency
    {
        [Display(Name = "Türk Lirası")]
        TL=1,

        [Display(Name = "Euro")]
        EUR,

        [Display(Name = "Amerikan Doları")]
        USD,

        [Display(Name = "İngiliz Sterlini")]
        GBP
    }
}
