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
	public class privacy
	{
		private Note_t noteField;

		private object[] itemsField;

		private ItemsChoiceType2[] itemsElementNameField;

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

		[XmlAnyElement(Order = 1), XmlChoiceIdentifier("ItemsElementName"), XmlElement("text", typeof(empty), Order = 1), XmlElement("video", typeof(empty), Order = 1), XmlElement("audio", typeof(empty), Order = 1), XmlElement("unknown", typeof(empty), Order = 1)]
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
		public ItemsChoiceType2[] ItemsElementName
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
