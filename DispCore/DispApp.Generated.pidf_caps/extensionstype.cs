using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class extensionstype
	{
		private extensiontypes supportedField;

		private extensiontypes notsupportedField;

		[XmlElement(Order = 0)]
		public extensiontypes supported
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

		[XmlElement(Order = 1)]
		public extensiontypes notsupported
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
