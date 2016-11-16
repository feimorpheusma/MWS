using DispCore.Models.Cfg;
using System;

namespace DispCore.Events
{
	public class ConfigurationEventArgs : MyEventArgs
	{
		private readonly Configuration.ConfFolder folder;

		private readonly Configuration.ConfEntry entry;

		private readonly object value;

		public Configuration.ConfFolder Folder
		{
			get
			{
				return this.folder;
			}
		}

		public Configuration.ConfEntry Entry
		{
			get
			{
				return this.entry;
			}
		}

		public object Value
		{
			get
			{
				return this.value;
			}
		}

		public ConfigurationEventArgs(Configuration.ConfFolder folder, Configuration.ConfEntry entry, object value)
		{
			this.folder = folder;
			this.entry = entry;
			this.value = value;
		}
	}
}
