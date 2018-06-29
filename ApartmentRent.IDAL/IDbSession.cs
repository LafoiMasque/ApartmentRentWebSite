using System;
using System.Data.Entity;

namespace ApartmentRent.IDAL
{
	/// <summary>
	/// 业务层调用的是数据会话层的接口。
	/// </summary>
	public interface IDbSession<T> : IDisposable where T : class, IBaseDal
	{
		DbContext DbContext { get; }
		T CreateInstanceDal { get; }
		bool SaveChanged();
	}
}
