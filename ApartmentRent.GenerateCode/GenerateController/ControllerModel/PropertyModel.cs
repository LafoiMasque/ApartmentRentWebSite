using System.ComponentModel;
using System.Xml.Serialization;

namespace ApartmentRent.GenerateCode.GenerateController.ControllerModel
{
	[DisplayName("property")]
	public class PropertyModel
	{
		[XmlAttribute]
		[DisplayName("name")]
		public string Name { get; set; }
		[XmlAttribute]
		[DisplayName("ref")]
		public string Reference { get; set; }
	}
}
