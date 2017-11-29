namespace ProjectManagementTool.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectManagementTool.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagementTool.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProjectManagementTool.Models.ApplicationDbContext";
        }

        protected override void Seed(ProjectManagementTool.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                Name = "Jayed Ahmed",
                UserName = "jayed@gmail.com",
                Email = "jayed@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };
            string password = user.Email + "123";
            var checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Developer");
            }

            user = new ApplicationUser
            {
                Name = "Dipok",
                UserName = "dipok@gmail.com",
                Email = "dipok@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };

            password = user.Email + "123";
            checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Developer");
            }

            user = new ApplicationUser
            {
                Name = "Rakib Hossain",
                UserName = "rakib@gmail.com",
                Email = "rakib@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };

            password = user.Email + "123";
            checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Project Manager");
            }
            user = new ApplicationUser
            {
                Name = "Minhas Kamal",
                UserName = "minhas@gmail.com",
                Email = "minhas@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };

            password = user.Email + "123";
            checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "Team Lead");
            }
            user = new ApplicationUser
            {
                Name = "Tarek Salauddin",
                UserName = "ts@gmail.com",
                Email = "ts@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };

            password = user.Email + "123";
            checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "QA Engineer");
            }
            user = new ApplicationUser
            {
                Name = "Mamun Ahmed",
                UserName = "mamu@gmail.com",
                Email = "mamu@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = true,
                Status = "Active"
            };

            password = user.Email + "123";
            checkUser = userManager.Create(user, password);
            if (checkUser.Succeeded)
            {
                userManager.AddToRole(user.Id, "UX Engineer");
            }

            context.Projects.AddOrUpdate(p => p.Name,
                new Project
                {
                    Name = "Project Management Tool",
                    CodeName = "PMT",
                    Description = "Project management tools are aids to assist an individual or team to effectively organize work and manage projects and tasks. The term usually refers to project management software you can purchase online or even use for free. ",
                    StartDate = DateTime.Parse("2017-11-11"),
                    EndDate = DateTime.Parse("2017-11-30"),
                    Duration = DateTime.Parse("2017-11-30").Subtract(DateTime.Parse("2017-11-11")).TotalDays.ToString(),
                    FilePath = "",
                    Status = "Started"
                },
                new Project
                {
                    Name = "Inventory Management System",
                    CodeName = "IMS",
                    Description = "IMS is an application to maintain inventory of an office.",
                    StartDate = DateTime.Parse("2017-10-10"),
                    EndDate = DateTime.Parse("2017-12-30"),
                    Duration = DateTime.Parse("2017-12-30").Subtract(DateTime.Parse("2017-10-10")).TotalDays.ToString(),
                    FilePath = "",
                    Status = "Cancelled"
                },
                new Project
                {
                    Name = "IIT Automation System",
                    CodeName = "IAS",
                    Description = "IAS is an application to automate the manual system of IIT.",
                    StartDate = DateTime.Parse("2017-01-01"),
                    EndDate = DateTime.Parse("2017-06-28"),
                    Duration = DateTime.Parse("2017-06-28").Subtract(DateTime.Parse("2017-01-01")).TotalDays.ToString(),
                    FilePath = "",
                    Status = "Completed"
                }
            );
        }
    }
}
