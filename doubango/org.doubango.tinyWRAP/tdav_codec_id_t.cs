using System;

namespace org.doubango.tinyWRAP
{
	[Obsolete("Deprecated and replaced by 'tmedia_codec_id_t'. Will be removed in Doubango 3.0.", false)]
	public enum tdav_codec_id_t
	{
		tdav_codec_id_none,
		tdav_codec_id_amr_nb_oa,
		tdav_codec_id_amr_nb_be,
		tdav_codec_id_amr_wb_oa = 4,
		tdav_codec_id_amr_wb_be = 8,
		tdav_codec_id_gsm = 16,
		tdav_codec_id_pcma = 32,
		tdav_codec_id_pcmu = 64,
		tdav_codec_id_ilbc = 128,
		tdav_codec_id_speex_nb = 256,
		tdav_codec_id_speex_wb = 512,
		tdav_codec_id_speex_uwb = 1024,
		tdav_codec_id_bv16 = 2048,
		tdav_codec_id_bv32 = 4096,
		tdav_codec_id_opus = 8192,
		tdav_codec_id_g729ab = 16384,
		tdav_codec_id_g722 = 32768,
		tdav_codec_id_h261 = 65536,
		tdav_codec_id_h263 = 131072,
		tdav_codec_id_h263p = 262144,
		tdav_codec_id_h263pp = 524288,
		tdav_codec_id_h264_bp = 1048576,
		tdav_codec_id_h264_mp = 2097152,
		tdav_codec_id_h264_hp = 4194304,
		tdav_codec_id_h264_bp10 = 1048576,
		tdav_codec_id_h264_bp20 = 1048576,
		tdav_codec_id_h264_bp30 = 1048576,
		tdav_codec_id_h264_svc = 8388608,
		tdav_codec_id_theora = 16777216,
		tdav_codec_id_mp4ves_es = 33554432,
		tdav_codec_id_vp8 = 67108864,
		tdav_codec_id_t140 = 1073741824,
		tdav_codec_id_red = -2147483648
	}
}
