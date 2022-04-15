using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class BlogController : Controller
    {
        SqlRepo<Blog> repoBlog;
        public BlogController(SqlRepo<Blog> _repoBlog)
        {
            repoBlog = _repoBlog;
        }
        public IActionResult Index()
        {
            BlogVM blogVM = new BlogVM
            {
                ListBlog = repoBlog.GetAll().OrderByDescending(o => o.ID).Take(16),
            };
            return View(blogVM);

        }
    
        [Route("/blog/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Blog blog = repoBlog.GetAll().FirstOrDefault(x => x.ID == id) ?? null;
            if (blog != null)
            {
                BlogVM blogVM = new BlogVM
                {
                    Blog = blog,
                };
                return View(blogVM);
            }
            else return Redirect("/");
        }
    }
}