using DispApp.Generated.data_model;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.pidf
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf", IsNullable = false), XmlType(Namespace = "urn:ietf:params:xml:ns:pidf")]
	[System.Serializable]
	public class presence
	{
		private tuple[] tupleField;

		private note[] noteField;

		private XmlElement[] anyField;

		private string entityField;

		private static readonly XmlSerializer personSerializer = new XmlSerializer(typeof(person));

		private static readonly XmlSerializer deviceSerializer = new XmlSerializer(typeof(device));

		private person[] persons = null;

		private device device = null;

		[XmlElement("tuple", Order = 0)]
		public tuple[] tuple
		{
			get
			{
				return this.tupleField;
			}
			set
			{
				this.tupleField = value;
			}
		}

		[XmlElement("note", Order = 1)]
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

		[XmlAttribute(DataType = "anyURI")]
		public string entity
		{
			get
			{
				return this.entityField;
			}
			set
			{
				this.entityField = value;
			}
		}

		[XmlElement("person", Namespace = "urn:ietf:params:xml:ns:pidf:data-model", Order = 18)]
		public person[] Persons
		{
			get
			{
				if (this.persons == null)
				{
					System.Collections.Generic.List<person> values = this.GetElements<person>("person", "urn:ietf:params:xml:ns:pidf:data-model", presence.personSerializer);
					if (values.Count > 0)
					{
						this.persons = values.ToArray();
					}
				}
				return this.persons;
			}
			set
			{
				this.persons = value;
			}
		}

		[XmlElement("device", Namespace = "urn:ietf:params:xml:ns:pidf:data-model", Order = 19)]
		public device Device
		{
			get
			{
				if (this.device == null)
				{
					System.Collections.Generic.List<device> values = this.GetElements<device>("device", "urn:ietf:params:xml:ns:pidf:data-model", presence.deviceSerializer);
					if (values.Count > 0)
					{
						this.device = values[0];
					}
				}
				return this.device;
			}
			set
			{
				this.device = value;
			}
		}

		private System.Collections.Generic.List<T> GetElements<T>(string name, string ns, XmlSerializer serializer) where T : class
		{
			System.Collections.Generic.List<T> result = new System.Collections.Generic.List<T>();
			if (this.anyField != null)
			{
				XmlElement[] array = this.anyField;
				for (int i = 0; i < array.Length; i++)
				{
					XmlElement xmlElement = array[i];
					if (xmlElement.LocalName.Equals(name) && xmlElement.NamespaceURI.Equals(ns))
					{
						string xml = xmlElement.OuterXml;
						using (System.IO.Stream stream = new System.IO.MemoryStream(System.Text.Encoding.Default.GetBytes(xml)))
						{
							T t = serializer.Deserialize(stream) as T;
							if (t != null)
							{
								result.Add(t);
							}
						}
					}
				}
			}
			return result;
		}
	}
}
