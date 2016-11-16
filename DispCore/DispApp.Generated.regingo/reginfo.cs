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
	public class reginfo
	{
		private registration[] registrationField;

		private XmlElement[] anyField;

		private string versionField;

		private reginfoState stateField;

		[XmlElement("registration", Order = 0)]
		public registration[] registration
		{
			get
			{
				return this.registrationField;
			}
			set
			{
				this.registrationField = value;
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

		[XmlAttribute(DataType = "nonNegativeInteger")]
		public string version
		{
			get
			{
				return this.versionField;
			}
			set
			{
				this.versionField = value;
			}
		}

		[XmlAttribute]
		public reginfoState state
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
