using DispApp.Generated.oma.pidf_pres;
using DispApp.Generated.rpid;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DispApp.Generated.data_model
{
	[GeneratedCode("xsd", "2.0.50727.3038"), DesignerCategory("code"), System.Diagnostics.DebuggerStepThrough, XmlRoot(Namespace = "urn:ietf:params:xml:ns:pidf:data-model", IsNullable = false), XmlType(AnonymousType = true, Namespace = "urn:ietf:params:xml:ns:pidf:data-model")]
	[System.Serializable]
	public class person
	{
		private XmlElement[] anyField;

		private Note_t[] noteField;

		private string timestampField;

		private bool timestampFieldSpecified;

		private string idField;

		private static readonly XmlSerializer overridingwillingnessSerializer = new XmlSerializer(typeof(overridingwillingness));

		private static readonly XmlSerializer activitiesSerializer = new XmlSerializer(typeof(activities));

		private static readonly XmlSerializer moodSerializer = new XmlSerializer(typeof(mood));

		private static readonly XmlSerializer statusIconSerializer = new XmlSerializer(typeof(statusicon));

		private activities activitiesElement;

		private mood moodElement;

		private overridingwillingness overridingWillingnessElement;

		private statusicon statusIconElement;

		private string cardField;

		private string displayNameField;

		private string homepageField;

		private string iconField;

		private string mapField;

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

		[XmlElement("note", Order = 10)]
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

		[XmlElement(Order = 20)]
		public string timestamp
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

		[XmlElement("overriding-willingness", Namespace = "urn:oma:xml:prs:pidf:oma-pres", Order = 0)]
		public overridingwillingness overridingWillingness
		{
			get
			{
				if (this.overridingWillingnessElement == null && this.anyField != null)
				{
					this.overridingWillingnessElement = this.GetElement<overridingwillingness>("overriding-willingness", "urn:oma:xml:prs:pidf:oma-pres", person.overridingwillingnessSerializer);
				}
				return this.overridingWillingnessElement;
			}
			set
			{
				this.overridingWillingnessElement = value;
			}
		}

		[XmlElement("activities", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", Order = 1)]
		public activities activities
		{
			get
			{
				if (this.activitiesElement == null && this.anyField != null)
				{
					this.activitiesElement = this.GetElement<activities>("activities", "urn:ietf:params:xml:ns:pidf:rpid", person.activitiesSerializer);
				}
				return this.activitiesElement;
			}
			set
			{
				this.activitiesElement = value;
			}
		}

		[XmlElement("mood", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", Order = 2)]
		public mood mood
		{
			get
			{
				if (this.moodElement == null && this.anyField != null)
				{
					this.moodElement = this.GetElement<mood>("mood", "urn:ietf:params:xml:ns:pidf:rpid", person.moodSerializer);
				}
				return this.moodElement;
			}
			set
			{
				this.moodElement = value;
			}
		}

		[XmlElement("status-icon", Namespace = "urn:ietf:params:xml:ns:pidf:rpid", Order = 3)]
		public statusicon statusicon
		{
			get
			{
				if (this.statusIconElement == null && this.anyField != null)
				{
					this.statusIconElement = this.GetElement<statusicon>("status-icon", "urn:ietf:params:xml:ns:pidf:rpid", person.statusIconSerializer);
				}
				return this.statusIconElement;
			}
			set
			{
				this.statusIconElement = value;
			}
		}

		[XmlElement("card", Namespace = "urn:ietf:params:xml:ns:pidf:cipid", Order = 4)]
		public string card
		{
			get
			{
				if (this.cardField == null && this.anyField != null)
				{
					this.cardField = this.GetValue("card", "urn:ietf:params:xml:ns:pidf:cipid");
				}
				return this.cardField;
			}
			set
			{
				this.cardField = value;
			}
		}

		[XmlElement("display-name", Namespace = "urn:ietf:params:xml:ns:pidf:cipid", Order = 5)]
		public string displayName
		{
			get
			{
				if (this.displayNameField == null && this.anyField != null)
				{
					this.displayNameField = this.GetValue("display-name", "urn:ietf:params:xml:ns:pidf:cipid");
				}
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		[XmlElement("homepage", Namespace = "urn:ietf:params:xml:ns:pidf:cipid", Order = 6)]
		public string homepage
		{
			get
			{
				if (this.homepageField == null && this.anyField != null)
				{
					this.homepageField = this.GetValue("homepage", "urn:ietf:params:xml:ns:pidf:cipid");
				}
				return this.homepageField;
			}
			set
			{
				this.homepageField = value;
			}
		}

		[XmlElement("icon", Namespace = "urn:ietf:params:xml:ns:pidf:cipid", Order = 7)]
		public string icon
		{
			get
			{
				if (this.iconField == null && this.anyField != null)
				{
					this.iconField = this.GetValue("icon", "urn:ietf:params:xml:ns:pidf:cipid");
				}
				return this.iconField;
			}
			set
			{
				this.iconField = value;
			}
		}

		[XmlElement("map", Namespace = "urn:ietf:params:xml:ns:pidf:cipid", Order = 8)]
		public string map
		{
			get
			{
				if (this.mapField == null && this.anyField != null)
				{
					this.mapField = this.GetValue("map", "urn:ietf:params:xml:ns:pidf:cipid");
				}
				return this.mapField;
			}
			set
			{
				this.mapField = value;
			}
		}

		public string GetNote()
		{
			string result = string.Empty;
			if (this.note != null && this.note.Length > 0)
			{
				result = this.note[0].Value;
			}
			else if (this.anyField != null)
			{
				result = this.GetValue("note", "urn:ietf:params:xml:ns:pidf:data-model");
			}
			return result;
		}

		public string GetTimeStamp()
		{
			string result = string.Empty;
			if (!string.IsNullOrEmpty(this.timestamp))
			{
				result = this.timestamp;
			}
			else if (this.anyField != null)
			{
				result = this.GetValue("timestamp", "urn:ietf:params:xml:ns:pidf:data-model");
			}
			return result;
		}

		private string GetValue(string name, string ns)
		{
			XmlElement[] array = this.anyField;
			string result;
			for (int i = 0; i < array.Length; i++)
			{
				XmlElement xmlElement = array[i];
				if (xmlElement.LocalName.Equals(name) && xmlElement.NamespaceURI.Equals(ns))
				{
					result = xmlElement.InnerText;
					return result;
				}
			}
			result = null;
			return result;
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
