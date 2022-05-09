using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Routing;
using NYCTaxiFHVData;
using NYCTaxiFHVData.Repository;
using NYCTaxiFHVData.Service;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace NYCTaxiFHVData
{
    public partial class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            var corsAttr = new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true };
            // corsAttr.PreflightMaxAge = 5000;
            GlobalConfiguration.Configuration.EnableCors(corsAttr);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var container=new SimpleInjector.Container();
            container.Register<IRepository,Repository.Repository>(Lifestyle.Singleton); 
            container.Register<ITripDataRepository,TripDataRespository>(Lifestyle.Transient);
            container.Register<ILookUpRepository, LookUpRepository>(Lifestyle.Transient);
            container.Register<ITripDataService, TripDataService>(Lifestyle.Transient);
            container.Register<ILookUpService, LookUpService>(Lifestyle.Transient);
            container.Verify();

           // DependencyResolver.SetResolver(new SimpleInjectorWebApiDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver=new  SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}
