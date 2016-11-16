using System;

namespace DispCore.Events
{
	public enum ServiceSessionChangedEventTypes
	{
		NONE,
		NEW_INCOMING_SESSION,
		NEW_OUTGOING_SESSION,
		DEL_SESSION,
		NEW_MSG_SESSION,
		MSG_SESSION_SENDING_RESULT
	}
}
