using System.Runtime.Remoting.Messaging;
using ApartmentRent.IDAL;

namespace ApartmentRent.DALFactory
{
	public class DbSessionFactory
	{
		public static IDbSession<T> CreateDbSession<T>() where T : class, IBaseDal
		{
			IDbSession<T> dbSession = (IDbSession<T>)CallContext.GetData("dbSession");
			if (dbSession == null)
			{
				dbSession = new DbSession<T>();
				CallContext.SetData("dbSession", dbSession);
			}
			return dbSession;
		}
	}
}
