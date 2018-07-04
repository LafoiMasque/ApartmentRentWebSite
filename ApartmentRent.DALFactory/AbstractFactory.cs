using ApartmentRent.Common.XmlOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ApartmentRent.DALFactory
{
	/// <summary>
	/// 通过反射的形式创建类的实例
	/// </summary>
	public class AbstractFactory
	{
		private static readonly List<EntityModel> m_entityModelList = null;

		static AbstractFactory()
		{
			string filePath = AppDomain.CurrentDomain.BaseDirectory + @"Config\EntityInfo.xml";
			m_entityModelList = XmlUtils.GetXmlElements<EntityModel>(filePath);
		}

		private static Assembly CreateAssemblyObject(string assemblyPath)
		{
			return Assembly.Load(assemblyPath);
		}

		private static object CreateInstanceObject(string typeName, string assemblyPath)
		{
			Assembly assembly = CreateAssemblyObject(assemblyPath);
			return assembly.CreateInstance(typeName);
		}

		public static T CreateInstanceDal<T>() where T : class
		{
			string entityKey = typeof(T).Name;
			return CreateInstanceDal<T>(entityKey);
		}

		public static T CreateInstanceDal<T>(string entityKey) where T : class
		{
			T result = null;
			if (m_entityModelList != null && !string.IsNullOrEmpty(entityKey))
			{
				EntityModel entityModel = m_entityModelList.FirstOrDefault(o => o.Key == entityKey);
				if (entityModel != null)
				{
					result = CreateInstanceObject(entityModel.FullName, entityModel.AssemblyPath) as T;
				}
			}
			return result;
		}

		public static T CreateInstanceDal<T>(string entityKey, params Type[] genericType) where T : class
		{
			T result = null;
			if (m_entityModelList != null && !string.IsNullOrEmpty(entityKey))
			{
				EntityModel entityModel = m_entityModelList.FirstOrDefault(o => o.Key == entityKey);
				if (entityModel != null)
				{
					Assembly assembly = CreateAssemblyObject(entityModel.AssemblyPath);
					Type entityType = assembly.GetType(entityModel.Type);
					Type entityFullType = entityType.MakeGenericType(genericType);
					result = assembly.CreateInstance(entityFullType.FullName) as T; ;
				}
			}
			return result;
		}

	}
}
