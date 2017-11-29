using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementTool.Models;
using System.IO;
using ProjectManagementTool.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace ProjectManagementTool.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Project
        [Authorize(Roles = "Project Manager")]
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }

        [Authorize(Roles = "Project Manager, Team Lead, Developer, QA Engineer, UX Engineer")]
        public ActionResult ViewProjects()
        {
            var userId = User.Identity.GetUserId();

            var projects = (from resource in db.ResourcePersons
                            where resource.UserId == userId
                            join project in db.Projects on resource.ProjectId equals project.Id
                            select new ProjectIndexViewModel
                            {
                                ProjectId = project.Id,
                                Name = project.Name,
                                CodeName = project.CodeName,
                                Status = project.Status,
                                NumberOfMembers = db.ResourcePersons.Where(s => s.ProjectId == project.Id).Count()
                            }).ToList();


            return View(projects);
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CodeName,Description,StartDate,EndDate,Duration,FilePath,Status")] Project project, HttpPostedFileBase file)
        {
            string fileName = "";

            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                file.SaveAs(HttpContext.Server.MapPath("~/UploadedFiles/")
                    + fileName);
            }
            else
            {
                ModelState.AddModelError("FilePath", "File upload failed.");
            }
            if (ModelState.IsValid)
            {
                project.FilePath = fileName;
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        [Authorize(Roles = "Project Manager")]
        public ActionResult AssignPerson()
        {
            AssignPersonViewModel model = new AssignPersonViewModel();

            var projects = db.Projects.OrderBy(s => s.Name).ToList();
            List<SelectListItem> projectList = new List<SelectListItem>();
            foreach (var item in projects)
            {
                projectList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            model.Projects = projectList;

            var adminRoleId = db.Roles.Where(r => r.Name == "IT Admin").Select(m => m.Id).SingleOrDefault();
            var users = db.Users.Where(u => u.Roles.Any(r => r.RoleId != adminRoleId)).OrderBy(s => s.Name).ToList();

            List<SelectListItem> userList = new List<SelectListItem>();
            foreach (var item in users)
            {
                userList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id
                });
            }
            model.Users = userList;

            var projectUserRole = (from project in db.Projects
                                   join resource in db.ResourcePersons on project.Id equals resource.ProjectId
                                   join user in db.Users on resource.UserId equals user.Id
                                   select new ResourcePersonViewModel
                                   {
                                       ProjectName = project.Name,
                                       ResourcePerson = user.Name,
                                       Designation = db.Roles.Where(s => s.Users.Any(u => u.UserId == user.Id)).FirstOrDefault().Name
                                   }).ToList();
            model.ResourcePersons = projectUserRole;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Project Manager")]
        [ValidateAntiForgeryToken]
        public ActionResult AssignPerson([Bind(Include = "ProjectId,UserId,")]AssignPersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var resource = new ResourcePerson();
                resource.ProjectId = Int32.Parse(model.ProjectId);
                resource.UserId = model.UserId;

                db.ResourcePersons.Add(resource);
                db.SaveChanges();
                return RedirectToAction("AssignPerson", "Project");
            }
            ModelState.AddModelError("", "Unable to assign resource person");
            return View(model);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CodeName,Description,StartDate,EndDate,Duration,FilePath,Status")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
