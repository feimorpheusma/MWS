using org.doubango.tinyWRAP;
using System;

namespace DispCore
{
	public static class MediaTypeUtils
	{
		private struct media_type_bind_s
		{
			public MediaType twrap;

			public twrap_media_type_t tnative;

			public media_type_bind_s(MediaType _twrap, twrap_media_type_t _tnative)
			{
				this.twrap = _twrap;
				this.tnative = _tnative;
			}
		}

		private static MediaTypeUtils.media_type_bind_s[] __media_type_binds = new MediaTypeUtils.media_type_bind_s[]
		{
			new MediaTypeUtils.media_type_bind_s(MediaType.Msrp, twrap_media_type_t.twrap_media_msrp),
			new MediaTypeUtils.media_type_bind_s(MediaType.Audio, twrap_media_type_t.twrap_media_audio),
			new MediaTypeUtils.media_type_bind_s(MediaType.Video, twrap_media_type_t.twrap_media_video),
			new MediaTypeUtils.media_type_bind_s(MediaType.T140, twrap_media_type_t.twrap_media_t140),
			new MediaTypeUtils.media_type_bind_s(MediaType.BFCP, twrap_media_type_t.twrap_media_bfcp),
			new MediaTypeUtils.media_type_bind_s(MediaType.Audiobfcp, twrap_media_type_t.twrap_media_bfcp_audio),
			new MediaTypeUtils.media_type_bind_s(MediaType.Videobfcp, twrap_media_type_t.twrap_media_bfcp_video)
		};

		public static MediaType ConvertFromNative(twrap_media_type_t mediaType)
		{
			MediaType t = MediaType.None;
			for (int i = 0; i < MediaTypeUtils.__media_type_binds.Length; i++)
			{
				if ((MediaTypeUtils.__media_type_binds[i].tnative & mediaType) == MediaTypeUtils.__media_type_binds[i].tnative)
				{
					t |= MediaTypeUtils.__media_type_binds[i].twrap;
				}
			}
			return t;
		}

		public static twrap_media_type_t ConvertToNative(MediaType mediaType)
		{
			twrap_media_type_t t = twrap_media_type_t.twrap_media_none;
			for (int i = 0; i < MediaTypeUtils.__media_type_binds.Length; i++)
			{
				if ((MediaTypeUtils.__media_type_binds[i].twrap & mediaType) == MediaTypeUtils.__media_type_binds[i].twrap)
				{
					t |= MediaTypeUtils.__media_type_binds[i].tnative;
				}
			}
			return t;
		}
	}
}
