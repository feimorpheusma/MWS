using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DispCore.Models.Rls
{
	[DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:doubango:params:xml:ns:properties"), XmlType(AnonymousType = true)]
	[System.Serializable]
	public class DoubangoProperty
	{
		public const string PROP_DISPLAY_NAME = "display-name";

		public const string PROP_FIRST_NAME = "first-name";

		private string nameField;

		private string valueField;

		[XmlAttribute]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		[XmlAttribute]
		public string value
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
