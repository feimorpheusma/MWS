using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[System.Serializable]
	public class status
	{
		private basic basicField;

		private bool basicFieldSpecified;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public basic basic
		{
			get
			{
				return this.basicField;
			}
			set
			{
				this.basicField = value;
			}
		}

		[XmlIgnore]
		public bool basicSpecified
		{
			get
			{
				return this.basicFieldSpecified;
			}
			set
			{
				this.basicFieldSpecified = value;
			}
		}

		[XmlAnyElement(Order = 1)]
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
