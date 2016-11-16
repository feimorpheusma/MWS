using System;

namespace DispCore.Models
{
	public enum InviteState
	{
		NONE,
		INCOMING,
		INPROGRESS,
		REMOTE_RINGING,
		EARLY_MEDIA,
		INCALL,
		LOCAL_HELD,
		REMOTE_HELD,
		TERMINATING,
		TERMINATED,
		POST_TERMINATED
	}
}
