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
	public class actortypes
	{
		private string attendantField;

		private string informationField;

		private string msgtakerField;

		private string principalField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string attendant
		{
			get
			{
				return this.attendantField;
			}
			set
			{
				this.attendantField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string information
		{
			get
			{
				return this.informationField;
			}
			set
			{
				this.informationField = value;
			}
		}

		[XmlElement("msg-taker", Order = 2)]
		public string msgtaker
		{
			get
			{
				return this.msgtakerField;
			}
			set
			{
				this.msgtakerField = value;
			}
		}

		[XmlElement(Order = 3)]
		public string principal
		{
			get
			{
				return this.principalField;
			}
			set
			{
				this.principalField = value;
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
