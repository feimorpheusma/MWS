using System;

namespace org.doubango.tinyWRAP
{
	public enum tsip_invite_event_type_t
	{
		tsip_i_newcall,
		tsip_i_request,
		tsip_ao_request,
		tsip_o_ect_trying,
		tsip_o_ect_accepted,
		tsip_o_ect_completed,
		tsip_o_ect_failed,
		tsip_o_ect_notify,
		tsip_i_ect_requested,
		tsip_i_ect_newcall,
		tsip_i_ect_completed,
		tsip_i_ect_failed,
		tsip_i_ect_notify,
		tsip_m_early_media,
		tsip_m_updating,
		tsip_m_updated,
		tsip_m_local_hold_ok,
		tsip_m_local_hold_nok,
		tsip_m_local_resume_ok,
		tsip_m_local_resume_nok,
		tsip_m_remote_hold,
		tsip_m_remote_resume
	}
}
