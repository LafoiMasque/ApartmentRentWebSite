using System.ComponentModel;
using System.Xml.Serialization;

namespace ApartmentRent.GenerateCode.GenerateController.ControllerModel
{
	[DisplayName("object")]
	public class ObjectModel
	{
		[XmlAttribute]
		[DisplayName("name")]
		public string Name { get; set; }
		[XmlAttribute]
		[DisplayName("type")]
		public string Type { get; set; }
		[XmlAttribute]
		[DisplayName("singleton")]
		public string Singleton { get; set; }
		[DisplayName("property")]
		public PropertyModel[] PropertyModel { get; set; }
	}
}
