using System.Configuration;

namespace ApartmentRent.Core.LuceneNet.Utility
{
	public class StaticConstant
	{
		public static readonly string IndexPath = ConfigurationManager.AppSettings["LuceneIndexPath"];
	}
}