using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class SubCategoryVM
    {
        public SubCategory SubCategory { get; set; }
        public IEnumerable<Category> CategoriesList { get; set; }
    }
}
