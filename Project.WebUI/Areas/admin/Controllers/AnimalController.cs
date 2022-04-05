using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace Project.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class AnimalController : Controller
    {
        SqlRepo<Animal> repoAnimal;
        public AnimalController(SqlRepo<Animal> _repoAnimal)
        {
            repoAnimal = _repoAnimal;
        }

        public IActionResult Index()
        {
            return View(repoAnimal.GetAll().OrderByDescending(o=>o.ID));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal model)
        {
            if (ModelState.IsValid)
            {

                repoAnimal.Add(model);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(repoAnimal.GetBy(x => x.ID == id));
        }

        [HttpPost]
        public IActionResult Update(Animal model)
        {
            if (ModelState.IsValid)
            {
                repoAnimal.Update(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            repoAnimal.Remove(repoAnimal.GetBy(x => x.ID == id));
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
    }
}
