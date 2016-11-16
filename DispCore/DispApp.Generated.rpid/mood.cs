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
	public class mood
	{
		private Note_t noteField;

		private object[] itemsField;

		private ItemsChoiceType1[] itemsElementNameField;

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

		[XmlAnyElement(Order = 1), XmlChoiceIdentifier("ItemsElementName"), XmlElement("anxious", typeof(empty), Order = 1), XmlElement("ashamed", typeof(empty), Order = 1), XmlElement("jealous", typeof(empty), Order = 1), XmlElement("annoyed", typeof(empty), Order = 1), XmlElement("bored", typeof(empty), Order = 1), XmlElement("brave", typeof(empty), Order = 1), XmlElement("calm", typeof(empty), Order = 1), XmlElement("cold", typeof(empty), Order = 1), XmlElement("confused", typeof(empty), Order = 1), XmlElement("contented", typeof(empty), Order = 1), XmlElement("cranky", typeof(empty), Order = 1), XmlElement("curious", typeof(empty), Order = 1), XmlElement("depressed", typeof(empty), Order = 1), XmlElement("disappointed", typeof(empty), Order = 1), XmlElement("disgusted", typeof(empty), Order = 1), XmlElement("distracted", typeof(empty), Order = 1), XmlElement("embarrassed", typeof(empty), Order = 1), XmlElement("excited", typeof(empty), Order = 1), XmlElement("flirtatious", typeof(empty), Order = 1), XmlElement("frustrated", typeof(empty), Order = 1), XmlElement("grumpy", typeof(empty), Order = 1), XmlElement("guilty", typeof(empty), Order = 1), XmlElement("happy", typeof(empty), Order = 1), XmlElement("hot", typeof(empty), Order = 1), XmlElement("humbled", typeof(empty), Order = 1), XmlElement("humiliated", typeof(empty), Order = 1), XmlElement("hungry", typeof(empty), Order = 1), XmlElement("hurt", typeof(empty), Order = 1), XmlElement("impressed", typeof(empty), Order = 1), XmlElement("in_awe", typeof(empty), Order = 1), XmlElement("in_love", typeof(empty), Order = 1), XmlElement("indignant", typeof(empty), Order = 1), XmlElement("interested", typeof(empty), Order = 1), XmlElement("invincible", typeof(empty), Order = 1), XmlElement("lonely", typeof(empty), Order = 1), XmlElement("mean", typeof(empty), Order = 1), XmlElement("moody", typeof(empty), Order = 1), XmlElement("nervous", typeof(empty), Order = 1), XmlElement("angry", typeof(empty), Order = 1), XmlElement("offended", typeof(empty), Order = 1), XmlElement("other", typeof(Note_t), Order = 1), XmlElement("playful", typeof(empty), Order = 1), XmlElement("proud", typeof(empty), Order = 1), XmlElement("relieved", typeof(empty), Order = 1), XmlElement("remorseful", typeof(empty), Order = 1), XmlElement("restless", typeof(empty), Order = 1), XmlElement("sad", typeof(empty), Order = 1), XmlElement("sarcastic", typeof(empty), Order = 1), XmlElement("serious", typeof(empty), Order = 1), XmlElement("shocked", typeof(empty), Order = 1), XmlElement("shy", typeof(empty), Order = 1), XmlElement("sick", typeof(empty), Order = 1), XmlElement("sleepy", typeof(empty), Order = 1), XmlElement("stressed", typeof(empty), Order = 1), XmlElement("surprised", typeof(empty), Order = 1), XmlElement("thirsty", typeof(empty), Order = 1), XmlElement("unknown", typeof(empty), Order = 1), XmlElement("worried", typeof(empty), Order = 1), XmlElement("neutral", typeof(empty), Order = 1), XmlElement("afraid", typeof(empty), Order = 1), XmlElement("amazed", typeof(empty), Order = 1)]
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
		public ItemsChoiceType1[] ItemsElementName
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
