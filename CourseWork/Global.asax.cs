using CourseWork.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CourseWork
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SecurityDbContext db = new SecurityDbContext();
            RoleStore<Role> roleStore = new RoleStore<Role>(db);
            RoleManager<Role> roleManager = new RoleManager<Role>(roleStore);
            if (!roleManager.RoleExists("Administrator"))
            {
                Role newRole = new Role("Administrator",
               "Администратор обладает полными правами в системе");
                roleManager.Create(newRole);
            }
            if (!roleManager.RoleExists("Operator"))
            {
                Role newRole = new Role("Operator", "Операторы могут только добавлять и изменять данные в системе");
               
                roleManager.Create(newRole);
            }
        }
    }
}
