using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("servcaps", Namespace = "urn:ietf:params:xml:ns:pidf:caps", IsNullable = false), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class servcapstype
	{
		private actortype actorField;

		private bool applicationField;

		private bool applicationFieldSpecified;

		private bool audioField;

		private bool audioFieldSpecified;

		private bool automataField;

		private bool automataFieldSpecified;

		private classtype classField;

		private bool controlField;

		private bool controlFieldSpecified;

		private bool dataField;

		private bool dataFieldSpecified;

		private descriptiontype[] descriptionField;

		private duplextype duplexField;

		private eventpackagestype eventpackagesField;

		private extensionstype extensionsField;

		private bool isfocusField;

		private bool isfocusFieldSpecified;

		private bool messageField;

		private bool messageFieldSpecified;

		private methodstype methodsField;

		private languagestype languagesField;

		private prioritytype priorityField;

		private schemestype schemesField;

		private bool textField;

		private bool textFieldSpecified;

		private string[] typeField;

		private bool videoField;

		private bool videoFieldSpecified;

		private XmlElement[] anyField;

		private XmlAttribute[] anyAttrField;

		[XmlElement(Order = 0)]
		public actortype actor
		{
			get
			{
				return this.actorField;
			}
			set
			{
				this.actorField = value;
			}
		}

		[XmlElement(Order = 1)]
		public bool application
		{
			get
			{
				return this.applicationField;
			}
			set
			{
				this.applicationField = value;
			}
		}

		[XmlIgnore]
		public bool applicationSpecified
		{
			get
			{
				return this.applicationFieldSpecified;
			}
			set
			{
				this.applicationFieldSpecified = value;
			}
		}

		[XmlElement(Order = 2)]
		public bool audio
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

		[XmlIgnore]
		public bool audioSpecified
		{
			get
			{
				return this.audioFieldSpecified;
			}
			set
			{
				this.audioFieldSpecified = value;
			}
		}

		[XmlElement(Order = 3)]
		public bool automata
		{
			get
			{
				return this.automataField;
			}
			set
			{
				this.automataField = value;
			}
		}

		[XmlIgnore]
		public bool automataSpecified
		{
			get
			{
				return this.automataFieldSpecified;
			}
			set
			{
				this.automataFieldSpecified = value;
			}
		}

		[XmlElement(Order = 4)]
		public classtype @class
		{
			get
			{
				return this.classField;
			}
			set
			{
				this.classField = value;
			}
		}

		[XmlElement(Order = 5)]
		public bool control
		{
			get
			{
				return this.controlField;
			}
			set
			{
				this.controlField = value;
			}
		}

		[XmlIgnore]
		public bool controlSpecified
		{
			get
			{
				return this.controlFieldSpecified;
			}
			set
			{
				this.controlFieldSpecified = value;
			}
		}

		[XmlElement(Order = 6)]
		public bool data
		{
			get
			{
				return this.dataField;
			}
			set
			{
				this.dataField = value;
			}
		}

		[XmlIgnore]
		public bool dataSpecified
		{
			get
			{
				return this.dataFieldSpecified;
			}
			set
			{
				this.dataFieldSpecified = value;
			}
		}

		[XmlElement("description", Order = 7)]
		public descriptiontype[] description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		[XmlElement(Order = 8)]
		public duplextype duplex
		{
			get
			{
				return this.duplexField;
			}
			set
			{
				this.duplexField = value;
			}
		}

		[XmlElement("event-packages", Order = 9)]
		public eventpackagestype eventpackages
		{
			get
			{
				return this.eventpackagesField;
			}
			set
			{
				this.eventpackagesField = value;
			}
		}

		[XmlElement(Order = 10)]
		public extensionstype extensions
		{
			get
			{
				return this.extensionsField;
			}
			set
			{
				this.extensionsField = value;
			}
		}

		[XmlElement(Order = 11)]
		public bool isfocus
		{
			get
			{
				return this.isfocusField;
			}
			set
			{
				this.isfocusField = value;
			}
		}

		[XmlIgnore]
		public bool isfocusSpecified
		{
			get
			{
				return this.isfocusFieldSpecified;
			}
			set
			{
				this.isfocusFieldSpecified = value;
			}
		}

		[XmlElement(Order = 12)]
		public bool message
		{
			get
			{
				return this.messageField;
			}
			set
			{
				this.messageField = value;
			}
		}

		[XmlIgnore]
		public bool messageSpecified
		{
			get
			{
				return this.messageFieldSpecified;
			}
			set
			{
				this.messageFieldSpecified = value;
			}
		}

		[XmlElement(Order = 13)]
		public methodstype methods
		{
			get
			{
				return this.methodsField;
			}
			set
			{
				this.methodsField = value;
			}
		}

		[XmlElement(Order = 14)]
		public languagestype languages
		{
			get
			{
				return this.languagesField;
			}
			set
			{
				this.languagesField = value;
			}
		}

		[XmlElement(Order = 15)]
		public prioritytype priority
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

		[XmlElement(Order = 16)]
		public schemestype schemes
		{
			get
			{
				return this.schemesField;
			}
			set
			{
				this.schemesField = value;
			}
		}

		[XmlElement(Order = 17)]
		public bool text
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

		[XmlIgnore]
		public bool textSpecified
		{
			get
			{
				return this.textFieldSpecified;
			}
			set
			{
				this.textFieldSpecified = value;
			}
		}

		[XmlElement("type", Order = 18)]
		public string[] type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		[XmlElement(Order = 19)]
		public bool video
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

		[XmlIgnore]
		public bool videoSpecified
		{
			get
			{
				return this.videoFieldSpecified;
			}
			set
			{
				this.videoFieldSpecified = value;
			}
		}

		[XmlAnyElement(Order = 20)]
		public XmlElement[] Any
		{
			get
			{
				return this.anyField;
			}
			set
			{
				this.anyField = value;
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
