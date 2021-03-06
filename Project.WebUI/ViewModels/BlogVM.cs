using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public Comment Comment { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Blog> ListBlog { get; set; }
        public IEnumerable<Comment> PostComment { get; set; }
    }
}
