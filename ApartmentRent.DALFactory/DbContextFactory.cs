﻿using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace ApartmentRent.DALFactory
{
	/// <summary>
	/// 负责创建EF数据操作上下文实例，必须保证线程内唯一
	/// </summary>
	public class DbContextFactory
	{
		/// <summary>
		/// 线程槽
		/// </summary>
		/// <returns></returns>
		public static DbContext CreateDbContext()
		{
			DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
			if (dbContext == null)
			{
				//dbContext = new WebSiteDbContext();
				dbContext = AbstractFactory.CreateInstanceDal<DbContext>("WebSiteDbContext");
				CallContext.SetData("dbContext", dbContext);
			}
			return dbContext;
		}
	}
}
