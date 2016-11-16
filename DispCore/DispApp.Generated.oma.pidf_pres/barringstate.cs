using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.oma.pidf_pres
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("barring-state", Namespace = "urn:oma:xml:prs:pidf:oma-pres", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:oma:xml:prs:pidf:oma-pres")]
	[System.Serializable]
	public class barringstate
	{
		private XmlAttribute[] anyAttrField;

		private barringType valueField;

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

		[XmlText]
		public barringType Value
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
