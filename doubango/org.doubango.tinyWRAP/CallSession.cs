using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class CallSession : InviteSession
	{
		private HandleRef swigCPtr;

		internal CallSession(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.CallSession_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(CallSession obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~CallSession()
		{
			this.Dispose();
		}

		public override void Dispose()
		{
			lock (this)
			{
				if (this.swigCPtr.Handle != IntPtr.Zero)
				{
					if (this.swigCMemOwn)
					{
						this.swigCMemOwn = false;
						tinyWRAPPINVOKE.delete_CallSession(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public CallSession(SipStack pStack) : this(tinyWRAPPINVOKE.new_CallSession(SipStack.getCPtr(pStack)), true)
		{
		}

		public bool callAudio(string remoteUriString, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callAudio__SWIG_0(this.swigCPtr, remoteUriString, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callAudio(string remoteUriString, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callAudio__SWIG_1(this.swigCPtr, remoteUriString, mediaAttr);
		}

		public bool callAudio(SipUri remoteUri, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callAudio__SWIG_2(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callAudio(SipUri remoteUri, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callAudio__SWIG_3(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr);
		}

		public bool callAudioVideo(string remoteUriString, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callAudioVideo__SWIG_0(this.swigCPtr, remoteUriString, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callAudioVideo(string remoteUriString, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callAudioVideo__SWIG_1(this.swigCPtr, remoteUriString, mediaAttr);
		}

		public bool callAudioVideo(SipUri remoteUri, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callAudioVideo__SWIG_2(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callAudioVideo(SipUri remoteUri, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callAudioVideo__SWIG_3(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr);
		}

		public bool callVideo(string remoteUriString, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callVideo__SWIG_0(this.swigCPtr, remoteUriString, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callVideo(string remoteUriString, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callVideo__SWIG_1(this.swigCPtr, remoteUriString, mediaAttr);
		}

		public bool callVideo(SipUri remoteUri, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_callVideo__SWIG_2(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool callVideo(SipUri remoteUri, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_callVideo__SWIG_3(this.swigCPtr, SipUri.getCPtr(remoteUri), mediaAttr);
		}

		public bool call(string remoteUriString, twrap_media_type_t media, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_call__SWIG_0(this.swigCPtr, remoteUriString, (int)media, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool call(string remoteUriString, twrap_media_type_t media, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_call__SWIG_1(this.swigCPtr, remoteUriString, (int)media, mediaAttr);
		}

		public bool call(SipUri remoteUri, twrap_media_type_t media, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_call__SWIG_2(this.swigCPtr, SipUri.getCPtr(remoteUri), (int)media, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool call(SipUri remoteUri, twrap_media_type_t media, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_call__SWIG_3(this.swigCPtr, SipUri.getCPtr(remoteUri), (int)media, mediaAttr);
		}

		public bool setSessionTimer(uint timeout, string refresher)
		{
			return tinyWRAPPINVOKE.CallSession_setSessionTimer(this.swigCPtr, timeout, refresher);
		}

		public bool set100rel(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_set100rel(this.swigCPtr, enabled);
		}

		public bool setRtcp(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_setRtcp(this.swigCPtr, enabled);
		}

		public bool setRtcpMux(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_setRtcpMux(this.swigCPtr, enabled);
		}

		public bool setSRtpMode(tmedia_srtp_mode_t mode)
		{
			return tinyWRAPPINVOKE.CallSession_setSRtpMode(this.swigCPtr, (int)mode);
		}

		public bool setAvpfMode(tmedia_mode_t mode)
		{
			return tinyWRAPPINVOKE.CallSession_setAvpfMode(this.swigCPtr, (int)mode);
		}

		public bool setICE(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_setICE(this.swigCPtr, enabled);
		}

		public bool setICEStun(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_setICEStun(this.swigCPtr, enabled);
		}

		public bool setICETurn(bool enabled)
		{
			return tinyWRAPPINVOKE.CallSession_setICETurn(this.swigCPtr, enabled);
		}

		public bool setSTUNServer(string hostname, ushort port)
		{
			return tinyWRAPPINVOKE.CallSession_setSTUNServer(this.swigCPtr, hostname, port);
		}

		public bool setSTUNCred(string username, string password)
		{
			return tinyWRAPPINVOKE.CallSession_setSTUNCred(this.swigCPtr, username, password);
		}

		public bool setVideoFps(int fps)
		{
			return tinyWRAPPINVOKE.CallSession_setVideoFps(this.swigCPtr, fps);
		}

		public bool setVideoBandwidthUploadMax(int max)
		{
			return tinyWRAPPINVOKE.CallSession_setVideoBandwidthUploadMax(this.swigCPtr, max);
		}

		public bool setVideoBandwidthDownloadMax(int max)
		{
			return tinyWRAPPINVOKE.CallSession_setVideoBandwidthDownloadMax(this.swigCPtr, max);
		}

		public bool setVideoPrefSize(tmedia_pref_video_size_t pref_video_size)
		{
			return tinyWRAPPINVOKE.CallSession_setVideoPrefSize(this.swigCPtr, (int)pref_video_size);
		}

		public bool setQoS(tmedia_qos_stype_t type, tmedia_qos_strength_t strength)
		{
			return tinyWRAPPINVOKE.CallSession_setQoS(this.swigCPtr, (int)type, (int)strength);
		}

		public bool hold(ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_hold__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool hold()
		{
			return tinyWRAPPINVOKE.CallSession_hold__SWIG_1(this.swigCPtr);
		}

		public bool resume(ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_resume__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool resume()
		{
			return tinyWRAPPINVOKE.CallSession_resume__SWIG_1(this.swigCPtr);
		}

		public bool update(twrap_media_type_t media, int mediaAttr, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_update__SWIG_0(this.swigCPtr, (int)media, mediaAttr, ActionConfig.getCPtr(config));
		}

		public bool update(twrap_media_type_t media, int mediaAttr)
		{
			return tinyWRAPPINVOKE.CallSession_update__SWIG_1(this.swigCPtr, (int)media, mediaAttr);
		}

		public bool transfer(string referToUriString, ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_transfer__SWIG_0(this.swigCPtr, referToUriString, ActionConfig.getCPtr(config));
		}

		public bool transfer(string referToUriString)
		{
			return tinyWRAPPINVOKE.CallSession_transfer__SWIG_1(this.swigCPtr, referToUriString);
		}

		public bool acceptTransfer(ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_acceptTransfer__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool acceptTransfer()
		{
			return tinyWRAPPINVOKE.CallSession_acceptTransfer__SWIG_1(this.swigCPtr);
		}

		public bool rejectTransfer(ActionConfig config)
		{
			return tinyWRAPPINVOKE.CallSession_rejectTransfer__SWIG_0(this.swigCPtr, ActionConfig.getCPtr(config));
		}

		public bool rejectTransfer()
		{
			return tinyWRAPPINVOKE.CallSession_rejectTransfer__SWIG_1(this.swigCPtr);
		}

		public bool sendDTMF(int number)
		{
			return tinyWRAPPINVOKE.CallSession_sendDTMF(this.swigCPtr, number);
		}

		public uint getSessionTransferId()
		{
			return tinyWRAPPINVOKE.CallSession_getSessionTransferId(this.swigCPtr);
		}

		public bool sendT140Data(tmedia_t140_data_type_t data_type, IntPtr data_ptr, uint data_size)
		{
			return tinyWRAPPINVOKE.CallSession_sendT140Data__SWIG_0(this.swigCPtr, (int)data_type, data_ptr, data_size);
		}

		public bool sendT140Data(tmedia_t140_data_type_t data_type, IntPtr data_ptr)
		{
			return tinyWRAPPINVOKE.CallSession_sendT140Data__SWIG_1(this.swigCPtr, (int)data_type, data_ptr);
		}

		public bool sendT140Data(tmedia_t140_data_type_t data_type)
		{
			return tinyWRAPPINVOKE.CallSession_sendT140Data__SWIG_2(this.swigCPtr, (int)data_type);
		}

		public bool setT140Callback(T140Callback pT140Callback)
		{
			return tinyWRAPPINVOKE.CallSession_setT140Callback(this.swigCPtr, T140Callback.getCPtr(pT140Callback));
		}
	}
}
