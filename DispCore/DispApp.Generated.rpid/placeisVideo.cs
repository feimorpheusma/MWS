using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class placeisVideo
	{
		private empty itemField;

		private ItemChoiceType1 itemElementNameField;

		[XmlChoiceIdentifier("ItemElementName"), XmlElement("ok", typeof(empty), Order = 0), XmlElement("dark", typeof(empty), Order = 0), XmlElement("toobright", typeof(empty), Order = 0), XmlElement("unknown", typeof(empty), Order = 0)]
		public empty Item
		{
			get
			{
				return this.itemField;
			}
			set
			{
				this.itemField = value;
			}
		}

		[XmlElement(Order = 1), XmlIgnore]
		public ItemChoiceType1 ItemElementName
		{
			get
			{
				return this.itemElementNameField;
			}
			set
			{
				this.itemElementNameField = value;
			}
		}
	}
}
