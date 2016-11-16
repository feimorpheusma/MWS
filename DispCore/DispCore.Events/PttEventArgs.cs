using System;

namespace DispCore.Events
{
	public class PttEventArgs : MyEventArgs
	{
		public const string EXTRA_ALERT_TYPE = "Alerttype";

		public const string EXTRA_UDN = "UDN";

		public const string EXTRA_CALLID = "callid";

		public const string EXTRA_CONTENT_TYPE_STRING = "content-Type";

		private readonly PttEventTypes type;

		private readonly long sessionId;

		private readonly string phrase;

		private string strfromUri;

		private readonly byte[] payload;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public PttEventTypes EventType
		{
			get
			{
				return this.type;
			}
		}

		public string FromUri
		{
			get
			{
				return this.strfromUri;
			}
			set
			{
				this.strfromUri = value;
			}
		}

		public byte[] Payload
		{
			get
			{
				return this.payload;
			}
		}

		public PttEventArgs(PttEventTypes type, long sessionId, string phrase, byte[] payload)
		{
			this.type = type;
			this.sessionId = sessionId;
			this.phrase = phrase;
			this.payload = payload;
		}
	}
}
