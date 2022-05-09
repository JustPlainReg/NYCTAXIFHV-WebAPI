using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NYCTaxiFHVData.Startup))]

namespace NYCTaxiFHVData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.AddSingleton<IRepository, CustomerRepository>();
            ConfigureAuth(app);
        }
    }
}
