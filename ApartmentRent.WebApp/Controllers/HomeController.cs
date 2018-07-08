using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApartmentRent.IBLL;
using ApartmentRent.Model.DataBaseModel;
using ApartmentRent.WebApp.CustomAttribute;

namespace ApartmentRent.WebApp.Controllers
{
	[WebSiteException]
	public class HomeController : Controller
	{
		public IBLL.IBuildingService BuildingService { get; set; }
		public IBLL.IBuildRoomService BuildRoomService { get; set; }

		public ActionResult Index()
		{
			var buildings = BuildingService.LoadEntities<Building>(o => o.CreateTime > new DateTime()).ToList();

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}