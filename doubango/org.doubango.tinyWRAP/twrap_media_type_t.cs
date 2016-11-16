using System;

namespace org.doubango.tinyWRAP
{
	public enum twrap_media_type_t
	{
		twrap_media_none,
		twrap_media_audio,
		twrap_media_video,
		twrap_media_msrp = 4,
		twrap_media_t140 = 8,
		twrap_media_bfcp = 16,
		twrap_media_bfcp_audio = 48,
		twrap_media_bfcp_video = 80,
		twrap_media_audiovideo = 3,
		twrap_media_audio_video = 3
	}
}
