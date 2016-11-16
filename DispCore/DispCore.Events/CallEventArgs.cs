using System;

namespace DispCore.Events
{
	public class CallEventArgs : MyEventArgs
	{
		public const string EXTRA_CALLTYPE = "calltype";

		public const string EXTRA_CALLATTRIBUTE = "callattribute";

		public const string EXTRA_E2EE = "e2ee";

		public const string EXTRA_DUPLEX = "duplex";

		public const string EXTRA_FOAOROACSU = "foaoroacsu";

		public const string EXTRA_CODE = "code";

		public const string EXTRA_SESSION = "session";

		public const string EXTRA_SESSIONTYPE = "sessiontype";

		public const string EXTRA_SIPMESSAGE = "sipemessage";

		public const string EXTRA_ORIGNEVENT = "orignevent";

		private readonly CallEventTypes type;

		private readonly long sessionId;

		private readonly string phrase;

		public CallEventTypes Type
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

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public CallEventArgs(CallEventTypes type, long sessionId, string phrase)
		{
			this.type = type;
			this.sessionId = sessionId;
			this.phrase = phrase;
		}
	}
}
