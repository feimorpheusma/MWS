using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:caps", IsNullable = false), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class devcaps
	{
		private descriptiontype[] descriptionField;

		private mobilitytype mobilityField;

		private XmlElement[] anyField;

		private XmlAttribute[] anyAttrField;

		[XmlElement("description", Order = 0)]
		public descriptiontype[] description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		[XmlElement(Order = 1)]
		public mobilitytype mobility
		{
			get
			{
				return this.mobilityField;
			}
			set
			{
				this.mobilityField = value;
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
