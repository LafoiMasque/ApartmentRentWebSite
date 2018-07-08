using System.Xml.Serialization;

namespace LafoiApp.Common.XmlOperation
{
	public class EntityModel
	{
		//[XmlAttribute]
		public string Key { get; set; }
		public string AssemblyPath { get; set; }
		public string NameSpace { get; set; }
		public string FullName { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
	}
}
