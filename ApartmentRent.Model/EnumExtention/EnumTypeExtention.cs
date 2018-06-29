using ApartmentRent.Model.CustomAttribute;
using System;
using System.Linq;

namespace ApartmentRent.Model.EnumExtention
{
	public static class EnumTypeExtention
	{
		public static string Display(this Enum t)
		{
			Type type = t.GetType();
			string fieldName = Enum.GetName(type, t);
			var attributes = type.GetField(fieldName).GetCustomAttributes(false);
			var enumDisplayAttribute = attributes.FirstOrDefault(p => p.GetType().Equals(typeof(EnumDisplayAttribute))) as EnumDisplayAttribute;
			return enumDisplayAttribute == null ? fieldName : enumDisplayAttribute.Display;
		}
	}
}
