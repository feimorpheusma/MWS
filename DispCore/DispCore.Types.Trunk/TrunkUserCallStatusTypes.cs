using System;

namespace DispCore.Types.Trunk
{
	public enum TrunkUserCallStatusTypes
	{
		TUCST_PTT_SPEAKER = 1,
		TUCST_PTT_LISTENER,
		TUCST_DUPLEX_TALKING,
		TUCST_IDLE,
		TUCST_GROUP_IDLE = 21,
		TUCST_GROUP_RUNG
	}
}
