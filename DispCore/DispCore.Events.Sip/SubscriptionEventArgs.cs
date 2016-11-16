using System;

namespace DispCore.Events.Sip
{
	public class SubscriptionEventArgs : MyEventArgs
	{
		public const string EXTRA_REMOTEURI = "from";

		public const string EXTRA_SESSION = "session";

		public const string EXTRA_CONTENTYPE_TYPE = "ContentTypeType";

		public const string EXTRA_CONTENTYPE_START = "ContentTypeStart";

		public const string EXTRA_CONTENTYPE_BOUNDARY = "ContentTypeBoundary";

		private readonly SubscriptionEventTypes type;

		private readonly short sipCode;

		private readonly string phrase;

		private readonly byte[] content;

		private readonly string contentType;

		private readonly long sessionId;

		private readonly string strfromUri;

		public SubscriptionEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public short SipCode
		{
			get
			{
				return this.sipCode;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public byte[] Content
		{
			get
			{
				return this.content;
			}
		}

		public string ContentType
		{
			get
			{
				return this.contentType;
			}
		}

		public string FromUri
		{
			get
			{
				return this.strfromUri;
			}
		}

		public SubscriptionEventArgs(SubscriptionEventTypes type, long sessionId, short sipCode, string phrase, byte[] content, string contentType, string strFromUri)
		{
			this.type = type;
			this.sessionId = sessionId;
			this.sipCode = sipCode;
			this.phrase = phrase;
			this.content = content;
			this.contentType = contentType;
			this.strfromUri = strFromUri;
		}
	}
}
