using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class AnimalVM
    {
        public Animal Animal { get; set; }
        public AnimalPicture AnimalPicture { get; set; }
    }
}
