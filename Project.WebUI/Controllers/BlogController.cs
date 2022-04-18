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
        SqlRepo<Comment> repoComment;
        public BlogController(SqlRepo<Blog> _repoBlog, SqlRepo<Comment> _repoComment)
        {
            repoBlog = _repoBlog;
            repoComment = _repoComment;
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
        public IActionResult Detail(BlogVM model, int id)
        {
            Blog blog = repoBlog.GetAll().FirstOrDefault(x => x.ID == id) ?? null;
            if (model.Comment != null)
            {
                repoComment.Add(model.Comment);
                string[] mailto = new string[] { model.Comment.MailAddress };
                
            }
            else
            {
                if (blog != null)
                {
                    BlogVM blogVM = new BlogVM
                    {

                        PostComment = repoComment.GetAll().OrderByDescending(p => p.ID),
                        Blog = blog,
                    };
                    return View(blogVM);
                }
            }
            return RedirectToAction("Index");
        }
    }
}