using System;

namespace DispCore.Events.Sip
{
	public class InfoEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		public const string EXTRA_CODE = "code";

		public const string EXTRA_REMOTE_PARTY_STRING = "from";

		public const string EXTRA_CONTENT_TYPE_STRING = "content-Type";

		private readonly long sessionId;

		private readonly InfoEventTypes type;

		private readonly string phrase;

		private readonly byte[] payload;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public InfoEventTypes Type
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

		public InfoEventArgs(long sessionId, InfoEventTypes type, string phrase, byte[] payload)
		{
			this.sessionId = sessionId;
			this.type = type;
			this.phrase = phrase;
			this.payload = payload;
		}
	}
}
