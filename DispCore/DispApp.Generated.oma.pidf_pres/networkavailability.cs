using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.oma.pidf_pres
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("network-availability", Namespace = "urn:oma:xml:prs:pidf:oma-pres", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:oma:xml:prs:pidf:oma-pres")]
	[System.Serializable]
	public class networkavailability
	{
		private networkavailabilityNetwork[] networkField;

		private XmlElement[] anyField;

		private XmlAttribute[] anyAttrField;

		[XmlElement("network", Order = 0)]
		public networkavailabilityNetwork[] network
		{
			get
			{
				return this.networkField;
			}
			set
			{
				this.networkField = value;
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
	}
}
