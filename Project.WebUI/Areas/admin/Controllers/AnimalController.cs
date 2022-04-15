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
        SqlRepo<AnimalPicture> repoAnimalPicture;
        public AnimalController(SqlRepo<Animal> _repoAnimal, SqlRepo<AnimalPicture> _repoAnimalPicture)
        {
            repoAnimal = _repoAnimal;
            repoAnimalPicture = _repoAnimalPicture;
        }

        public IActionResult Index()
        {
            return View(repoAnimal.GetAll().OrderByDescending(o => o.ID));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AnimalVM model)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Any())
                {
                    string animalPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "animal");
                    if (!Directory.Exists(animalPath)) Directory.CreateDirectory(animalPath);
                    using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "animal", Request.Form.Files["Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["Picture"].CopyTo(stream);
                    }
                    model.AnimalPicture.Path = "/img/animal/" + Request.Form.Files["AnimalPicture"].FileName;
                }

                repoAnimal.Add(model.Animal);

            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            AnimalVM animalVM = new AnimalVM
            {
                Animal = repoAnimal.GetBy(x => x.ID == id),
            };
            return View(animalVM);
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
