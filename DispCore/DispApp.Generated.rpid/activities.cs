using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class activities
	{
		private Note_t noteField;

		private object[] itemsField;

		private ItemsChoiceType[] itemsElementNameField;

		private System.DateTime fromField;

		private bool fromFieldSpecified;

		private System.DateTime untilField;

		private bool untilFieldSpecified;

		private string idField;

		private XmlAttribute[] anyAttrField;

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

		[XmlAnyElement(Order = 1), XmlChoiceIdentifier("ItemsElementName"), XmlElement("working", typeof(empty), Order = 1), XmlElement("travel", typeof(empty), Order = 1), XmlElement("playing", typeof(empty), Order = 1), XmlElement("steering", typeof(empty), Order = 1), XmlElement("presentation", typeof(empty), Order = 1), XmlElement("unknown", typeof(empty), Order = 1), XmlElement("breakfast", typeof(empty), Order = 1), XmlElement("permanent-absence", typeof(empty), Order = 1), XmlElement("vacation", typeof(empty), Order = 1), XmlElement("worship", typeof(empty), Order = 1), XmlElement("spectator", typeof(empty), Order = 1), XmlElement("tv", typeof(empty), Order = 1), XmlElement("sleeping", typeof(empty), Order = 1), XmlElement("appointment", typeof(empty), Order = 1), XmlElement("away", typeof(empty), Order = 1), XmlElement("shopping", typeof(empty), Order = 1), XmlElement("busy", typeof(empty), Order = 1), XmlElement("dinner", typeof(empty), Order = 1), XmlElement("holiday", typeof(empty), Order = 1), XmlElement("in-transit", typeof(empty), Order = 1), XmlElement("looking-for-work", typeof(empty), Order = 1), XmlElement("meal", typeof(empty), Order = 1), XmlElement("meeting", typeof(empty), Order = 1), XmlElement("on-the-phone", typeof(empty), Order = 1), XmlElement("other", typeof(Note_t), Order = 1), XmlElement("performance", typeof(empty), Order = 1)]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		[XmlElement("ItemsElementName", Order = 2), XmlIgnore]
		public ItemsChoiceType[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}

		[XmlAttribute]
		public System.DateTime from
		{
			get
			{
				return this.fromField;
			}
			set
			{
				this.fromField = value;
			}
		}

		[XmlIgnore]
		public bool fromSpecified
		{
			get
			{
				return this.fromFieldSpecified;
			}
			set
			{
				this.fromFieldSpecified = value;
			}
		}

		[XmlAttribute]
		public System.DateTime until
		{
			get
			{
				return this.untilField;
			}
			set
			{
				this.untilField = value;
			}
		}

		[XmlIgnore]
		public bool untilSpecified
		{
			get
			{
				return this.untilFieldSpecified;
			}
			set
			{
				this.untilFieldSpecified = value;
			}
		}

		[XmlAttribute(DataType = "ID")]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
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
