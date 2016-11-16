using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.oma.pidf_pres
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("overriding-willingness", Namespace = "urn:oma:xml:prs:pidf:oma-pres", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:oma:xml:prs:pidf:oma-pres")]
	[System.Serializable]
	public class overridingwillingness
	{
		private basicType basicField;

		private bool basicFieldSpecified;

		private XmlElement[] anyField;

		private XmlAttribute[] anyAttrField;

		private string until;

		[XmlElement(Order = 0)]
		public basicType basic
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

		[XmlAttribute("until")]
		public string Until
		{
			get
			{
				return this.until;
			}
			set
			{
				this.until = value;
			}
		}
	}
}
