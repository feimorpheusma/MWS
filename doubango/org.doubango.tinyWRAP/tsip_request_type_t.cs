using System;

namespace org.doubango.tinyWRAP
{
	public enum tsip_request_type_t
	{
		tsip_NONE,
		tsip_ACK,
		tsip_BYE,
		tsip_CANCEL,
		tsip_INVITE,
		tsip_OPTIONS,
		tsip_REGISTER,
		tsip_SUBSCRIBE,
		tsip_NOTIFY,
		tsip_REFER,
		tsip_INFO,
		tsip_UPDATE,
		tsip_MESSAGE,
		tsip_PUBLISH,
		tsip_PRACK
	}
}
