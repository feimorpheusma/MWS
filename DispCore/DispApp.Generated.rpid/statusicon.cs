using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("status-icon", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class statusicon
	{
		private System.DateTime fromField;

		private bool fromFieldSpecified;

		private System.DateTime untilField;

		private bool untilFieldSpecified;

		private string idField;

		private XmlAttribute[] anyAttrField;

		private string valueField;

		[XmlAttribute]
		public System.DateTime from
		{
			get
			{
				return this.fromField;
			}
			set
			{
				this.fromField = value;
			}
		}

		[XmlIgnore]
		public bool fromSpecified
		{
			get
			{
				return this.fromFieldSpecified;
			}
			set
			{
				this.fromFieldSpecified = value;
			}
		}

		[XmlAttribute]
		public System.DateTime until
		{
			get
			{
				return this.untilField;
			}
			set
			{
				this.untilField = value;
			}
		}

		[XmlIgnore]
		public bool untilSpecified
		{
			get
			{
				return this.untilFieldSpecified;
			}
			set
			{
				this.untilFieldSpecified = value;
			}
		}

		[XmlAttribute(DataType = "ID")]
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

		[XmlText(DataType = "anyURI")]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}
}
