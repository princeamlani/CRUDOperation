using CURDoperation.Models;
using CURDoperation.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CURDoperation.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            ProjectRepo prjrepo = new ProjectRepo();
            
            var vm = new ProjectDataViewModel
            {
                project = new Project(),
                projectlist = prjrepo.GetProject()
            };

            return View(vm);
        }
        [HttpPost]
        public ActionResult AddProject(ProjectDataViewModel prjdata)
        {
            ProjectRepo p = new ProjectRepo();

            if (!ModelState.IsValid)
            {
               
                return View("Index", prjdata);
            }
            if (ModelState.IsValid)
            {

              
                if (prjdata.project.Id == 0)
                {
                    if (prjdata.project.file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(prjdata.project.file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        prjdata.project.file.SaveAs(_path);
                    }

                    if (p.InsertProject(prjdata.project))
                    {
                        ViewBag.Message = "Project added successfully";
                    }
                }
                else
                {
                    if (p.EditProject(prjdata.project))
                    {
                        ViewBag.Message = "Project updated successfully";
                    }
                }

            }
            ModelState.Clear();
            var vm = new ProjectDataViewModel
            {
                project = new Project(),
                projectlist = p.GetProject()
                
            };
            return View("Index", vm);
        }


        public ActionResult GetProject(Project proj)
        {
            ProjectRepo prjrepo = new ProjectRepo();
            ModelState.Clear();
            var vm = new ProjectDataViewModel
            {
                project = new Project(),
                projectlist = prjrepo.GetProject()
            };

            return View("Index", vm);
        }
        public ActionResult DeleteProject(int id)
        {
            try
            {
                ProjectRepo prjr = new ProjectRepo();
                if (prjr.DeleteProject(id))
                {
                    ViewBag.Message = "Project Deleted Successfully";
                }

                return RedirectToAction("GetProject");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditProject(int id)
        {
            ProjectRepo prjrepo = new ProjectRepo();
            var prjtoEdit = prjrepo.GetProject().Find(p => p.ProjectID == id);

            var vm = new ProjectDataViewModel
            {
                project = prjtoEdit,
                projectlist = prjrepo.GetProject()
            };

            return View("Index",vm);
        }


        }
}
