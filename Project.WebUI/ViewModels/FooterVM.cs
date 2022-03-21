using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class FooterVM
    {
        public IEnumerable<Brand> Brands { get; set; }
    }
}
