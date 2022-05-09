using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.ViewModels
{
    public class UserVM
    {
        public IEnumerable<User> Users { get; set; }
    }
}
