using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[System.Serializable]
	public class contact
	{
		private decimal priorityField;

		private bool priorityFieldSpecified;

		private string valueField;

		[XmlAttribute]
		public decimal priority
		{
			get
			{
				return this.priorityField;
			}
			set
			{
				this.priorityField = value;
			}
		}

		[XmlIgnore]
		public bool prioritySpecified
		{
			get
			{
				return this.priorityFieldSpecified;
			}
			set
			{
				this.priorityFieldSpecified = value;
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
