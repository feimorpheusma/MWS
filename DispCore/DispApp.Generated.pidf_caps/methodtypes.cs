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
	public class methodtypes
	{
		private string aCKField;

		private string bYEField;

		private string cANCELField;

		private string iNFOField;

		private string iNVITEField;

		private string mESSAGEField;

		private string nOTIFYField;

		private string oPTIONSField;

		private string pRACKField;

		private string pUBLISHField;

		private string rEFERField;

		private string rEGISTERField;

		private string sUBSCRIBEField;

		private string uPDATEField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string ACK
		{
			get
			{
				return this.aCKField;
			}
			set
			{
				this.aCKField = value;
			}
		}

		[XmlElement(Order = 1)]
		public string BYE
		{
			get
			{
				return this.bYEField;
			}
			set
			{
				this.bYEField = value;
			}
		}

		[XmlElement(Order = 2)]
		public string CANCEL
		{
			get
			{
				return this.cANCELField;
			}
			set
			{
				this.cANCELField = value;
			}
		}

		[XmlElement(Order = 3)]
		public string INFO
		{
			get
			{
				return this.iNFOField;
			}
			set
			{
				this.iNFOField = value;
			}
		}

		[XmlElement(Order = 4)]
		public string INVITE
		{
			get
			{
				return this.iNVITEField;
			}
			set
			{
				this.iNVITEField = value;
			}
		}

		[XmlElement(Order = 5)]
		public string MESSAGE
		{
			get
			{
				return this.mESSAGEField;
			}
			set
			{
				this.mESSAGEField = value;
			}
		}

		[XmlElement(Order = 6)]
		public string NOTIFY
		{
			get
			{
				return this.nOTIFYField;
			}
			set
			{
				this.nOTIFYField = value;
			}
		}

		[XmlElement(Order = 7)]
		public string OPTIONS
		{
			get
			{
				return this.oPTIONSField;
			}
			set
			{
				this.oPTIONSField = value;
			}
		}

		[XmlElement(Order = 8)]
		public string PRACK
		{
			get
			{
				return this.pRACKField;
			}
			set
			{
				this.pRACKField = value;
			}
		}

		[XmlElement(Order = 9)]
		public string PUBLISH
		{
			get
			{
				return this.pUBLISHField;
			}
			set
			{
				this.pUBLISHField = value;
			}
		}

		[XmlElement(Order = 10)]
		public string REFER
		{
			get
			{
				return this.rEFERField;
			}
			set
			{
				this.rEFERField = value;
			}
		}

		[XmlElement(Order = 11)]
		public string REGISTER
		{
			get
			{
				return this.rEGISTERField;
			}
			set
			{
				this.rEGISTERField = value;
			}
		}

		[XmlElement(Order = 12)]
		public string SUBSCRIBE
		{
			get
			{
				return this.sUBSCRIBEField;
			}
			set
			{
				this.sUBSCRIBEField = value;
			}
		}

		[XmlElement(Order = 13)]
		public string UPDATE
		{
			get
			{
				return this.uPDATEField;
			}
			set
			{
				this.uPDATEField = value;
			}
		}

		[XmlAnyElement(Order = 14)]
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
