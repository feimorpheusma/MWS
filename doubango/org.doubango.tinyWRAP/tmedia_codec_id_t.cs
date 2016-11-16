using System;

namespace org.doubango.tinyWRAP
{
	public enum tmedia_codec_id_t
	{
		tmedia_codec_id_none,
		tmedia_codec_id_amr_nb_oa,
		tmedia_codec_id_amr_nb_be,
		tmedia_codec_id_amr_wb_oa = 4,
		tmedia_codec_id_amr_wb_be = 8,
		tmedia_codec_id_gsm = 16,
		tmedia_codec_id_pcma = 32,
		tmedia_codec_id_pcmu = 64,
		tmedia_codec_id_ilbc = 128,
		tmedia_codec_id_speex_nb = 256,
		tmedia_codec_id_speex_wb = 512,
		tmedia_codec_id_speex_uwb = 1024,
		tmedia_codec_id_bv16 = 2048,
		tmedia_codec_id_bv32 = 4096,
		tmedia_codec_id_opus = 8192,
		tmedia_codec_id_g729ab = 16384,
		tmedia_codec_id_g722 = 32768,
		tmedia_codec_id_h261 = 65536,
		tmedia_codec_id_h263 = 131072,
		tmedia_codec_id_h263p = 262144,
		tmedia_codec_id_h263pp = 524288,
		tmedia_codec_id_h264_bp = 1048576,
		tmedia_codec_id_h264_mp = 2097152,
		tmedia_codec_id_h264_hp = 4194304,
		tmedia_codec_id_h264_bp10 = 1048576,
		tmedia_codec_id_h264_bp20 = 1048576,
		tmedia_codec_id_h264_bp30 = 1048576,
		tmedia_codec_id_h264_svc = 8388608,
		tmedia_codec_id_theora = 16777216,
		tmedia_codec_id_mp4ves_es = 33554432,
		tmedia_codec_id_vp8 = 67108864,
		tmedia_codec_id_t140 = 1073741824,
		tmedia_codec_id_red = -2147483648
	}
}
