using System;

namespace DispCore.Types
{
	public class X686Defs
	{
		public const string SERVICETYPE_SIGLEAUDIO = "singleaudio";

		public const string SERVICETYPE_SIGLEVIDEO = "singlevideo";

		public const string SERVICETYPE_MEETINGAUDIO = "audiocall;groupid=";

		public const string SERVICETYPE_MEETINGVIDEO = "videocall;groupid=";

		public const string SERVICETYPE_GROUPEAUDIO = "groupcall/audio";

		public const string SERVICETYPE_GROUPEVIDEO = "groupcall/video";

		public const string SERVICETYPE_MONITORAUDIO = "monitor";

		public const string SERVICETYPE_MONITORVIDEO = "jiankong";

		public const string SERVICETYPE_DPAQIAGNCHA = "qcha";

		public const string SERVICETYPE_DPAQIAGNCHI = "qchi";

		private const string SERVICETYPE_CALLHOLD = "hold";

		public const string SERVICETYPE_CALLCONT = "continue";

		public const string SERVICETYPE_ENVIROMONITOR = "envirmonitor";

		public const string SERVICETYPE_POINT = "PTTSet/";

		public const string PTT_TYPE_REQUEST = "Request";

		public const string PTT_TYPE_RELEASE = "Release";

		public const string PTT_TYPE_RELEASE_ACK = "Release Ack";

		public const string PTT_TYPE_REPORT = "Report";

		public const string PTT_TYPE_GRANT = "Grant";

		public const string PTT_TYPE_REJECT = "Reject";

		public const string PTT_TYPE_REJECT_ACK = "Reject Ack";

		public const string PTT_TYPE_CANCEL = "Cancel";

		public const string PTT_TYPE_CANCEL_ACK = "Cancel Ack";

		public const string PTT_TYPE_SUBSCRIBE = "Subscribe";

		public const string PTT_TYPE_SUBSCRIBE_ACK = "Subscribe Ack";
	}
}
