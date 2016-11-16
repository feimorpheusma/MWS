using System;

namespace DispCore.Events
{
	public class ServiceSessionChangedEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		private ServiceSessionChangedEventTypes type;

		private long sessionId;

		private string remoteUri;

		public ServiceSessionChangedEventTypes Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
			set
			{
				this.sessionId = value;
			}
		}

		public string RemoteUri
		{
			get
			{
				return this.remoteUri;
			}
			set
			{
				this.remoteUri = value;
			}
		}

		public ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes type, long sessionId, string remoteUri)
		{
			this.type = type;
			this.sessionId = sessionId;
			this.remoteUri = remoteUri;
		}
	}
}
