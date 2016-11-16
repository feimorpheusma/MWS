using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.oma.pidf_pres
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("service-description", Namespace = "urn:oma:xml:prs:pidf:oma-pres", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:oma:xml:prs:pidf:oma-pres")]
	[System.Serializable]
	public class servicedescription
	{
		private string serviceidField;

		private string versionField;

		private string descriptionField;

		private XmlElement[] anyField;

		private XmlAttribute[] anyAttrField;

		[XmlElement("service-id", DataType = "token", Order = 0)]
		public string serviceid
		{
			get
			{
				return this.serviceidField;
			}
			set
			{
				this.serviceidField = value;
			}
		}

		[XmlElement(DataType = "token", Order = 1)]
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

		[XmlElement(DataType = "token", Order = 2)]
		public string description
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

		[XmlAnyElement(Order = 3)]
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
