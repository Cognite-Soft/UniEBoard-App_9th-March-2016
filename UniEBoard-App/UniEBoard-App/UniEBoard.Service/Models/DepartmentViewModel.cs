using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace UniEBoard.Service.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [AllowHtml]
        public string Name { set; get; }
    }
}
