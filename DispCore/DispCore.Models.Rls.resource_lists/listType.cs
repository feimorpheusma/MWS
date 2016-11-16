using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Models.Rls.resource_lists
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot("list", Namespace = "urn:ietf:params:xml:ns:resource-lists"), XmlType(Namespace = "urn:ietf:params:xml:ns:resource-lists")]
	[System.Serializable]
	public class listType
	{
		private displaynameType displaynameField;

		private object[] itemsField;

		private XmlElement[] anyField;

		private string nameField;

		private XmlAttribute[] anyAttrField;

		private System.Collections.Generic.List<externalType> externalTypes = null;

		private System.Collections.Generic.List<entryType> entryTypes = null;

		private System.Collections.Generic.List<entryrefType> entryrefTypes = null;

		private System.Collections.Generic.List<listTypeList> listTypeLists = null;

		[XmlElement("display-name", Order = 0)]
		public displaynameType displayname
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

		[XmlElement("entry", typeof(entryType), Order = 1), XmlElement("external", typeof(externalType), Order = 1), XmlElement("entry-ref", typeof(entryrefType), Order = 1), XmlElement("list", typeof(listTypeList), Order = 1)]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		[XmlAnyElement(Order = 2)]
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

		[XmlElement("entry", Order = 9)]
		public System.Collections.Generic.List<entryType> EntryTypes
		{
			get
			{
				if (this.entryTypes == null)
				{
					this.entryTypes = new System.Collections.Generic.List<entryType>();
				}
				if (this.entryTypes.Count == 0 && this.Items != null)
				{
					object[] items = this.Items;
					for (int i = 0; i < items.Length; i++)
					{
						object item = items[i];
						entryType etype = item as entryType;
						if (etype != null)
						{
							this.entryTypes.Add(etype);
						}
					}
				}
				return this.entryTypes;
			}
			set
			{
				this.entryTypes = value;
			}
		}

		[XmlIgnore]
		public System.Collections.Generic.List<entryrefType> EntryrefTypes
		{
			get
			{
				if (this.entryrefTypes == null)
				{
					this.entryrefTypes = new System.Collections.Generic.List<entryrefType>();
					if (this.Items != null)
					{
						object[] items = this.Items;
						for (int i = 0; i < items.Length; i++)
						{
							object item = items[i];
							entryrefType entryrefType = item as entryrefType;
							if (entryrefType != null)
							{
								this.entryrefTypes.Add(entryrefType);
							}
						}
					}
				}
				return this.entryrefTypes;
			}
		}

		[XmlElement("external", Order = 8)]
		public System.Collections.Generic.List<externalType> ExternalTypes
		{
			get
			{
				if (this.externalTypes == null)
				{
					this.externalTypes = new System.Collections.Generic.List<externalType>();
				}
				if (this.externalTypes.Count == 0 && this.Items != null)
				{
					object[] items = this.Items;
					for (int i = 0; i < items.Length; i++)
					{
						object item = items[i];
						externalType externalType = item as externalType;
						if (externalType != null)
						{
							this.externalTypes.Add(externalType);
						}
					}
				}
				return this.externalTypes;
			}
			set
			{
				this.externalTypes = value;
			}
		}

		[XmlIgnore]
		public System.Collections.Generic.List<listTypeList> ListTypeLists
		{
			get
			{
				if (this.listTypeLists == null)
				{
					this.listTypeLists = new System.Collections.Generic.List<listTypeList>();
					if (this.Items != null)
					{
						object[] items = this.Items;
						for (int i = 0; i < items.Length; i++)
						{
							object item = items[i];
							listTypeList listTypeList = item as listTypeList;
							if (listTypeList != null)
							{
								this.listTypeLists.Add(listTypeList);
							}
						}
					}
				}
				return this.listTypeLists;
			}
		}
	}
}
