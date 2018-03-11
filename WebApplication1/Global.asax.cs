using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using CarFactory.Admin;
using Castle.Facilities.Logging;

namespace WebApplication1
{
    //    public class MvcApplication : System.Web.HttpApplication
    //    {
    //        protected void Application_Start()
    //        {
    //            AreaRegistration.RegisterAllAreas();
    //            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
    //            RouteConfig.RegisterRoutes(RouteTable.Routes);
    //            BundleConfig.RegisterBundles(BundleTable.Bundles);
    //        }
    //    }

    public class MvcApplication : AbpWebApplication<CarFactoryWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig(Server.MapPath("log4net.config"))
            );

            base.Application_Start(sender, e);
        }
    }
}
