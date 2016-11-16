using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.im_iscomposing
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:im-iscomposing", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:im-iscomposing")]
	[System.Serializable]
	public class isComposing
	{
		private string stateField;

		private System.DateTime lastactiveField;

		private bool lastactiveFieldSpecified;

		private string contenttypeField;

		private string refreshField;

		private XmlElement[] anyField;

		[XmlElement(Order = 0)]
		public string state
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

		[XmlElement(Order = 1)]
		public System.DateTime lastactive
		{
			get
			{
				return this.lastactiveField;
			}
			set
			{
				this.lastactiveField = value;
			}
		}

		[XmlIgnore]
		public bool lastactiveSpecified
		{
			get
			{
				return this.lastactiveFieldSpecified;
			}
			set
			{
				this.lastactiveFieldSpecified = value;
			}
		}

		[XmlElement(Order = 2)]
		public string contenttype
		{
			get
			{
				return this.contenttypeField;
			}
			set
			{
				this.contenttypeField = value;
			}
		}

		[XmlElement(DataType = "positiveInteger", Order = 3)]
		public string refresh
		{
			get
			{
				return this.refreshField;
			}
			set
			{
				this.refreshField = value;
			}
		}

		[XmlAnyElement(Order = 4)]
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
