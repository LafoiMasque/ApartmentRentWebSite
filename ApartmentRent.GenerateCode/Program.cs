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
				switch (consoleKeyInfo.Key)
				{
					case ConsoleKey.C:
						GenerateControllerXml generateControllerXml = new GenerateControllerXml();
						generateControllerXml.CreateControllerXml();
						break;
					case ConsoleKey.S:
						GenerateServiceXml generateServiceXml = new GenerateServiceXml();
						generateServiceXml.CreateServiceXml();
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
