using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Blog> ListBlog { get; set; }


    }
}
