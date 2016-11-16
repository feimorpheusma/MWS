using DispCore.Services;
using System;
using System.ComponentModel;

namespace DispCore.Models.Cfg
{
	public class NetworkCfg : INotifyPropertyChanged
	{
		private bool isEarlyIMS;

		private string ipVersion;

		private bool isDiscoDNS;

		private bool isDiscoDHCP;

		private string proxyHost;

		private string proxyPort;

		private bool isSigcomp;

		private string transport;

		private string localIP;

		private string localPort;

		private string realm;

		private IConfigurationService configurationService;

		public event PropertyChangedEventHandler PropertyChanged;

		public IConfigurationService ConfigurationService
		{
			set
			{
				this.configurationService = value;
			}
		}

		public bool IsEarlyIMS
		{
			get
			{
				return this.isEarlyIMS;
			}
			set
			{
				if (this.isEarlyIMS != value)
				{
					this.isEarlyIMS = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.EARLY_IMS, value);
						this.OnPropertyChanged("IsEarlyIMS");
					}
				}
			}
		}

		public string IpVersion
		{
			get
			{
				return this.ipVersion;
			}
			set
			{
				if (this.ipVersion != value)
				{
					this.ipVersion = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.IP_VERSION, value);
						this.OnPropertyChanged("IpVersion");
					}
				}
			}
		}

		public bool IsDiscoDHCP
		{
			get
			{
				return this.isDiscoDHCP;
			}
			set
			{
				if (this.isDiscoDHCP != value)
				{
					this.isDiscoDHCP = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_DISCOVERY_DHCP, value);
						this.OnPropertyChanged("IsDiscoDHCP");
					}
				}
			}
		}

		public bool IsDiscoDNS
		{
			get
			{
				return this.isDiscoDNS;
			}
			set
			{
				if (this.isDiscoDNS != value)
				{
					this.isDiscoDNS = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_DISCOVERY_DNS, value);
						this.OnPropertyChanged("IsDiscoDNS");
					}
				}
			}
		}

		public string ProxyHost
		{
			get
			{
				return this.proxyHost;
			}
			set
			{
				if (this.proxyHost != value)
				{
					this.proxyHost = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_HOST, value);
						this.OnPropertyChanged("ProxyHost");
					}
				}
			}
		}

		public string ProxyPort
		{
			get
			{
				return this.proxyPort;
			}
			set
			{
				if (this.proxyPort != value)
				{
					this.proxyPort = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_PORT, value);
						this.OnPropertyChanged("ProxyPort");
					}
				}
			}
		}

		public string Transport
		{
			get
			{
				return this.transport;
			}
			set
			{
				if (this.transport != value)
				{
					this.transport = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.TRANSPORT, value);
						this.OnPropertyChanged("Transport");
					}
				}
			}
		}

		public string LocalIP
		{
			get
			{
				return this.localIP;
			}
			set
			{
				if (this.localIP != value)
				{
					this.localIP = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_IP, value);
						this.OnPropertyChanged("LocalIP");
					}
				}
			}
		}

		public string LocalPort
		{
			get
			{
				return this.localPort;
			}
			set
			{
				if (this.localPort != value)
				{
					this.localPort = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_PORT, value);
						this.OnPropertyChanged("LocalPort");
					}
				}
			}
		}

		public bool IsSigcomp
		{
			get
			{
				return this.isSigcomp;
			}
			set
			{
				if (this.isSigcomp != value)
				{
					this.isSigcomp = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.SIGCOMP, value);
						this.OnPropertyChanged("IsSigcomp");
					}
				}
			}
		}

		public string Realm
		{
			get
			{
				return this.realm;
			}
			set
			{
				this.realm = value;
				if (this.configurationService != null)
				{
					this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, value);
					this.OnPropertyChanged("Realm");
				}
			}
		}

		public NetworkCfg(string ipVersion, string proxyHost, string proxyPort, string transport, string localIP, string localPort, bool isEarlyIMS, bool isDiscoDNS, bool isDiscoDHCP, bool isSigcomp, string strRealm)
		{
			this.ipVersion = ipVersion;
			this.proxyHost = proxyHost;
			this.proxyPort = proxyPort;
			this.transport = transport;
			this.localIP = localIP;
			this.localPort = localPort;
			this.isEarlyIMS = isEarlyIMS;
			this.isDiscoDNS = isDiscoDNS;
			this.isDiscoDHCP = isDiscoDHCP;
			this.isSigcomp = isSigcomp;
			this.realm = strRealm;
		}

		public void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
