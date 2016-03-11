using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [AllowHtml]
        public string Title { get; set; }
        [AllowHtml]
        public string Description { get; set; }

        public virtual ICollection<UserViewModel> Users { get; set; }
    }
}
