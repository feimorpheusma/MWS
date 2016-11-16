using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("place-is", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class placeis
	{
		private Note_t noteField;

		private placeisAudio audioField;

		private placeisVideo videoField;

		private placeisText textField;

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

		[XmlElement(Order = 1)]
		public placeisAudio audio
		{
			get
			{
				return this.audioField;
			}
			set
			{
				this.audioField = value;
			}
		}

		[XmlElement(Order = 2)]
		public placeisVideo video
		{
			get
			{
				return this.videoField;
			}
			set
			{
				this.videoField = value;
			}
		}

		[XmlElement(Order = 3)]
		public placeisText text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
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
