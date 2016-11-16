using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class mobilitytypes
	{
		private string fixedField;

		private string mobileField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string @fixed
		{
			get
			{
				return this.fixedField;
			}
			set
			{
				this.fixedField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string mobile
		{
			get
			{
				return this.mobileField;
			}
			set
			{
				this.mobileField = value;
			}
		}

		[XmlAnyElement(Order = 2)]
		public XmlElement[] Any
		{
			get
			{
				return this.anyField;
			}
			set
			{
				this.anyField = value;
			}
		}
	}
}
