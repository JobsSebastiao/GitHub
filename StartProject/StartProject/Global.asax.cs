using StartProject.App_Start;
using StartProject.DAO;
using StartProject.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StartProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            //configura para que o banco seja atualizado durrante a incializaçao do projeto.
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EstoqueContext,Configuration>());
        }
    }
}
