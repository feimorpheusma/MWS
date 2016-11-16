using DispCore.Events;
using DispCore.Models.Cfg;
using System;

namespace DispCore.Services
{
	public interface IConfigurationService : IService
	{
		event System.EventHandler<ConfigurationEventArgs> onConfigurationEvent;

		IdentityCfg IdentityCfg
		{
			get;
		}

		NetworkCfg NetworkCfg
		{
			get;
		}

		ContactsCfg ContactsCfg
		{
			get;
		}

		CodecsCfg CodecsCfg
		{
			get;
		}

		GeneralCfg GeneralCfg
		{
			get;
		}

		QosCfg QosParaCfg
		{
			get;
		}

		string Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, string defaultValue);

		bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, string value);

		int Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, int defaultValue);

		bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, int value);

		bool Get(Configuration.ConfFolder folder, Configuration.ConfEntry entry, bool defaultValue);

		bool Set(Configuration.ConfFolder folder, Configuration.ConfEntry entry, bool value);
	}
}
