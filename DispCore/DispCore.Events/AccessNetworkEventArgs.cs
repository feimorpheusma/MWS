using DispCore.Services;
using System;

namespace DispCore.Events
{
	public class AccessNetworkEventArgs : MyEventArgs
	{
		private AccessNetworkEventTypes type;

		private ANStatus status;

		private string phrase;

		public AccessNetworkEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public ANStatus Status
		{
			get
			{
				return this.status;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public AccessNetworkEventArgs(AccessNetworkEventTypes type, ANStatus status, string phrase)
		{
			this.type = type;
			this.status = status;
			this.phrase = phrase;
		}
	}
}
