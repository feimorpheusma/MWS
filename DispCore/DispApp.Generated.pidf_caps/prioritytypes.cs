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
	public class prioritytypes
	{
		private equalstype[] equalsField;

		private higherthantype[] higherhanField;

		private lowerthantype[] lowerthanField;

		private rangetype[] rangeField;

		private XmlElement[] anyField;

		[XmlElement("equals", Order = 0)]
		public equalstype[] equals
		{
			get
			{
				return this.equalsField;
			}
			set
			{
				this.equalsField = value;
			}
		}

		[XmlElement("higherhan", Order = 1)]
		public higherthantype[] higherhan
		{
			get
			{
				return this.higherhanField;
			}
			set
			{
				this.higherhanField = value;
			}
		}

		[XmlElement("lowerthan", Order = 2)]
		public lowerthantype[] lowerthan
		{
			get
			{
				return this.lowerthanField;
			}
			set
			{
				this.lowerthanField = value;
			}
		}

		[XmlElement("range", Order = 3)]
		public rangetype[] range
		{
			get
			{
				return this.rangeField;
			}
			set
			{
				this.rangeField = value;
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
