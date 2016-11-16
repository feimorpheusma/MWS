using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("place-type", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class placetype
	{
		private Note_t noteField;

		private object itemField;

		private ItemChoiceType3 itemElementNameField;

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

		[XmlAnyElement(Order = 1), XmlChoiceIdentifier("ItemElementName"), XmlElement("underway", typeof(empty), Order = 1), XmlElement("theater", typeof(empty), Order = 1), XmlElement("water", typeof(empty), Order = 1), XmlElement("watercraft", typeof(empty), Order = 1), XmlElement("airport", typeof(empty), Order = 1), XmlElement("arena", typeof(empty), Order = 1), XmlElement("street", typeof(empty), Order = 1), XmlElement("unknown", typeof(empty), Order = 1), XmlElement("train", typeof(empty), Order = 1), XmlElement("train-station", typeof(empty), Order = 1), XmlElement("warehouse", typeof(empty), Order = 1), XmlElement("truck", typeof(empty), Order = 1), XmlElement("aircraft", typeof(empty), Order = 1), XmlElement("automobile", typeof(empty), Order = 1), XmlElement("bank", typeof(empty), Order = 1), XmlElement("bar", typeof(empty), Order = 1), XmlElement("bus", typeof(empty), Order = 1), XmlElement("bus-station", typeof(empty), Order = 1), XmlElement("cafe", typeof(empty), Order = 1), XmlElement("classroom", typeof(empty), Order = 1), XmlElement("club", typeof(empty), Order = 1), XmlElement("construction", typeof(empty), Order = 1), XmlElement("convention-center", typeof(empty), Order = 1), XmlElement("cycle", typeof(empty), Order = 1), XmlElement("government", typeof(empty), Order = 1), XmlElement("hospital", typeof(empty), Order = 1), XmlElement("hotel", typeof(empty), Order = 1), XmlElement("industrial", typeof(empty), Order = 1), XmlElement("library", typeof(empty), Order = 1), XmlElement("office", typeof(empty), Order = 1), XmlElement("other", typeof(Note_t), Order = 1), XmlElement("outdoors", typeof(empty), Order = 1), XmlElement("parking", typeof(empty), Order = 1), XmlElement("place-of-worship", typeof(empty), Order = 1), XmlElement("prison", typeof(empty), Order = 1), XmlElement("public", typeof(empty), Order = 1), XmlElement("public-transport", typeof(empty), Order = 1), XmlElement("residence", typeof(empty), Order = 1), XmlElement("restaurant", typeof(empty), Order = 1), XmlElement("school", typeof(empty), Order = 1), XmlElement("shopping-area", typeof(empty), Order = 1), XmlElement("stadium", typeof(empty), Order = 1), XmlElement("store", typeof(empty), Order = 1)]
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
		public ItemChoiceType3 ItemElementName
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
