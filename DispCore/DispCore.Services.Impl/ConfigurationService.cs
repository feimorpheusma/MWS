using DispCore.Events;
using DispCore.Models.Cfg;
using DispCore.Utils;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Timers;
using System.Xml.Serialization;

namespace DispCore.Services.Impl
{
	public class ConfigurationService : IConfigurationService, IService
	{
		[XmlRoot("section", ElementName = "section")]
		[System.Serializable]
		public class XmlSection : System.IEquatable<ConfigurationService.XmlSection>, System.IComparable<ConfigurationService.XmlSection>, INotifyPropertyChanged
		{
			private string name;

			private MyObservableCollection<ConfigurationService.XmlSectionEntry> entries;

			public event PropertyChangedEventHandler PropertyChanged;

			[XmlElement("entry")]
			public MyObservableCollection<ConfigurationService.XmlSectionEntry> Entries
			{
				get
				{
					return this.entries;
				}
				set
				{
					this.entries = value;
				}
			}

			[XmlAttribute("name")]
			public string Name
			{
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
					this.OnPropertyChanged("Name");
				}
			}

			public XmlSection() : this(null)
			{
			}

			public XmlSection(string name)
			{
				this.name = name;
				this.entries = new MyObservableCollection<ConfigurationService.XmlSectionEntry>();
			}

			public bool Equals(ConfigurationService.XmlSection other)
			{
				if (other == null)
				{
					throw new System.ArgumentNullException("other");
				}
				return this.Name.Equals(other.Name);
			}

			public int CompareTo(ConfigurationService.XmlSection other)
			{
				if (other == null)
				{
					throw new System.ArgumentNullException("other");
				}
				return this.Name.CompareTo(other.Name);
			}

			protected void OnPropertyChanged(string propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}

		[XmlRoot("entry", ElementName = "entry")]
		[System.Serializable]
		public class XmlSectionEntry : System.IEquatable<ConfigurationService.XmlSectionEntry>, System.IComparable<ConfigurationService.XmlSectionEntry>, INotifyPropertyChanged
		{
			private string key;

			private string value;

			public event PropertyChangedEventHandler PropertyChanged;

			[XmlAttribute("key")]
			public string Key
			{
				get
				{
					return this.key;
				}
				set
				{
					this.key = value;
					this.OnPropertyChanged("Key");
				}
			}

			[XmlAttribute("value")]
			public string Value
			{
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
					this.OnPropertyChanged("Value");
				}
			}

			public XmlSectionEntry() : this(null, null)
			{
			}

			public XmlSectionEntry(string key, string value)
			{
				this.key = key;
				this.value = value;
			}

			public bool Equals(ConfigurationService.XmlSectionEntry other)
			{
				if (other == null)
				{
					throw new System.ArgumentNullException("other");
				}
				return this.Key.Equals(other.Key);
			}

			public int CompareTo(ConfigurationService.XmlSectionEntry other)
			{
				if (other == null)
				{
					throw new System.ArgumentNullException("other");
				}
				return this.Key.CompareTo(other.Key);
			}

			protected void OnPropertyChanged(string propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}

		private const string FILE_NAME = "configuration.xml";

		private static readonly ILog LOG = LogManager.GetLogger(typeof(ConfigurationService));

		private ServiceManager serviceManager;

		private string fileFullPath;

		private MyObservableCollection<ConfigurationService.XmlSection> sections;

		private readonly Timer deferredSaveTimer;

		private readonly XmlSerializer xmlSerializer;

		private IdentityCfg identityCfg;

		private NetworkCfg networkCfg;

		private ContactsCfg contactsCfg;

		private CodecsCfg codecsCfg;

		private GeneralCfg generalCfg;

		private QosCfg qosParaCfg;

		public event System.EventHandler<ConfigurationEventArgs> onConfigurationEvent;

