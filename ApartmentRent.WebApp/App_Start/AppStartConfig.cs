using ApartmentRent.WebApp.CustomAttribute;
using Common.Logging;
using LafoiApp.Common.XmlOperation;
using LafoiApp.Core.LuceneNet.Utility;
using log4net.Config;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ApartmentRent.WebApp.App_Start
{
	public class AppStartConfig
	{
		public static void ApplicationStart(HttpServerUtility server)
		{
			//读取了配置文件中关于Log4Net配置信息.
			XmlConfigurator.Configure();

			#region Exception

			//开启一个线程，扫描异常信息队列。
			string filePath = server.MapPath("/Log/");//Request.MapPath()
			Task.Factory.StartNew(o =>
			{
				while (true)
				{
					//判断一下队列中是否有数据
					if (WebSiteExceptionAttribute.ExceptionQueue.Count > 0)
					{
						Exception ex = WebSiteExceptionAttribute.ExceptionQueue.Dequeue();
						if (ex != null)
						{
							//将异常信息写到日志文件中。
							//string fileName = DateTime.Now.ToString("yyyy-MM-dd");
							//System.IO.File.AppendAllText(filePath+ fileName + ".txt", ex.ToString(), System.Text.Encoding.UTF8);
							ILog logger = LogManager.GetLogger("errorMsg");
							logger.Error(ex.ToString());
						}
						else
						{
							//如果队列中没有数据，休息
							Thread.Sleep(3000);
						}
					}
					else
					{
						//如果队列中没有数据，休息
						Thread.Sleep(3000);
					}
				}
			}, filePath);

			#endregion

			StaticConstant.IndexPath = ConfigurationManager.AppSettings["LuceneIndexPath"];

			string importFilePath = AppDomain.CurrentDomain.BaseDirectory + @"Config\ImportantConfiguration.xml";
			if (File.Exists(importFilePath))
			{
				List<EntityModel> entityModels = XmlUtils.GetXmlElements<EntityModel>(importFilePath);
				string encryptKey = entityModels.First().Key;
				LafoiApp.Common.SecurityEncrypt.DesEncrypt.SetEncryptKey(encryptKey);
			}
		}
	}
}