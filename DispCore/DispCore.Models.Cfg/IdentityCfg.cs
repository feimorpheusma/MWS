using DispCore.Services;
using System;
using System.ComponentModel;

namespace DispCore.Models.Cfg
{
	public class IdentityCfg : INotifyPropertyChanged
	{
		private string impi;

		private string impu;

		private string password;

		private string displayName;

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

		public string Impi
		{
			get
			{
				return this.impi;
			}
			set
			{
				if (this.impi != value)
				{
					this.impi = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPI, value);
					}
					this.OnPropertyChanged("Impi");
				}
			}
		}

		public string Impu
		{
			get
			{
				return this.impu;
			}
			set
			{
				if (this.impu != value)
				{
					this.impu = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPU, value);
					}
					this.OnPropertyChanged("Impu");
				}
			}
		}

		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				if (this.password != value)
				{
					this.password = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.PASSWORD, value);
					}
					this.OnPropertyChanged("Password");
				}
			}
		}

		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				if (this.displayName != value)
				{
					this.displayName = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.DISPLAY_NAME, value);
					}
					this.OnPropertyChanged("DisplayName");
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
				if (this.realm != value)
				{
					this.realm = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, value);
					}
					this.OnPropertyChanged("Realm");
				}
			}
		}

		public IdentityCfg(string impi, string impu, string password, string displayName, string realm)
		{
			this.impi = impi;
			this.impu = impu;
			this.password = password;
			this.displayName = displayName;
			this.realm = realm;
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
