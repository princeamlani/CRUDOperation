using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURDoperation.Models
{
    public class ProjectWork
    {
        public int Id { get; set; }
        public int ProjectWorkID { get; set; }
        public string ProjectID { get; set; }

        public string Work { get; set; }

        public bool IsCompleted { get; set; }
    }
}