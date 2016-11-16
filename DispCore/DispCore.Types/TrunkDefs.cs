using DispCore.Trunk.Types;
using System;

namespace DispCore.Types
{
	public class TrunkDefs
	{
		public const string CallID_HEADER = "Call-ID";

		public const string EXTENSION_HEADER = "Ptt-Extension";

		public const string EXTENSION_PPI = "P-Asserted-Identity";

		public const string PTT_EXTENSION_HEARTBEAT = "pttheartbeat";

		public const string PTT_EXTENSION_KICKOFF = "pttkickoff";

		public const string KICKOFF_PARAM_CAUSE = "Cause";

		public const string KICKOFF_PARAM_KICKEDIP = "KickedIP";

		public const string PTT_EXTENSION_PTT_INFO = "pttinfo";

		public const string PTT_INFO_PARAM_ALERTTYPE = "Alerttype";

		public const string PTT_INFO_PARAM_UDN = "UDN";

		public const string PTT_REG_M_IDENTITY = "pttregister";

		public const string PTT_REG_O_DATAQUERY = "dataquery";

		public const string PTT_EXTENSION_MSG = "pttmsg";

		public const string PTT_EXTENSION_DGNA = "pptDGNA";

		public const string PTT_EXTENSION_REDGNA = "reDGNA";

		public const string REDGNA_PARAM_UDN = "UDN";

		public const string REDGNA_PARAM_DGNARESULT = "DGNAresult";

		public const string PTT_EXTENSION_STUN = "pttstun";

		public const string PTT_EXTENSION_KILL = "pttkill";

		public const string PTT_EXTENSION_REVIVE = "pttrevive";

		public const string PTT_EXTENSION_DISMANTLE = "pttdismantle";

		public const string PTT_EXTENSION_VIDEOSEND = "pttVideoForward";

		public const string PTT_EXTENSION_VIDEOSENDEND = "pttVideoTerminate";

		public const string PTT_EXTENSION_VIDEOSENDREPORT = "pttVideoForwardReport";

		public const string VIDEOSENDREPORT_PARAM_UDN = "UDN";

		public const string VIDEOSENDREPORT_PARAM_RESULT = "VideoSendResult";

		public const string PTT_EXTENSION_GETADDRLIST = "pttgetaddrlist";

		public const string PTT_EXTENSION_PUSHADDRLIST = "pttpushaddrlist";

		public const string PTT_EXTENSION_CALL = "pttcall";

		public const string CALL_PARAM_CALLTYPE = "calltype";

		public const string CALL_PARAM_CALLATTRIBUTE = "PrioAttribute";

		public const string CALL_PARAM_E2EE = "e2ee";

		public const string CALL_PARAM_DUPLEX = "duplex";

		public const string CALL_PARAM_FOAOROACSU = "foaoroacsu";

		public const string CALL_PARAM_PRIORITY = "priority";

		public const string CALL_PARAM_CALLERUDN = "callerUDN";

		public const string CALL_PARAM_ONLINECALLID = "OnlineCallID";

		public const string CALL_PARAM_CALLEDTYPE = "CalledType";

		public const string PTT_EXTENSION_PTTREQUEST = "pttrequest";

		public const string PTT_EXTENSION_PTTACCEPT = "pttaccept";

		public const string PTT_EXTENSION_PTTRELEASE = "pttreleasefloor";

		public const string PTT_EXTENSION_INSERT = "pttinsert";

		public const string PTT_EXTENSION_DL = "pttDL";

		public const string PTT_EXTENSION_AMBIANCELISTENING = "pttambiancelistening";

		public const string PTT_EXTENSION_RELEASE = "pttrelease";

		public const string PTT_EXTENSION_RELEASEINS = "pttreleaseins";

		public const string PTT_EXTENSION_RELEASEDL = "pttreleaseDL";

		public const string PTT_EXTENSION_PTTWAITING = "pttwaiting";

		public static bool IsAudioTypeCall(TrunkCallType callType)
		{
			return callType == TrunkCallType.TCT_P2P_AUDIO_CALL || callType == TrunkCallType.TCT_GRP_AUDIO_CALL;
		}
	}
}
