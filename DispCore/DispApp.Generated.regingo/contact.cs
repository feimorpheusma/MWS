using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.regingo
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:reginfo", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:reginfo")]
	[System.Serializable]
	public class contact
	{
		private string uriField;

		private contactDisplayname displaynameField;

		private contactUnknownparam[] unknownparamField;

		private XmlElement[] anyField;

		private contactState stateField;

		private contactEvent eventField;

		private ulong durationregisteredField;

		private bool durationregisteredFieldSpecified;

		private ulong expiresField;

		private bool expiresFieldSpecified;

		private ulong retryafterField;

		private bool retryafterFieldSpecified;

		private string idField;

		private string qField;

		private string callidField;

		private ulong cseqField;

		private bool cseqFieldSpecified;

		[XmlElement(DataType = "anyURI", Order = 0)]
		public string uri
		{
			get
			{
				return this.uriField;
			}
			set
			{
				this.uriField = value;
			}
		}

		[XmlElement("display-name", Order = 1)]
		public contactDisplayname displayname
		{
			get
			{
				return this.displaynameField;
			}
			set
			{
				this.displaynameField = value;
			}
		}

		[XmlElement("unknown-param", Order = 2)]
		public contactUnknownparam[] unknownparam
		{
			get
			{
				return this.unknownparamField;
			}
			set
			{
				this.unknownparamField = value;
			}
		}

		[XmlAnyElement(Order = 3)]
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

		[XmlAttribute]
		public contactState state
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}

		[XmlAttribute]
		public contactEvent @event
		{
			get
			{
				return this.eventField;
			}
			set
			{
				this.eventField = value;
			}
		}

		[XmlAttribute("duration-registered")]
		public ulong durationregistered
		{
			get
			{
				return this.durationregisteredField;
			}
			set
			{
				this.durationregisteredField = value;
			}
		}

		[XmlIgnore]
		public bool durationregisteredSpecified
		{
			get
			{
				return this.durationregisteredFieldSpecified;
			}
			set
			{
				this.durationregisteredFieldSpecified = value;
			}
		}

		[XmlAttribute]
		public ulong expires
		{
			get
			{
				return this.expiresField;
			}
			set
			{
				this.expiresField = value;
			}
		}

		[XmlIgnore]
		public bool expiresSpecified
		{
			get
			{
				return this.expiresFieldSpecified;
			}
			set
			{
				this.expiresFieldSpecified = value;
			}
		}

		[XmlAttribute("retry-after")]
		public ulong retryafter
		{
			get
			{
				return this.retryafterField;
			}
			set
			{
				this.retryafterField = value;
			}
		}

		[XmlIgnore]
		public bool retryafterSpecified
		{
			get
			{
				return this.retryafterFieldSpecified;
			}
			set
			{
				this.retryafterFieldSpecified = value;
			}
		}

		[XmlAttribute]
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

		[XmlAttribute]
		public string q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}

		[XmlAttribute]
		public string callid
		{
			get
			{
				return this.callidField;
			}
			set
			{
				this.callidField = value;
			}
		}

		[XmlAttribute]
		public ulong cseq
		{
			get
			{
				return this.cseqField;
			}
			set
			{
				this.cseqField = value;
			}
		}

		[XmlIgnore]
		public bool cseqSpecified
		{
			get
			{
				return this.cseqFieldSpecified;
			}
			set
			{
				this.cseqFieldSpecified = value;
			}
		}
	}
}
