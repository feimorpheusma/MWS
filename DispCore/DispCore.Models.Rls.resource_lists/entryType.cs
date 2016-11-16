using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Models.Rls.resource_lists
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("entry", Namespace = "urn:ietf:params:xml:ns:resource-lists"), XmlType(Namespace = "urn:ietf:params:xml:ns:resource-lists")]
	[System.Serializable]
	public class entryType
	{
		private entryTypeDisplayname displaynameField;

		private XmlElement[] anyField;

		private string uriField;

		private XmlAttribute[] anyAttrField;

		private DoubangoProperty[] propField = null;

		[XmlElement("display-name", Order = 0)]
		public entryTypeDisplayname displayname
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
		public string uri
		{
			get
			{
				return this.uriField;
			}
			set
			{
				this.uriField = value;
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

		[XmlElement("prop", Namespace = "urn:doubango:params:xml:ns:properties", Order = 9)]
		public DoubangoProperty[] prop
		{
			get
			{
				return this.propField;
			}
			set
			{
				this.propField = value;
			}
		}
	}
}
