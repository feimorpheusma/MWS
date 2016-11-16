using System;

namespace DispCore.Events.Sip
{
	public class MessagingEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		public const string EXTRA_CODE = "code";

		public const string EXTRA_REMOTE_PARTY = "from";

		public const string EXTRA_CONTENT_TYPE = "content-Type";

		public const string EXTRA_ORIGNEVENT = "orign-event";

		public const string EXTRA_SENDER = "PPI";

		private readonly long sessionId;

		private readonly MessagingEventTypes type;

		private readonly string phrase;

		private readonly byte[] payload;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public MessagingEventTypes Type
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

		public byte[] Payload
		{
			get
			{
				return this.payload;
			}
		}

		public MessagingEventArgs(long sessionId, MessagingEventTypes type, string phrase, byte[] payload)
		{
			this.sessionId = sessionId;
			this.type = type;
			this.phrase = phrase;
			this.payload = payload;
		}
	}
}
