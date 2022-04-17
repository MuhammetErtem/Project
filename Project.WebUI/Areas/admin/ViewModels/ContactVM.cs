using Project.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project.WebUI.Areas.admin.ViewModels
{
    public class ContactVM
    {
        public Contact Contact { get; set; }
        public IEnumerable<Contact> ContactMessageBox { get; internal set; }


    }
}
