using System;

namespace DispCore.Trunk.Types
{
	public enum TrunkCallType
	{
		TCT_NONE,
		TCT_P2P_AUDIO_CALL,
		TCT_P2P_VIDEO_CALL,
		TCT_P2P_VIDEOONLY_CALL,
		TCT_GRP_AUDIO_CALL,
		TCT_GRP_VIDEO_CALL,
		TCT_GRP_VIDEOONLY_CALL,
		TCT_GRP_DIF_VIDE_CALL,
		TCT_BRD_AUDIO_CALL,
		TCT_BRD_VIDEO_CALL,
		TCT_BRD_VIDEOONLY_CALL,
		TCT_ENV_LISTEN = 16,
		TCT_VIDEO_PULL_CALL = 20,
		TCT_VIDEO_POLL_CALL,
		TCT_VIDEO_BACK_CALL,
		TCT_VIDEO_PUSH_CALL,
		TCT_DUMMY_VIDEO_DISPATCH = 90
	}
}