using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;
using NewsParserSite.DATA.Entities;
using Ninject.Modules;

namespace NewsParserSite.API.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<INewsRepository>().To<SqlNewsRepository>();
            Bind<IRepository<News>>().To<SqlNewsRepository>();
        }
    }
}