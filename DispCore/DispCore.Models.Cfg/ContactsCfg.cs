using DispCore.Services;
using DispCore.Utils;
using System;
using System.ComponentModel;

namespace DispCore.Models.Cfg
{
	public class ContactsCfg : INotifyPropertyChanged
	{
		private string contactStorageType;

		private string remoteContactType;

		private string xcapRoot;

		private string xcapRootIP;

		private string xcapName;

		private string xcapXui;

		private string xcapPassword;

		private string xcapTimeout;

		private IConfigurationService configurationService;

		public event PropertyChangedEventHandler PropertyChanged;

		public IConfigurationService ConfigurationService
		{
			set
			{
				this.configurationService = value;
			}
		}

		public string ContactStorageType
		{
			get
			{
				return this.contactStorageType;
			}
			set
			{
				if (this.contactStorageType != value)
				{
					this.contactStorageType = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.CONTACT_STORAGE, value.ToString());
						this.OnPropertyChanged("ContactStorageType");
					}
				}
			}
		}

		public string RemoteContactType
		{
			get
			{
				return this.remoteContactType;
			}
			set
			{
				if (this.remoteContactType != value)
				{
					this.remoteContactType = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.REMOTE_CONTACT_TYPE, value.ToString());
						this.OnPropertyChanged("RemoteContactType");
					}
				}
			}
		}

		public string XcapRoot
		{
			get
			{
				return this.xcapRoot;
			}
			set
			{
				if (this.xcapRoot != value)
				{
					this.xcapRoot = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_ROOT, value);
						this.OnPropertyChanged("XcapRoot");
					}
				}
			}
		}

		public string XcapRootIP
		{
			get
			{
				return this.xcapRootIP;
			}
			set
			{
				if (this.xcapRootIP != value)
				{
					this.XcapRoot = string.Format("http://{0}:1000/services", value);
					this.xcapRootIP = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_ROOT_IP, value);
						this.OnPropertyChanged("xcapRootIP");
					}
				}
			}
		}

		public string XcapXui
		{
			get
			{
				return this.xcapXui;
			}
			set
			{
				if (this.xcapXui != value)
				{
					this.xcapXui = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_XUI, value);
						this.OnPropertyChanged("Xui");
					}
				}
			}
		}

		public string XcapName
		{
			get
			{
				return this.xcapName;
			}
			set
			{
				if (this.xcapName != value)
				{
					this.xcapName = value;
					this.XcapXui = UriUtils.GetValidSipUri(value);
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_USERNAME, value);
						this.OnPropertyChanged("xcapName");
					}
				}
			}
		}

		public string XcapPassword
		{
			get
			{
				return this.xcapPassword;
			}
			set
			{
				if (this.xcapPassword != value)
				{
					this.xcapPassword = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_PASSWORD, value);
						this.OnPropertyChanged("XcapPassword");
					}
				}
			}
		}

		public string XcapTimeout
		{
			get
			{
				return this.xcapTimeout;
			}
			set
			{
				if (this.xcapTimeout != value)
				{
					this.xcapTimeout = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.CONTACTS, Configuration.ConfEntry.XCAP_TIMEOUT, value);
						this.OnPropertyChanged("XcapTimeout");
					}
				}
			}
		}

		public ContactsCfg(string contactStorageType, string remoteContactType, string xcapRoot, string xcapXui, string xcapPassword, string xcapTimeout)
		{
			this.contactStorageType = contactStorageType;
			this.remoteContactType = remoteContactType;
			this.xcapRoot = xcapRoot;
			this.xcapXui = xcapXui;
			this.xcapPassword = xcapPassword;
			this.xcapTimeout = xcapTimeout;
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
