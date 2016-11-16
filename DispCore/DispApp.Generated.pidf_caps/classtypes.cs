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
	public class classtypes
	{
		private string businessField;

		private string personalField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string business
		{
			get
			{
				return this.businessField;
			}
			set
			{
				this.businessField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string personal
		{
			get
			{
				return this.personalField;
			}
			set
			{
				this.personalField = value;
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
	}
}
