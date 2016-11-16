using DispCore.Services;
using System;
using System.ComponentModel;

namespace DispCore.Models.Cfg
{
	public class GeneralCfg : INotifyPropertyChanged
	{
		private string enumDomain;

		private bool isAutoStart;

		private IConfigurationService configurationService;

		public event PropertyChangedEventHandler PropertyChanged;

		public IConfigurationService ConfigurationService
		{
			set
			{
				this.configurationService = value;
			}
		}

		public string EnumDomain
		{
			get
			{
				return this.enumDomain;
			}
			set
			{
				if (this.enumDomain != value)
				{
					this.enumDomain = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.GENERAL, Configuration.ConfEntry.ENUM_DOMAIN, value);
						this.OnPropertyChanged("EnumDomain");
					}
				}
			}
		}

		public bool IsAutoStart
		{
			get
			{
				return this.isAutoStart;
			}
			set
			{
				if (this.isAutoStart != value)
				{
					this.isAutoStart = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.GENERAL, Configuration.ConfEntry.AUTO_START, value);
						this.OnPropertyChanged("IsAutoStart");
					}
				}
			}
		}

		public GeneralCfg(bool isAutoStart, string enumDomain)
		{
			this.enumDomain = enumDomain;
			this.isAutoStart = isAutoStart;
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
