using System;

namespace DispCore.Events
{
	public class HeartbeartEventArgs : MyEventArgs
	{
		public const string EXTRA_CODE = "code";

		private HeartbeatEventTypes type;

		private long sessionId;

		private string phrase;

		public HeartbeartEventArgs(HeartbeatEventTypes type, long sessionId, string phrase)
		{
			this.type = type;
			this.sessionId = sessionId;
			this.phrase = phrase;
		}
	}
}
