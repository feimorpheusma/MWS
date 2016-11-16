using System;

namespace DispCore.Events
{
	public enum MsrpEventTypes
	{
		CONNECTED,
		SUCCESS_2XX,
		SUCCESS_REPORT,
		FAILURE_REPORT,
		DATA,
		ERROR,
		DISCONNECTED
	}
}
