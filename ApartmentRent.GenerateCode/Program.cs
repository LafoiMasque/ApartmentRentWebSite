using ApartmentRent.GenerateCode.GenerateController;
using ApartmentRent.GenerateCode.GenerateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRent.GenerateCode
{
	class Program
	{
		static void Main(string[] args)
		{
			bool isContinue = true;
			do
			{
				Console.WriteLine("GenerateControllerXml->C");
				Console.WriteLine("GenerateServiceXml->S");
				Console.Write("生成目标：");
				ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
				Console.WriteLine();
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string solutionPath = baseDir.Substring(0, baseDir.IndexOf("ApartmentRent.GenerateCode"));
				switch (consoleKeyInfo.Key)
				{
					case ConsoleKey.C:
						GenerateControllerXml generateControllerXml = new GenerateControllerXml();
						generateControllerXml.CreateControllerXml(solutionPath);
						break;
					case ConsoleKey.S:
						GenerateServiceXml generateServiceXml = new GenerateServiceXml();
						generateServiceXml.CreateServiceXml(solutionPath);
						break;
					default:
						isContinue = false;
						break;
				}
				Console.WriteLine("生成完成");
			} while (isContinue);
		}
	}
}
