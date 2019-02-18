using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NewsParserSite.API.Utils;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

namespace NewsParserSite.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //// внедрение зависимостей
            //NinjectModule registrations = new NinjectRegistrations();
            //var kernel = new StandardKernel(registrations);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            // происходит ошибка
            // {
            //    "Message": "Произошла ошибка.",
            //    "ExceptionMessage": "Произошла ошибка при попытке создать контроллер типа \"NewsApiController\". Убедитесь в том, что контроллер имеет общедоступный конструктор без параметров.",
            //    "ExceptionType": "System.InvalidOperationException",
            //    "StackTrace": "   в System.Web.Http.Dispatcher.DefaultHttpControllerActivator.Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)\r\n   в System.Web.Http.Controllers.HttpControllerDescriptor.CreateController(HttpRequestMessage request)\r\n   в System.Web.Http.Dispatcher.HttpControllerDispatcher.<SendAsync>d__15.MoveNext()",
            //    "InnerException": {
            //        "Message": "Произошла ошибка.",
            //        "ExceptionMessage": "Тип \"NewsParserSite.API.Controllers.NewsApiController\" не содержит конструктор по умолчанию",
            //        "ExceptionType": "System.ArgumentException",
            //        "StackTrace": "   в System.Linq.Expressions.Expression.New(Type type)\r\n   в System.Web.Http.Internal.TypeActivator.Create[TBase](Type instanceType)\r\n   в System.Web.Http.Dispatcher.DefaultHttpControllerActivator.GetInstanceOrActivator(HttpRequestMessage request, Type controllerType, Func`1& activator)\r\n   в System.Web.Http.Dispatcher.DefaultHttpControllerActivator.Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)"
            //    }s
            //}
        }
    }
}
