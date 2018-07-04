using ApartmentRent.Common.XmlOperation;
using ApartmentRent.GenerateCode.GenerateController.ControllerModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRent.GenerateCode.GenerateController
{
	class GenerateControllerXml
	{
		public void CreateControllerXml()
		{
			string modelFile = @"D:\ProjectCode\VS2017\ApartmentRentWebSite\ApartmentRent.WebApp\bin\ApartmentRent.WebApp.dll";
			string filePath = @"D:\ProjectCode\VS2017\ApartmentRentWebSite\ApartmentRent.WebApp\Config\controllers.xml";
			if (File.Exists(modelFile))
			{
				byte[] fileData = File.ReadAllBytes(modelFile);
				Assembly assembly = Assembly.Load(fileData);
				Type[] assemblyTypes = assembly.GetTypes();
				var typeList = assemblyTypes.Where(m => m.BaseType.Name.Equals("Controller"));
				if (typeList != null && typeList.Count() > 0)
				{
					XmlUtils xmlUtils = new XmlUtils();
					xmlUtils.BeginInitialize(filePath);
					ObjectsModel objectsModel = new ObjectsModel()
					{
						Xmlns= "http://www.springframework.net",
					};
					List<ObjectModel> objectModelList = new List<ObjectModel>();
					foreach (var type in typeList)
					{
						ObjectModel objectModel = new ObjectModel()
						{
							Type = string.Format("{0}, {1}", type.FullName, type.Assembly.FullName.Substring(0, type.Assembly.FullName.IndexOf(','))),
							Singleton = "false",
						};
						List<PropertyModel> propertyModelList = new List<PropertyModel>();
						var propertyInfos = type.GetProperties().Where(o => o.PropertyType.Assembly.FullName.Contains("ApartmentRent.IBLL"));
						foreach (PropertyInfo propertyInfo in propertyInfos)
						{
							propertyModelList.Add(new PropertyModel()
							{
								Name = propertyInfo.Name,
								Reference = propertyInfo.Name,
							});
						}
						objectModel.PropertyModel = propertyModelList.ToArray();
						objectModelList.Add(objectModel);
					}
					objectsModel.ObjectModels = objectModelList.ToArray();
					if (File.Exists(filePath))
						xmlUtils.EditXmlElementInstance<ObjectsModel>(objectsModel);
					else
						xmlUtils.AddXmlElementInstance<ObjectsModel>(objectsModel);

					xmlUtils.EndInitialize();
				}
			}
		}
	}
}
