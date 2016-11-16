using System;

namespace DispCore.Services.Impl
{
	public abstract class ServiceManager
	{
		public abstract string ApplicationDataPath
		{
			get;
		}

		public abstract bool IsMultiInstanceEnabled
		{
			get;
		}

		public abstract IConfigurationService ConfigurationService
		{
			get;
		}

		public abstract IScreenService ScreenService
		{
			get;
		}

		public abstract IContactService ContactService
		{
			get;
		}

		public abstract IHistoryService HistoryService
		{
			get;
		}

		public abstract ISoundService SoundService
		{
			get;
		}

		public abstract IAccessNetworkService AccessNetworkService
		{
			get;
		}

		public abstract IStatusService StatusService
		{
			get;
		}

		public abstract IServiceRealizeService ServiceRealizeService
		{
			get;
		}

		public abstract IStackService StackService
		{
			get;
		}

		public abstract string BuildStoragePath(string folder);
	}
}
