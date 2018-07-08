using LafoiApp.Common.XmlOperation;
using ApartmentRent.GenerateCode.GenerateController.ControllerModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRent.GenerateCode.GenerateService
{
	class GenerateServiceXml
	{
		public void CreateServiceXml(string solutionPath)
		{
			string modelFile = solutionPath + @"ApartmentRent.BLL\bin\Debug\ApartmentRent.BLL.dll";
			string filePath = solutionPath + @"ApartmentRent.WebApp\Config\services.xml";
			if (File.Exists(modelFile))
			{
				byte[] fileData = File.ReadAllBytes(modelFile);
				Assembly assembly = Assembly.Load(fileData);
				Type[] assemblyTypes = assembly.GetTypes();
				var typeList = assemblyTypes.Where(m => m.GetInterface("IBaseService", false) != null);
				if (typeList != null && typeList.Count() > 0)
				{
					XmlUtils xmlUtils = new XmlUtils();
					xmlUtils.BeginInitialize(filePath);
					ObjectsModel objectsModel = new ObjectsModel()
					{
						Xmlns = "http://www.springframework.net",
					};
					List<ObjectModel> objectModelList = new List<ObjectModel>();
					foreach (var type in typeList)
					{
						ObjectModel objectModel = new ObjectModel()
						{
							Name = type.Name,
							Type = string.Format("{0}, {1}", type.FullName, type.Assembly.FullName.Substring(0, type.Assembly.FullName.IndexOf(','))),
							Singleton = "false",
						};
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
