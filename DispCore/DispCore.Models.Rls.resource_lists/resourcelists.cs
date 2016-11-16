using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispCore.Models.Rls.resource_lists
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("resource-lists", Namespace = "urn:ietf:params:xml:ns:resource-lists", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:resource-lists")]
	[System.Serializable]
	public class resourcelists
	{
		private listType[] listField;

		[XmlElement("list", Order = 0)]
		public listType[] list
		{
			get
			{
				return this.listField;
			}
			set
			{
				this.listField = value;
			}
		}
	}
}
