using System;

namespace DispCore.Events
{
	public class VideoSendEventArgs : MyEventArgs
	{
		public const string EXTRA_UDN = "UDN";

		public const string EXTRA_RESULT = "pttVideoForwardReport";

		public VideoSendEventTypes type;

		public VideoSendEventArgs(VideoSendEventTypes type)
		{
			this.type = type;
		}
	}
}
