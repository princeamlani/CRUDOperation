using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURDoperation.Models
{
    public class ProjectDataViewModel
    {

        public Project project { get; set; }

         public List<Project> projectlist { get; set; }

        public ProjectWork projectwork { get; set; }


    }
}