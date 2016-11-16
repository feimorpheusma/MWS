using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.regingo
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:reginfo", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:reginfo")]
	[System.Serializable]
	public class registration
	{
		private contact[] contactField;

		private XmlElement[] anyField;

		private string aorField;

		private string idField;

		private registrationState stateField;

		[XmlElement("contact", Order = 0)]
		public contact[] contact
		{
			get
			{
				return this.contactField;
			}
			set
			{
				this.contactField = value;
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

		[XmlAttribute(DataType = "anyURI")]
		public string aor
		{
			get
			{
				return this.aorField;
			}
			set
			{
				this.aorField = value;
			}
		}

		[XmlAttribute]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		[XmlAttribute]
		public registrationState state
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}
	}
}
