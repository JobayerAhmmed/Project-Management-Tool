using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagementTool.Models;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectManagementTool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateRolesAndUsers();
        }

        protected void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Admin role and user
            if (!roleManager.RoleExists("IT Admin"))
            {
                var role = new IdentityRole();
                role.Name = "IT Admin";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.Name = "Jobayer Ahmmed";
                user.UserName = "jobayer.ahmmed@gmail.com";
                user.Email = "jobayer.ahmmed@gmail.com";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                user.Status = "Active";

                string userPWD = "jobayer.ahmmed@gmail.com123";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "IT Admin");
                }
            }

            if (!roleManager.RoleExists("Project Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Project Manager";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Team Lead"))
            {
                var role = new IdentityRole();
                role.Name = "Team Lead";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Developer"))
            {
                var role = new IdentityRole();
                role.Name = "Developer";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("QA Engineer"))
            {
                var role = new IdentityRole();
                role.Name = "QA Engineer";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("UX Engineer"))
            {
                var role = new IdentityRole();
                role.Name = "UX Engineer";
                roleManager.Create(role);
            }
        }
    }
}
