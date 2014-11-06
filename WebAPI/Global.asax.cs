﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HibernatingRhinos.Profiler.Appender.NHibernate;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {

            NHibernateProfiler.Initialize();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
