using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MediaSessionMgr : IDisposable
	{
		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		internal MediaSessionMgr(IntPtr cPtr, bool cMemoryOwn)
		{
			this.swigCMemOwn = cMemoryOwn;
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MediaSessionMgr obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MediaSessionMgr()
		{
			this.Dispose();
		}

		public virtual void Dispose()
		{
			lock (this)
			{
				if (this.swigCPtr.Handle != IntPtr.Zero)
				{
					if (this.swigCMemOwn)
					{
						this.swigCMemOwn = false;
						tinyWRAPPINVOKE.delete_MediaSessionMgr(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
			}
		}

		public bool sessionSetInt32(twrap_media_type_t media, string key, int value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_sessionSetInt32(this.swigCPtr, (int)media, key, value);
		}

		public int sessionGetInt32(twrap_media_type_t media, string key)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_sessionGetInt32(this.swigCPtr, (int)media, key);
		}

		public bool consumerSetInt32(twrap_media_type_t media, string key, int value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_consumerSetInt32(this.swigCPtr, (int)media, key, value);
		}

		public bool consumerSetInt64(twrap_media_type_t media, string key, long value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_consumerSetInt64(this.swigCPtr, (int)media, key, value);
		}

		public bool producerSetInt32(twrap_media_type_t media, string key, int value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_producerSetInt32(this.swigCPtr, (int)media, key, value);
		}

		public bool producerSetInt64(twrap_media_type_t media, string key, long value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_producerSetInt64(this.swigCPtr, (int)media, key, value);
		}

		public Codec producerGetCodec(twrap_media_type_t media)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MediaSessionMgr_producerGetCodec(this.swigCPtr, (int)media);
			return (cPtr == IntPtr.Zero) ? null : new Codec(cPtr, true);
		}

		public ProxyPlugin findProxyPluginConsumer(twrap_media_type_t media)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MediaSessionMgr_findProxyPluginConsumer(this.swigCPtr, (int)media);
			return (cPtr == IntPtr.Zero) ? null : new ProxyPlugin(cPtr, false);
		}

		public ProxyPlugin findProxyPluginProducer(twrap_media_type_t media)
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MediaSessionMgr_findProxyPluginProducer(this.swigCPtr, (int)media);
			return (cPtr == IntPtr.Zero) ? null : new ProxyPlugin(cPtr, false);
		}

		public static uint registerAudioPluginFromFile(string path)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_registerAudioPluginFromFile(path);
		}

		public ulong getSessionId(twrap_media_type_t media)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_getSessionId(this.swigCPtr, (int)media);
		}

		public static bool defaultsSetProfile(tmedia_profile_t profile)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetProfile((int)profile);
		}

		public static tmedia_profile_t defaultsGetProfile()
		{
			return (tmedia_profile_t)tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetProfile();
		}

		public static bool defaultsSetBandwidthLevel(tmedia_bandwidth_level_t bl)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetBandwidthLevel((int)bl);
		}

		public static tmedia_bandwidth_level_t defaultsGetBandwidthLevel()
		{
			return (tmedia_bandwidth_level_t)tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetBandwidthLevel();
		}

		public static bool defaultsSetCongestionCtrlEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetCongestionCtrlEnabled(enabled);
		}

		public static bool defaultsSetVideoMotionRank(int video_motion_rank)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVideoMotionRank(video_motion_rank);
		}

		public static bool defaultsSetVideoFps(int video_fps)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVideoFps(video_fps);
		}

		public static bool defaultsSetBandwidthVideoUploadMax(int bw_video_up_max_kbps)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetBandwidthVideoUploadMax(bw_video_up_max_kbps);
		}

		public static bool defaultsSetBandwidthVideoDownloadMax(int bw_video_down_max_kbps)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetBandwidthVideoDownloadMax(bw_video_down_max_kbps);
		}

		public static bool defaultsSetPrefVideoSize(tmedia_pref_video_size_t pref_video_size)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetPrefVideoSize((int)pref_video_size);
		}

		public static bool defaultsSetJbMargin(uint jb_margin_ms)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetJbMargin(jb_margin_ms);
		}

		public static bool defaultsSetJbMaxLateRate(uint jb_late_rate_percent)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetJbMaxLateRate(jb_late_rate_percent);
		}

		public static bool defaultsSetEchoTail(uint echo_tail)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetEchoTail(echo_tail);
		}

		public static uint defaultsGetEchoTail()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetEchoTail();
		}

		public static bool defaultsSetEchoSkew(uint echo_skew)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetEchoSkew(echo_skew);
		}

		public static bool defaultsSetEchoSuppEnabled(bool echo_supp_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetEchoSuppEnabled(echo_supp_enabled);
		}

		public static bool defaultsGetEchoSuppEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetEchoSuppEnabled();
		}

		public static bool defaultsSetAgcEnabled(bool agc_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAgcEnabled(agc_enabled);
		}

		public static bool defaultsGetAgcEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetAgcEnabled();
		}

		public static bool defaultsSetAgcLevel(float agc_level)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAgcLevel(agc_level);
		}

		public static float defaultsGetAgcLevel()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetAgcLevel();
		}

		public static bool defaultsSetVadEnabled(bool vad_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVadEnabled(vad_enabled);
		}

		public static bool defaultsGetGetVadEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetGetVadEnabled();
		}

		public static bool defaultsSetNoiseSuppEnabled(bool noise_supp_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetNoiseSuppEnabled(noise_supp_enabled);
		}

		public static bool defaultsGetNoiseSuppEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetNoiseSuppEnabled();
		}

		public static bool defaultsSetNoiseSuppLevel(int noise_supp_level)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetNoiseSuppLevel(noise_supp_level);
		}

		public static int defaultsGetNoiseSuppLevel()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetNoiseSuppLevel();
		}

		public static bool defaultsSet100relEnabled(bool _100rel_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSet100relEnabled(_100rel_enabled);
		}

		public static bool defaultsGet100relEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGet100relEnabled();
		}

		public static bool defaultsSetScreenSize(int sx, int sy)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetScreenSize(sx, sy);
		}

		public static bool defaultsSetAudioGain(int producer_gain, int consumer_gain)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAudioGain(producer_gain, consumer_gain);
		}

		public static bool defaultsSetAudioPtime(int ptime)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAudioPtime(ptime);
		}

		public static bool defaultsSetAudioChannels(int channel_playback, int channel_record)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAudioChannels(channel_playback, channel_record);
		}

		public static bool defaultsSetRtpPortRange(ushort range_start, ushort range_stop)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetRtpPortRange(range_start, range_stop);
		}

		public static bool defaultsSetRtpSymetricEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetRtpSymetricEnabled(enabled);
		}

		public static bool defaultsSetMediaType(twrap_media_type_t media_type)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetMediaType((int)media_type);
		}

		public static bool defaultsSetVolume(int volume)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVolume(volume);
		}

		public static int defaultsGetVolume()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetVolume();
		}

		public static bool defaultsSetInviteSessionTimers(int timeout, string refresher)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetInviteSessionTimers(timeout, refresher);
		}

		public static bool defaultsSetSRtpMode(tmedia_srtp_mode_t mode)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetSRtpMode((int)mode);
		}

		public static tmedia_srtp_mode_t defaultsGetSRtpMode()
		{
			return (tmedia_srtp_mode_t)tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetSRtpMode();
		}

		public static bool defaultsSetSRtpType(tmedia_srtp_type_t srtp_type)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetSRtpType((int)srtp_type);
		}

		public static tmedia_srtp_type_t defaultsGetSRtpType()
		{
			return (tmedia_srtp_type_t)tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetSRtpType();
		}

		public static bool defaultsSetRtcpEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetRtcpEnabled(enabled);
		}

		public static bool defaultsGetRtcpEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetRtcpEnabled();
		}

		public static bool defaultsSetRtcpMuxEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetRtcpMuxEnabled(enabled);
		}

		public static bool defaultsGetRtcpMuxEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetRtcpMuxEnabled();
		}

		public static bool defaultsSetStunEnabled(bool stun_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetStunEnabled(stun_enabled);
		}

		public static bool defaultsSetIceStunEnabled(bool icestun_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetIceStunEnabled(icestun_enabled);
		}

		public static bool defaultsSetIceTurnEnabled(bool iceturn_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetIceTurnEnabled(iceturn_enabled);
		}

		public static bool defaultsSetStunServer(string server_ip, ushort server_port)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetStunServer(server_ip, server_port);
		}

		public static bool defaultsSetStunCred(string username, string password)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetStunCred(username, password);
		}

		public static bool defaultsSetIceEnabled(bool ice_enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetIceEnabled(ice_enabled);
		}

		public static bool defaultsSetByPassEncoding(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetByPassEncoding(enabled);
		}

		public static bool defaultsGetByPassEncoding()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetByPassEncoding();
		}

		public static bool defaultsSetByPassDecoding(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetByPassDecoding(enabled);
		}

		public static bool defaultsGetByPassDecoding()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetByPassDecoding();
		}

		public static bool defaultsSetVideoJbEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVideoJbEnabled(enabled);
		}

		public static bool defaultsGetVideoJbEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetVideoJbEnabled();
		}

		public static bool defaultsSetVideoZeroArtifactsEnabled(bool enabled)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetVideoZeroArtifactsEnabled(enabled);
		}

		public static bool defaultsGetVideoZeroArtifactsEnabled()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetVideoZeroArtifactsEnabled();
		}

		public static bool defaultsSetRtpBuffSize(uint buffSize)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetRtpBuffSize(buffSize);
		}

		public static uint defaultsGetRtpBuffSize()
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsGetRtpBuffSize();
		}

		public static bool defaultsSetAvpfTail(uint tail_min, uint tail_max)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAvpfTail(tail_min, tail_max);
		}

		public static bool defaultsSetAvpfMode(tmedia_mode_t mode)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetAvpfMode((int)mode);
		}

		public static bool defaultsSetOpusMaxCaptureRate(uint opus_maxcapturerate)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetOpusMaxCaptureRate(opus_maxcapturerate);
		}

		public static bool defaultsSetOpusMaxPlaybackRate(uint opus_maxplaybackrate)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetOpusMaxPlaybackRate(opus_maxplaybackrate);
		}

		public static bool defaultsSetMaxFds(int max_fds)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_defaultsSetMaxFds(max_fds);
		}

		public bool codecSetInt32(twrap_media_type_t media, string key, int value)
		{
			return tinyWRAPPINVOKE.MediaSessionMgr_codecSetInt32(this.swigCPtr, (int)media, key, (long)value);
		}
	}
}
