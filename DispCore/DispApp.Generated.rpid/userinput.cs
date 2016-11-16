using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.rpid
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("user-input", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:rpid")]
	[System.Serializable]
	public class userinput
	{
		private string idlethresholdField;

		private System.DateTime lastinputField;

		private bool lastinputFieldSpecified;

		private string idField;

		private XmlAttribute[] anyAttrField;

		private activeIdle valueField;

		[XmlAttribute("idle-threshold", DataType = "positiveInteger")]
		public string idlethreshold
		{
			get
			{
				return this.idlethresholdField;
			}
			set
			{
				this.idlethresholdField = value;
			}
		}

		[XmlAttribute("last-input")]
		public System.DateTime lastinput
		{
			get
			{
				return this.lastinputField;
			}
			set
			{
				this.lastinputField = value;
			}
		}

		[XmlIgnore]
		public bool lastinputSpecified
		{
			get
			{
				return this.lastinputFieldSpecified;
			}
			set
			{
				this.lastinputFieldSpecified = value;
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

		[XmlText]
		public activeIdle Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
	}
}
