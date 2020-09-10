using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CURDoperation.Models
{
    public class Project
    {
        public int Id { get; set; }

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public bool IsActive { get; set; }

        public DateTime DevelopementStartDate { get; set; }
        public string Projectlogo { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFileBase file { get; set; }


    }
}