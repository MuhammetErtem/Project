using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public Blog Blog { get; set; }
        public BlogPicture BlogPicture { get; set; }

    }
}
