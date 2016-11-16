using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.42"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("pidf-full", Namespace = "urn:ietf:params:xml:ns:pidf-diff", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf-diff")]
	[System.Serializable]
	public class pidffull : presence
	{
		private uint versionField;

		private bool versionFieldSpecified;

		[XmlAttribute]
		public uint version
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

		[XmlIgnore]
		public bool versionSpecified
		{
			get
			{
				return this.versionFieldSpecified;
			}
			set
			{
				this.versionFieldSpecified = value;
			}
		}
	}
}
