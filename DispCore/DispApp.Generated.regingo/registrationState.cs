using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.regingo
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:reginfo")]
	[System.Serializable]
	public enum registrationState
	{
		init,
		active,
		terminated
	}
}
