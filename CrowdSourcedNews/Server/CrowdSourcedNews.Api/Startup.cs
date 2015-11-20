using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

using Ninject.Web.Common;
using Ninject.Web.WebApi;

[assembly: OwinStartup(typeof(CrowdSourcedNews.Api.Startup))]

namespace CrowdSourcedNews.Api
{
    using System.Web.Http;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
