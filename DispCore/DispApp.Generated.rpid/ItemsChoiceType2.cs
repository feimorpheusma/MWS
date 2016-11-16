using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IncludeInSchema = false)]
	[System.Serializable]
	public enum ItemsChoiceType2
	{
		[XmlEnum("##any:")]
		Item,
		audio,
		text,
		unknown,
		video
	}
}
