using System;

namespace DispCore.Events
{
	public class MsrpEventArgs : MyEventArgs
	{
		public const string EXTRA_SESSION = "session";

		public const string EXTRA_DATA = "data";

		public const string EXTRA_CONTENT_TYPE = "content-type";

		public const string EXTRA_WRAPPED_CONTENT_TYPE = "w-content-type";

		public const string EXTRA_BYTE_RANGE_START = "byte-start";

		public const string EXTRA_BYTE_RANGE_END = "byte-end";

		public const string EXTRA_BYTE_RANGE_TOTAL = "byte-total";

		public const string EXTRA_RESPONSE_CODE = "response-code";

		public const string EXTRA_REQUEST_TYPE = "request-type";

		private readonly long sessionId;

		private readonly MsrpEventTypes type;

		public long SessionId
		{
			get
			{
				return this.sessionId;
			}
		}

		public MsrpEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public MsrpEventArgs(long sessionId, MsrpEventTypes type)
		{
			this.sessionId = sessionId;
			this.type = type;
		}
	}
}
