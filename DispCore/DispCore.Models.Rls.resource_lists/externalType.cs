using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Models.Rls.resource_lists
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("external", Namespace = "urn:ietf:params:xml:ns:resource-lists"), XmlType(Namespace = "urn:ietf:params:xml:ns:resource-lists")]
	[System.Serializable]
	public class externalType
	{
		private displaynameType displaynameField;

		private XmlElement[] anyField;

		private string anchorField;

		private XmlAttribute[] anyAttrField;

		[XmlElement("display-name", Order = 0)]
		public displaynameType displayname
		{
			get
			{
				return this.displaynameField;
			}
			set
			{
				this.displaynameField = value;
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
		public string anchor
		{
			get
			{
				return this.anchorField;
			}
			set
			{
				this.anchorField = value;
			}
		}

		[XmlAnyAttribute]
		public XmlAttribute[] AnyAttr
		{
			get
			{
				return this.anyAttrField;
			}
			set
			{
				this.anyAttrField = value;
			}
		}
	}
}
