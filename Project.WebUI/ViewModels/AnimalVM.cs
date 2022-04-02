using Project.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class AnimalVM
    {
        public Animal Animal { get; set; }
        public IEnumerable<Animal> ListAnimal { get; set; }
        public IEnumerable<Animal> SimilarAnimals { get; set; }

        public AnimalPicture AnimalPicture { get; set; }

    }
}
