using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using ServiceStack.Redis;

namespace VietLottVNAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public IRedisClientsManager ClientsManager;
        private const string RedisUri = "localhost";

        protected void Application_Start()
        {
            //ClientsManager = new PooledRedisClientManager(RedisUri);

            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            //ConfigureDependencyResolver(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureDependencyResolver(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly())
                .PropertiesAutowired();

            //builder.RegisterType<CustomerRepository>()
            //    .As<ICustomerRepository>()
            //    .PropertiesAutowired()
            //    .InstancePerApiRequest();

            //builder.RegisterType<OrderRepository>()
            //    .As<IOrderRepository>()
            //    .PropertiesAutowired()
            //    .InstancePerApiRequest();

            builder.Register<IRedisClient>(c => ClientsManager.GetClient())
                .InstancePerApiRequest();

            configuration.DependencyResolver
                = new AutofacWebApiDependencyResolver(builder.Build());
        }

        protected void Application_OnEnd()
        {
            ClientsManager.Dispose();
        }
    }
}
