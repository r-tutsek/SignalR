using Autofac;
using Autofac.Integration.WebApi;
using SignalRTestData.DAL;
using SignalRTestService;
using SignalRTestService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace SignalRTest.Autofac
{
    public static class AutofacDependencyBuilder
    {
        public static void DependencyBuilder()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<QuoteRepository>().As<IQuoteRespository>();
            builder.RegisterType<QuoteService>().As<IQuoteService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}