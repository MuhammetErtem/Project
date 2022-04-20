using Project.BL.Repositories;
using Project.DAL.Entities;
using Project.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Project.WebUI.Controllers
{
    public class AnimalController : Controller
    {
        SqlRepo<Animal> repoAnimal;
        public AnimalController(SqlRepo<Animal> _repoAnimal)
        {
            repoAnimal = _repoAnimal;
        }
        public IActionResult Index(int id)
        {
            AnimalVM animalVM = new AnimalVM
            {
                ListAnimal = repoAnimal.GetAll().Include(i => i.AnimalPictures).OrderByDescending(o => o.ID).Where(p => p.Enabled).Take(16),
                
            };
            return View(animalVM);
        }

        [Route("/animal/{name}-{id}")]
        public IActionResult Detail(string name, int id)
        {
            Animal animal = repoAnimal.GetAll().Include(i => i.AnimalPictures).FirstOrDefault(x => x.ID == id) ?? null;
            if (animal != null)
            {
                AnimalVM animalVM = new AnimalVM
                {
                    Animal = animal,
                    SimilarAnimals = repoAnimal.GetAll().Include(i => i.AnimalPictures).Take(4)

                };
                return View(animalVM);
            }
            else return Redirect("/");
        }
    }
}