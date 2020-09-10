using CURDoperation.Models;
using CURDoperation.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDoperation.Controllers
{
    public class ProjectWorkController : Controller
    {
        // GET: ProjectWork
        public ActionResult Index()
        {
            ProjectWorkRepo prjrepo = new ProjectWorkRepo();

            var vm = new ProjectWorkDataViewModel
            {

                projectlist = prjrepo.GetProject(),
                prjtwork = new ProjectWork(),
                projectwrklist = prjrepo.GetProjectWork()
            };

            return View(vm);
        }

        public ActionResult AddPrjWork(ProjectWorkDataViewModel prjdata)
        {

            ProjectWorkRepo p = new ProjectWorkRepo();


            if (prjdata.prjtwork.ProjectWorkID == 0)
            {
                if (p.InsertProject(prjdata.prjtwork))
                {
                    ViewBag.Message = "Project added successfully";
                }
            }
            else
            {

                ModelState.Clear();
                var vm = new ProjectWorkDataViewModel
                {
                    projectlist = p.GetProject(),
                    prjtwork = new ProjectWork(),
                    projectwrklist = p.GetProjectWork()

                };
                return View("Index", vm);
            }
        }

        public ActionResult GetProjectWork(ProjectWork proj)
        {
            ProjectWorkRepo prjrepo = new ProjectWorkRepo();
            ModelState.Clear();
            var vm = new ProjectWorkDataViewModel
            {
                projectlist = prjrepo.GetProject(),
                prjtwork = new ProjectWork(),
                projectwrklist = prjrepo.GetProjectWork()
            };

            return View("Index", vm);
        }

    }

}
