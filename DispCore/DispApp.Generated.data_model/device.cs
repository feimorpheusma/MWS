using DispApp.Generated.oma.pidf_pres;
using DispApp.Generated.pidf;
using DispApp.Generated.pidf_caps;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.data_model
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:data-model", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
	[System.Serializable]
	public class device
	{
		private XmlElement[] anyField;

		private string deviceIDField;

		private Note_t[] noteField;

		private System.DateTime timestampField;

		private bool timestampFieldSpecified;

		private string idField;

		private status status;

		private devcaps caps;

		private networkavailability netAvaibility;

		[XmlAnyElement(Order = 9)]
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

		[XmlElement(DataType = "anyURI", Order = 10)]
		public string deviceID
		{
			get
			{
				return this.deviceIDField;
			}
			set
			{
				this.deviceIDField = value;
			}
		}

		[XmlElement("note", Order = 20)]
		public Note_t[] note
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

		[XmlElement(Order = 30)]
		public System.DateTime timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}

		[XmlIgnore]
		public bool timestampSpecified
		{
			get
			{
				return this.timestampFieldSpecified;
			}
			set
			{
				this.timestampFieldSpecified = value;
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

		[XmlElement("status", Namespace = "urn:ietf:params:xml:ns:pidf", Order = 5)]
		public status Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		[XmlElement("devcaps", Namespace = "urn:ietf:params:xml:ns:pidf:caps", Order = 6)]
		public devcaps DeviceCapabilities
		{
			get
			{
				return this.caps;
			}
			set
			{
				this.caps = value;
			}
		}

		[XmlElement("network-availability", Namespace = "urn:oma:xml:prs:pidf:oma-pres", Order = 7)]
		public networkavailability NetworkAvaibility
		{
			get
			{
				return this.netAvaibility;
			}
			set
			{
				this.netAvaibility = value;
			}
		}
	}
}
