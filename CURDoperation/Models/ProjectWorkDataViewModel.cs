using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURDoperation.Models
{
    public class ProjectWorkDataViewModel
    {
        public List<Project> projectlist { get; set; }

        public ProjectWork prjtwork { get; set; }

        public List<ProjectWork> projectwrklist { get; set; }

    }
}