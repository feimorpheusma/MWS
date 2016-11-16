using DispApp.Generated.oma.pidf_pres;
using DispApp.Generated.pidf_caps;
using DispApp.Generated.rpid;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[System.Serializable]
	public class tuple
	{
		private status statusField;

		private XmlElement[] anyField;

		private contact contactField;

		private note[] noteField;

		private System.DateTime timestampField;

		private bool timestampFieldSpecified;

		private string idField;

		private static readonly XmlSerializer serviceDescriptionSerializer = new XmlSerializer(typeof(servicedescription));

		private static readonly XmlSerializer willingnessSerializer = new XmlSerializer(typeof(willingness));

		private servicedescription serviceDescriptionElement;

		private string deviceIDField;

		private willingness willingnessElement;

		private relationship relationshipElement;

		private servcapstype caps;

		[XmlElement(Order = 0)]
		public status status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}

		[XmlAnyElement(Order = 1)]
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

		[XmlElement(Order = 2)]
		public contact contact
		{
			get
			{
				return this.contactField;
			}
			set
			{
				this.contactField = value;
			}
		}

		[XmlElement("note", Order = 3)]
		public note[] note
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

		[XmlElement(Order = 4)]
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

		[XmlElement("willingness", Namespace = "urn:oma:xml:prs:pidf:oma-pres", Order = 5)]
		public willingness willingness
		{
			get
			{
				if (this.willingnessElement == null && this.anyField != null)
				{
					this.willingnessElement = this.GetElement<willingness>("willingness", "urn:oma:xml:prs:pidf:oma-pres", tuple.willingnessSerializer);
				}
				return this.willingnessElement;
			}
			set
			{
				this.willingnessElement = value;
			}
		}

		[XmlElement("service-description", Namespace = "urn:oma:xml:prs:pidf:oma-pres", Order = 6)]
		public servicedescription serviceDescription
		{
			get
			{
				if (this.serviceDescriptionElement == null && this.anyField != null)
				{
					this.serviceDescriptionElement = this.GetElement<servicedescription>("service-description", "urn:oma:xml:prs:pidf:oma-pres", tuple.serviceDescriptionSerializer);
				}
				return this.serviceDescriptionElement;
			}
			set
			{
				this.serviceDescriptionElement = value;
			}
		}

		[XmlElement("deviceID", Namespace = "urn:ietf:params:xml:ns:pidf:data-model", Order = 7)]
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

		[XmlElement("relationship", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", Order = 8)]
		public relationship relationship
		{
			get
			{
				return this.relationshipElement;
			}
			set
			{
				this.relationshipElement = value;
			}
		}

		[XmlElement("servcaps", Namespace = "urn:ietf:params:xml:ns:pidf:caps", Order = 9)]
		public servcapstype servcaps
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

		private T GetElement<T>(string name, string ns, XmlSerializer serializer) where T : class
		{
			T result = default(T);
			XmlElement[] array = this.anyField;
			for (int i = 0; i < array.Length; i++)
			{
				XmlElement xmlElement = array[i];
				if (xmlElement.LocalName.Equals(name) && xmlElement.NamespaceURI.Equals(ns))
				{
					string xml = xmlElement.OuterXml;
					using (System.IO.Stream stream = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(xml)))
					{
						result = (serializer.Deserialize(stream) as T);
						break;
					}
				}
			}
			return result;
		}
	}
}
