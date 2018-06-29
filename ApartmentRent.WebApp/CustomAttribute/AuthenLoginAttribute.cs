using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace ApartmentRent.WebApp.CustomAttribute
{
	public class AuthenLoginAttribute : FilterAttribute, IAuthenticationFilter
	{
		/// <summary>
		/// 这个方法是在Action执行之前调用
		/// </summary>
		/// <param name="filterContext"></param>
		public void OnAuthentication(AuthenticationContext filterContext)
		{
			//if (filterContext.HttpContext.Session["userInfo"] == null)
			//{
			//	//var Url = new UrlHelper(filterContext.RequestContext);
			//	//var url = Url.Action("Logon", "Account", new { area = "" });
			//	//filterContext.Result = new RedirectResult(url);
			//	filterContext.Result = new RedirectResult("/Login/Index");
			//}
		}

		/// <summary>
		/// 这个方法是在Action执行之后调用
		/// </summary>
		/// <param name="filterContext"></param>
		public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
		{

		}
	}
}