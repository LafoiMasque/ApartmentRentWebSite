using System.ComponentModel;
using System.Xml.Serialization;

namespace ApartmentRent.GenerateCode.GenerateController.ControllerModel
{
	[DisplayName("objects")]
	public class ObjectsModel
	{
		[XmlAttribute]
		[DisplayName("xmlns")]
		public string Xmlns { get; set; }
		[DisplayName("object")]
		public ObjectModel[] ObjectModels { get; set; }
	}
}
