using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DispCore.Models.Rls.resource_lists
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(TypeName = "display-nameType", Namespace = "urn:ietf:params:xml:ns:resource-lists")]
	[System.Serializable]
	public class displaynameType
	{
		private string langField;

		private string valueField;

		[XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
		public string lang
		{
			get
			{
				return this.langField;
			}
			set
			{
				this.langField = value;
			}
		}

		[XmlText]
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
