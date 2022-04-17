using Project.DAL.Entities;
using System.Collections.Generic;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class NavbarVM
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<Contact> ContactMessageBox { get; internal set; }

    }
}
