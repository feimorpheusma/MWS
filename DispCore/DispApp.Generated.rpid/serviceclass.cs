using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("service-class", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class serviceclass
	{
		private Note_t noteField;

		private object itemField;

		private ItemChoiceType5 itemElementNameField;

		[XmlElement(Order = 0)]
		public Note_t note
		{
			get
			{
				return this.noteField;
			}
			set
			{
				this.noteField = value;
			}
		}

		[XmlAnyElement(Order = 1), XmlChoiceIdentifier("ItemElementName"), XmlElement("postal", typeof(empty), Order = 1), XmlElement("unknown", typeof(empty), Order = 1), XmlElement("courier", typeof(empty), Order = 1), XmlElement("electronic", typeof(empty), Order = 1), XmlElement("freight", typeof(empty), Order = 1), XmlElement("in-person", typeof(empty), Order = 1)]
		public object Item
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

		[XmlElement(Order = 2), XmlIgnore]
		public ItemChoiceType5 ItemElementName
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
