using System;

namespace DispCore.Events
{
	public class MessageEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		public const string EXTRA_CODE = "code";

		public const string EXTRA_REMOTE_PARTY = "from";

		public const string EXTRA_CONTENT_TYPE = "content-Type";

		public const string EXTRA_SENDER = "PPI";

		private readonly long sessionId;

		private readonly MessageEventTypes type;

		private readonly string phrase;

		private readonly byte[] payload;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public MessageEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public byte[] Payload
		{
			get
			{
				return this.payload;
			}
		}

		public MessageEventArgs(long sessionId, MessageEventTypes type, string phrase, byte[] payload)
		{
			this.sessionId = sessionId;
			this.type = type;
			this.phrase = phrase;
			this.payload = payload;
		}
	}
}
