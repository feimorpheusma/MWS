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
	public class duplextypes
	{
		private string fullField;

		private string halfField;

		private string receiveonlyField;

		private string sendonlyField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string full
		{
			get
			{
				return this.fullField;
			}
			set
			{
				this.fullField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string half
		{
			get
			{
				return this.halfField;
			}
			set
			{
				this.halfField = value;
			}
		}

		[XmlElement("receive-only", Order = 2)]
		public string receiveonly
		{
			get
			{
				return this.receiveonlyField;
			}
			set
			{
				this.receiveonlyField = value;
			}
		}

		[XmlElement("send-only", Order = 3)]
		public string sendonly
		{
			get
			{
				return this.sendonlyField;
			}
			set
			{
				this.sendonlyField = value;
			}
		}

		[XmlAnyElement(Order = 4)]
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
