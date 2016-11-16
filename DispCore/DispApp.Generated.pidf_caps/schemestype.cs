using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class schemestype
	{
		private string[] supportedField;

		private string[] notsupportedField;

		[XmlArray(Order = 0), XmlArrayItem("s", IsNullable = false)]
		public string[] supported
		{
			get
			{
				return this.supportedField;
			}
			set
			{
				this.supportedField = value;
			}
		}

		[XmlArray(Order = 1), XmlArrayItem("s", IsNullable = false)]
		public string[] notsupported
		{
			get
			{
				return this.notsupportedField;
			}
			set
			{
				this.notsupportedField = value;
			}
		}
	}
}