		public IdentityCfg IdentityCfg
		{
			get
			{
				if (this.identityCfg == null)
				{
					string impi = this.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPI, Configuration.DEFAULT_IDENTITY_IMPI);
					string impu = this.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPU, Configuration.DEFAULT_IDENTITY_IMPU);
					string password = this.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.PASSWORD, string.Empty);
					string displayName = this.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.DISPLAY_NAME, Configuration.DEFAULT_IDENTITY_DISPLAY_NAME);
					string realm = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, Configuration.DEFAULT_NETWORK_REALM);
					this.identityCfg = new IdentityCfg(impi, impu, password, displayName, realm);
					this.identityCfg.ConfigurationService = this;
				}
				return this.identityCfg;
			}
		}

		public NetworkCfg NetworkCfg
		{
			get
			{
				if (this.networkCfg == null)
				{
					string proxyHost = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_HOST, Configuration.DEFAULT_NETWORK_PCSCF_HOST);
					string proxyPort = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_PORT, Configuration.DEFAULT_NETWORK_PCSCF_PORT.ToString());
					string localIP = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_IP, Configuration.DEFAULT_NETWORK_LOCAL_IP);
					string localPort = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_PORT, Configuration.DEFAULT_NETWORK_LOCAL_PORT.ToString());
					string transport = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.TRANSPORT, Configuration.DEFAULT_NETWORK_TRANSPORT);
					string ipVersion = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.IP_VERSION, Configuration.DEFAULT_NETWORK_IP_VERSION);
					bool isDiscoDNS = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_DISCOVERY_DNS, Configuration.DEFAULT_NETWORK_PCSCF_DISCOVERY_DNS);
					bool isDiscoDHCP = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_DISCOVERY_DHCP, Configuration.DEFAULT_NETWORK_PCSCF_DISCOVERY_DHCP);
					bool isSigcomp = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.SIGCOMP, Configuration.DEFAULT_NETWORK_SIGCOMP);
					bool isEarlyIMS = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.EARLY_IMS, Configuration.DEFAULT_NETWORK_EARLY_IMS);
					string strRealm = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, Configuration.DEFAULT_NETWORK_REALM);
					this.networkCfg = new NetworkCfg(ipVersion, proxyHost, proxyPort, transport, localIP, localPort, isEarlyIMS, isDiscoDNS, isDiscoDHCP, isSigcomp, strRealm);
					this.networkCfg.ConfigurationService = this;
				}
				return this.networkCfg;
			}
		}

		public ContactsCfg ContactsCfg
		{
			get
			{
				if (this.contactsCfg == null)
				{
					string contactStorageType = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.CONTACT_STORAGE, Configuration.DEFAULT_REMOTE_CONTACT_TYPE);
					string remoteContactType = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.REMOTE_CONTACT_TYPE, Configuration.DEFAULT_REMOTE_CONTACT_TYPE);
					string xcapRoot = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_ROOT, Configuration.DEFAULT_XCAP_ROOT);
					string xcapXui = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_XUI, Configuration.DEFAULT_XUI);
					string xcapPassword = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_PASSWORD, string.Empty);
					string xcapTimeout = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.TIMEOUT, Configuration.DEFAULT_XCAP_TIMEOUT.ToString());
					string strPcscfIp = this.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_HOST, Configuration.DEFAULT_NETWORK_PCSCF_HOST);
					string xcapRootIP = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_ROOT_IP, strPcscfIp);
					string xcapName = this.Get(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_USERNAME, "");
					this.contactsCfg = new ContactsCfg(contactStorageType, remoteContactType, xcapRoot, xcapXui, xcapPassword, xcapTimeout);
					this.contactsCfg.ConfigurationService = this;
					this.contactsCfg.XcapRootIP = xcapRootIP;
					this.contactsCfg.XcapName = xcapName;
				}
				return this.contactsCfg;
			}
		}

		public CodecsCfg CodecsCfg
		{
			get
			{
				if (this.codecsCfg == null)
				{
					int codecs = this.Get(Configuration.ConfFolder.MEDIA, Configuration.ConfEntry.CODECS, Configuration.DEFAULT_MEDIA_CODECS);
					this.codecsCfg = new CodecsCfg(codecs);
					this.codecsCfg.ConfigurationService = this;
				}
				return this.codecsCfg;
			}
		}

		public QosCfg QosParaCfg
		{
			get
			{
				if (this.qosParaCfg == null)
				{
					tmedia_pref_video_size_t prefVideoSize = (tmedia_pref_video_size_t)System.Enum.Parse(typeof(tmedia_pref_video_size_t), this.Get(Configuration.ConfFolder.QOS, Configuration.ConfEntry.PREF_VIDEO_SIZE, Configuration.DEFAULT_QOS_PREF_VIDEO_SIZE));
					int fps = this.Get(Configuration.ConfFolder.QOS, Configuration.ConfEntry.VIDEO_FPS, Configuration.DEFAULT_QOS_VIDEO_FPS);
					this.qosParaCfg = new QosCfg(prefVideoSize, fps);
					this.qosParaCfg.ConfigurationService = this;
				}
				return this.qosParaCfg;
			}
		}

		public GeneralCfg GeneralCfg
		{
			get
			{
				if (this.generalCfg == null)
				{
					string enumDomain = this.Get(Configuration.ConfFolder.GENERAL, Configuration.ConfEntry.ENUM_DOMAIN, Configuration.DEFAULT_GENERAL_ENUM_DOMAIN);
					bool isAutoStart = this.Get(Configuration.ConfFolder.GENERAL, Configuration.ConfEntry.AUTO_START, Configuration.DEFAULT_GENERAL_AUTOSTART);
					this.generalCfg = new GeneralCfg(isAutoStart, enumDomain);
					this.generalCfg.ConfigurationService = this;
				}
				return this.generalCfg;
			}
		}

		public ConfigurationService(ServiceManager manager)
		{
			this.serviceManager = manager;
			this.xmlSerializer = new XmlSerializer(typeof(MyObservableCollection<ConfigurationService.XmlSection>));
			this.deferredSaveTimer = new Timer(2500.0);
			this.deferredSaveTimer.AutoReset = false;
		}

		public bool Start()
		{
			bool ret = true;
			this.fileFullPath = this.serviceManager.BuildStoragePath("configuration.xml");
			ConfigurationService.LOG.Debug(string.Format("Loading XML configuration from {0}", this.fileFullPath));
			try
			{
				if (!System.IO.File.Exists(this.fileFullPath))
				{
					ConfigurationService.LOG.Debug(string.Format("{0} doesn't exist, trying to create new one", this.fileFullPath));
					System.IO.File.Create(this.fileFullPath).Close();
					this.sections = new MyObservableCollection<ConfigurationService.XmlSection>();
					this.ImmediateSave();
				}
				using (System.IO.StreamReader reader = new System.IO.StreamReader(this.fileFullPath))
				{
					try
					{
						this.sections = (this.xmlSerializer.Deserialize(reader) as MyObservableCollection<ConfigurationService.XmlSection>);
					}
					catch (System.InvalidOperationException ie)
					{
						ConfigurationService.LOG.Error("Failed to load configuration", ie);
						reader.Close();
						System.IO.File.Delete(this.fileFullPath);
					}
				}
				this.deferredSaveTimer.Elapsed += delegate(object param0, ElapsedEventArgs param1)
				{
					this.ImmediateSave();
				};
			}
			catch (System.Exception e)
			{
				ConfigurationService.LOG.Error("Failed to load configuration", e);
				ret = false;
			}
			return ret;
		}

		public bool Stop()
		{
			if (this.deferredSaveTimer.Enabled)
			{
				try
				{
					this.deferredSaveTimer.Stop();
					this.ImmediateSave();
				}
				catch (System.UnauthorizedAccessException e)
				{
					ConfigurationService.LOG.Error(e);
				}
			}
			return true;
		}

		public string Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, string defaultValue)
		{
			string result = defaultValue;
			try
			{
				lock (this.sections)
				{
					ConfigurationService.XmlSection section = this.sections.FirstOrDefault((ConfigurationService.XmlSection x) => string.Equals(x.Name, folder.ToString()));
					if (section != null)
					{
						ConfigurationService.XmlSectionEntry sectionEntry = section.Entries.FirstOrDefault((ConfigurationService.XmlSectionEntry x) => string.Equals(x.Key, entry.ToString()));
						if (sectionEntry != null)
						{
							result = sectionEntry.Value;
						}
					}
				}
			}
			catch (System.Exception e)
			{
				ConfigurationService.LOG.Error(e);
			}
			return result;
		}

		public bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, string value)
		{
			bool result;
			if (value == null)
			{
				result = false;
			}
			else
			{
				try
				{
					lock (this.sections)
					{
						ConfigurationService.XmlSection section = this.sections.FirstOrDefault((ConfigurationService.XmlSection x) => string.Equals(x.Name, folder.ToString()));
						if (section == null)
						{
							section = new ConfigurationService.XmlSection(folder.ToString());
							this.sections.Add(section);
						}
						ConfigurationService.XmlSectionEntry sectionEntry = section.Entries.FirstOrDefault((ConfigurationService.XmlSectionEntry x) => string.Equals(x.Key, entry.ToString()));
						if (sectionEntry == null)
						{
							sectionEntry = new ConfigurationService.XmlSectionEntry(entry.ToString(), value);
							section.Entries.Add(sectionEntry);
						}
						else
						{
							sectionEntry.Value = value;
						}
					}
				}
				catch (System.Exception e)
				{
					ConfigurationService.LOG.Error("Failed to set value into registry", e);
					result = false;
					return result;
				}
				EventHandlerTrigger.TriggerEvent<ConfigurationEventArgs>(this.onConfigurationEvent, this, new ConfigurationEventArgs(folder, entry, value));
				this.DeferredSave();
				result = true;
			}
			return result;
		}

		public int Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, int defaultValue)
		{
			int result = defaultValue;
			string value = this.Get(folder, entry, defaultValue.ToString());
			int result2;
			if (int.TryParse(value, out result))
			{
				result2 = result;
			}
			else
			{
				result2 = defaultValue;
			}
			return result2;
		}

		public bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, int value)
		{
			return this.Set(folder, entry, value.ToString());
		}

		public bool Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, bool defaultValue)
		{
			return System.Convert.ToBoolean(this.Get(folder, entry, defaultValue ? bool.TrueString : bool.FalseString));
		}

		public bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, bool value)
		{
			return this.Set(folder, entry, value ? bool.TrueString : bool.FalseString);
		}

		private void DeferredSave()
		{
			this.deferredSaveTimer.Stop();
			this.deferredSaveTimer.Start();
		}

		private bool ImmediateSave()
		{
			bool result;
			lock (this.sections)
			{
				ConfigurationService.LOG.Debug("Saving configuration...");
				try
				{
					using (System.IO.StreamWriter writer = new System.IO.StreamWriter(this.fileFullPath))
					{
						this.xmlSerializer.Serialize(writer, this.sections);
						writer.Flush();
						writer.Close();
					}
					result = true;
					return result;
				}
				catch (System.IO.IOException ioe)
				{
					ConfigurationService.LOG.Error("Failed to save configuration", ioe);
				}
			}
			result = false;
			return result;
		}
	}
}
