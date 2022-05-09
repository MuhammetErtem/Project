using Project.BL.Repositories;
using Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.WebUI.Areas.admin.ViewModels;
using System.Linq;
using Project.WebUI.Tools;
using X.PagedList;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ContactController : Controller
    {
        SqlRepo<Contact> repoContact;
        public ContactController(SqlRepo<Contact> _repoContact)
        {
            repoContact = _repoContact;
        }

        public IActionResult Index(int? page)
        {
            return View(repoContact.GetAll().ToPagedList(page ?? 1, 10));
        }
        public IActionResult Read(int id)
        {
            return View(repoContact.GetBy(x => x.ID == id));
        }
        public IActionResult Delete(int id)
        {
            repoContact.Remove(repoContact.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}

