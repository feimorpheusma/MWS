using System;

namespace org.doubango.tinyWRAP
{
	public enum thttp_event_type_t
	{
		thttp_event_dialog_started,
		thttp_event_message,
		thttp_event_auth_failed,
		thttp_event_closed,
		thttp_event_transport_error,
		thttp_event_dialog_terminated
	}
}
