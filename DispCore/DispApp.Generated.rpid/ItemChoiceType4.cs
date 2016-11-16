using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IncludeInSchema = false)]
	[System.Serializable]
	public enum ItemChoiceType4
	{
		[XmlEnum("##any:")]
		Item,
		assistant,
		associate,
		family,
		friend,
		other,
		self,
		supervisor,
		unknown
	}
}
