using System;

namespace DispCore.Events.Sip
{
	public class InviteEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		public const string EXTRA_SIP_CODE = "sipcode";

		public const string EXTRA_REFERTO_URI = "refer-to-uri";

		private readonly long sessionId;

		private readonly InviteEventTypes type;

		private readonly string phrase;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public InviteEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public InviteEventArgs(long sessionId, InviteEventTypes type, string phrase)
		{
			this.sessionId = sessionId;
			this.type = type;
			this.phrase = phrase;
		}
	}
}
