using ApartmentRent.WebApp.App_Start;
using Spring.Web.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ApartmentRent.WebApp
{
	public class MvcApplication : SpringMvcApplication//HttpApplication
	{
		protected void Application_Start()
		{
			AppStartConfig.ApplicationStart(Server);

			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
