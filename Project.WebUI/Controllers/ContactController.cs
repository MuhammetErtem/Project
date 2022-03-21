using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Tools;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class ContactController : Controller
    {
        SqlRepo<Product> repoProduct;
        SqlRepo<Contact> repoContact;
        public ContactController(SqlRepo<Product> _repoProduct, SqlRepo<Contact> _repoContact)
        {
            repoProduct = _repoProduct;
            repoContact = _repoContact;
        }
        public IActionResult Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Contact = new Contact(),
                Products = repoProduct.GetAll().Include(i => i.ProductPictures).OrderBy(o => Guid.NewGuid()).Take(4)
            };
            return View(contactVM);
        }

        [HttpPost]
        public IActionResult Index(ContactVM model)
        {
            if(ModelState.IsValid)
            {
                repoContact.Add(model.Contact);
                string[] mailto = new string[] { model.Contact.MailAddress };
                GeneralTool.SendMail("smtp.gmail.com", 587, "denemeinfotech@gmail.com", "deneme1234", true, "denemeinfotech@gmail.com", mailto, model.Contact.Subject,"Bu mail kişiden geldi:"+model.Contact.MailAddress+" mesajı ise:"+ model.Contact.Message);
            }
            else
            {
                ViewBag.Mesaj = "Veriler uygun gönderilmedi...";    
            }
            return RedirectToAction("Index");
        }
    }
}
