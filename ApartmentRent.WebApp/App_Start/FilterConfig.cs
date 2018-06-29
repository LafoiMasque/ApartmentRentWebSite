using ApartmentRent.WebApp.CustomAttribute;
using System.Web;
using System.Web.Mvc;

namespace ApartmentRent.WebApp
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			//filters.Add(new HandleErrorAttribute());
			filters.Add(new WebSiteExceptionAttribute());
		}
	}
}
