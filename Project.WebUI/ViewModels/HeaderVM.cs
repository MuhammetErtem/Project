using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class HeaderVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
