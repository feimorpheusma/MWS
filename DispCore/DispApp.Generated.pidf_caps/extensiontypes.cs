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
	public class extensiontypes
	{
		private string rel100Field;

		private string earlysessionField;

		private string eventlistField;

		private string fromchangeField;

		private string gruuField;

		private string histinfoField;

		private string joinField;

		private string norefersubField;

		private string pathField;

		private string preconditionField;

		private string prefField;

		private string privacyField;

		private string replacesField;

		private string resourcepriorityField;

		private string sdpanatField;

		private string secagreeField;

		private string tdialogField;

		private string timerField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string rel100
		{
			get
			{
				return this.rel100Field;
			}
			set
			{
				this.rel100Field = value;
			}
		}

		[XmlElement("early-session", Order = 1)]
		public string earlysession
		{
			get
			{
				return this.earlysessionField;
			}
			set
			{
				this.earlysessionField = value;
			}
		}

		[XmlElement(Order = 2)]
		public string eventlist
		{
			get
			{
				return this.eventlistField;
			}
			set
			{
				this.eventlistField = value;
			}
		}

		[XmlElement("from-change", Order = 3)]
		public string fromchange
		{
			get
			{
				return this.fromchangeField;
			}
			set
			{
				this.fromchangeField = value;
			}
		}

		[XmlElement(Order = 4)]
		public string gruu
		{
			get
			{
				return this.gruuField;
			}
			set
			{
				this.gruuField = value;
			}
		}

		[XmlElement("hist-info", Order = 5)]
		public string histinfo
		{
			get
			{
				return this.histinfoField;
			}
			set
			{
				this.histinfoField = value;
			}
		}

		[XmlElement(Order = 6)]
		public string join
		{
			get
			{
				return this.joinField;
			}
			set
			{
				this.joinField = value;
			}
		}

		[XmlElement(Order = 7)]
		public string norefersub
		{
			get
			{
				return this.norefersubField;
			}
			set
			{
				this.norefersubField = value;
			}
		}

		[XmlElement(Order = 8)]
		public string path
		{
			get
			{
				return this.pathField;
			}
			set
			{
				this.pathField = value;
			}
		}

		[XmlElement(Order = 9)]
		public string precondition
		{
			get
			{
				return this.preconditionField;
			}
			set
			{
				this.preconditionField = value;
			}
		}

		[XmlElement(Order = 10)]
		public string pref
		{
			get
			{
				return this.prefField;
			}
			set
			{
				this.prefField = value;
			}
		}

		[XmlElement(Order = 11)]
		public string privacy
		{
			get
			{
				return this.privacyField;
			}
			set
			{
				this.privacyField = value;
			}
		}

		[XmlElement(Order = 12)]
		public string replaces
		{
			get
			{
				return this.replacesField;
			}
			set
			{
				this.replacesField = value;
			}
		}

		[XmlElement("resource-priority", Order = 13)]
		public string resourcepriority
		{
			get
			{
				return this.resourcepriorityField;
			}
			set
			{
				this.resourcepriorityField = value;
			}
		}

		[XmlElement("sdp-anat", Order = 14)]
		public string sdpanat
		{
			get
			{
				return this.sdpanatField;
			}
			set
			{
				this.sdpanatField = value;
			}
		}

		[XmlElement("sec-agree", Order = 15)]
		public string secagree
		{
			get
			{
				return this.secagreeField;
			}
			set
			{
				this.secagreeField = value;
			}
		}

		[XmlElement(Order = 16)]
		public string tdialog
		{
			get
			{
				return this.tdialogField;
			}
			set
			{
				this.tdialogField = value;
			}
		}

		[XmlElement(Order = 17)]
		public string timer
		{
			get
			{
				return this.timerField;
			}
			set
			{
				this.timerField = value;
			}
		}

		[XmlAnyElement(Order = 18)]
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
