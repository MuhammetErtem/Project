using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using X.PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

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

        public IActionResult Index(int? page)
        {
            return View(repoAnimal.GetAll().ToPagedList(page ?? 1, 10));
        }

        public IActionResult Create()
        {
            return View(new AnimalVM());
        }

        [HttpPost]
        public IActionResult Create(AnimalVM model)
        {
            if (ModelState.IsValid) repoAnimal.Add(model.Animal);
            return View();
        }
        public IActionResult AnimalPictures()
        {
            AnimalVM animalVM = new AnimalVM()
            {
                Animal = new Animal { Enabled = true },
                Animals = repoAnimal.GetAll(),
                AnimalPicture = new AnimalPicture(),
            };
            return View(animalVM);

        }

        [HttpPost]
        public async Task<IActionResult> AnimalPictures(AnimalVM model)
        {
            var dosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "animal");
            var imageList = Directory.GetFiles(dosyaYolu);
            foreach (var image in imageList)
            {
                if (Request.Form.Files.Any())
                {
                    string animalPicture = dosyaYolu;
                    if (!Directory.Exists(animalPicture)) Directory.CreateDirectory(animalPicture);
                    using (var dosyaAkisi = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "animal", Request.Form.Files["AnimalPicture.Picture"].FileName), FileMode.Create))
                    {
                        Request.Form.Files["AnimalPicture.Picture"].CopyTo(dosyaAkisi);
                    }

                    model.AnimalPicture.Picture = "/img/animal/" + Request.Form.Files["AnimalPicture.Picture"].FileName;
                }
                repoAnimalPicture.Add(model.AnimalPicture);
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
