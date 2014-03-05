using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace UniEBoard.Service.Models.Units
{
    public class ClassViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public VideoViewModel VideoAssets { get; set; }

        public DocumentViewModel DocumentAssets { get; set; }

        public List<AssignmentViewModel> ListAsignment { get; set; }

        public List<ScheduleViewModel> ListScheduleViewModel { get; set; }

        public List<DepartmentViewModel> DepartmentViewModel
        {
            get;
            set;
        }

        public int UserCount { set; get; }
    }
}
