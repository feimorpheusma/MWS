using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class lowerthantype
	{
		private string maxvalueField;

		[XmlAttribute(DataType = "integer")]
		public string maxvalue
		{
			get
			{
				return this.maxvalueField;
			}
			set
			{
				this.maxvalueField = value;
			}
		}
	}
}
