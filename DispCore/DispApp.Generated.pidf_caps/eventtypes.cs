using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf_caps
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf:caps")]
	[System.Serializable]
	public class eventtypes
	{
		private string conferenceField;

		private string dialogField;

		private string kpmlField;

		private string messagesummaryField;

		private string pocsettingsField;

		private string presenceField;

		private string regField;

		private string referField;

		private string siemensRTPStatsField;

		private string spiritsINDPsField;

		private string spiritsuserprofField;

		private string winfoField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string conference
		{
			get
			{
				return this.conferenceField;
			}
			set
			{
				this.conferenceField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string dialog
		{
			get
			{
				return this.dialogField;
			}
			set
			{
				this.dialogField = value;
			}
		}

		[XmlElement(Order = 2)]
		public string kpml
		{
			get
			{
				return this.kpmlField;
			}
			set
			{
				this.kpmlField = value;
			}
		}

		[XmlElement("message-summary", Order = 3)]
		public string messagesummary
		{
			get
			{
				return this.messagesummaryField;
			}
			set
			{
				this.messagesummaryField = value;
			}
		}

		[XmlElement("poc-settings", Order = 4)]
		public string pocsettings
		{
			get
			{
				return this.pocsettingsField;
			}
			set
			{
				this.pocsettingsField = value;
			}
		}

		[XmlElement(Order = 5)]
		public string presence
		{
			get
			{
				return this.presenceField;
			}
			set
			{
				this.presenceField = value;
			}
		}

		[XmlElement(Order = 6)]
		public string reg
		{
			get
			{
				return this.regField;
			}
			set
			{
				this.regField = value;
			}
		}

		[XmlElement(Order = 7)]
		public string refer
		{
			get
			{
				return this.referField;
			}
			set
			{
				this.referField = value;
			}
		}

		[XmlElement("Siemens-RTP-Stats", Order = 8)]
		public string SiemensRTPStats
		{
			get
			{
				return this.siemensRTPStatsField;
			}
			set
			{
				this.siemensRTPStatsField = value;
			}
		}

		[XmlElement("spirits-INDPs", Order = 9)]
		public string spiritsINDPs
		{
			get
			{
				return this.spiritsINDPsField;
			}
			set
			{
				this.spiritsINDPsField = value;
			}
		}

		[XmlElement("spirits-user-prof", Order = 10)]
		public string spiritsuserprof
		{
			get
			{
				return this.spiritsuserprofField;
			}
			set
			{
				this.spiritsuserprofField = value;
			}
		}

		[XmlElement(Order = 11)]
		public string winfo
		{
			get
			{
				return this.winfoField;
			}
			set
			{
				this.winfoField = value;
			}
		}

		[XmlAnyElement(Order = 12)]
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
	}
}
