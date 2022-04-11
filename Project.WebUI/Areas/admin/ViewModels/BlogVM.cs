using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public BlogPicture BlogPicture { get; set; }
    }
}
