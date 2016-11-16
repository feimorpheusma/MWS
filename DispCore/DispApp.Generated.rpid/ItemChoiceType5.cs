using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IncludeInSchema = false)]
	[System.Serializable]
	public enum ItemChoiceType5
	{
		[XmlEnum("##any:")]
		Item,
		courier,
		electronic,
		freight,
		[XmlEnum("in-person")]
		inperson,
		postal,
		unknown
	}
}
