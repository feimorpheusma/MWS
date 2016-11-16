using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.3038"), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[System.Serializable]
	public enum basic
	{
		open,
		close,
		Inviting,
		Invited,
		Ringing,
		Rung,
		Answer,
		GroupCall,
		Meeting,
		Disconn
	}
}
