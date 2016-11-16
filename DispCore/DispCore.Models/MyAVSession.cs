using DispCore.Trunk.Types;
using org.doubango.tinyWRAP;
using System;
using System.Runtime.InteropServices;

namespace DispCore.Models
{
	public class MyAVSession : MyInviteSession
	{
		private readonly CallSession mSession;

		private bool mMute;

		protected long mSessionTransferId = -1L;

		private bool isMissed;

		private string strCallType;

		private string strPrioAttribute;

		private string stre2ee;

		private string strduplex;

		private string strfoaoroacsu;

		private string strpriority;

		private string strcallerUDN;

		private string strOnlineCallID;

		private string strCalledType;

		protected override SipSession Session
		{
			get
			{
				return this.mSession;
			}
		}

		public long SessionTransferId
		{
			get
			{
				if (this.mSessionTransferId == -1L)
				{
					this.mSessionTransferId = (long)((ulong)this.mSession.getSessionTransferId());
				}
				return this.mSessionTransferId;
			}
		}

		public string CallType
		{
			get
			{
				return this.strCallType;
			}
		}

		public string PrioAttribute
		{
			get
			{
				return this.strPrioAttribute;
			}
		}

		public string E2ee
		{
			get
			{
				return this.stre2ee;
			}
		}

		public string Duplex
		{
			get
			{
				return this.strduplex;
			}
		}

		public string Foaoroacsu
		{
			get
			{
				return this.strfoaoroacsu;
			}
			set
			{
				this.strfoaoroacsu = value;
			}
		}

		public string Priority
		{
			get
			{
				return this.strpriority;
			}
		}

		public string CallerUDN
		{
			get
			{
				return this.strcallerUDN;
			}
		}

		public string OnlineCallID
		{
			get
			{
				return this.strOnlineCallID;
			}
		}

		public string CalledType
		{
			get
			{
				return this.strCalledType;
			}
		}

		public bool IsMute
		{
			get
			{
				return this.mMute;
			}
		}

		public bool IsMissed
		{
			get
			{
				return this.isMissed;
			}
			set
			{
				this.isMissed = value;
				base.OnPropertyChanged("IsMissed");
			}
		}

		public MyAVSession(MySipStack sipStack, CallSession session, MediaType mediaType, InviteState callState) : base(sipStack)
		{
			this.mSession = ((session == null) ? new CallSession(sipStack.WrappedStack) : session);
			this.mMediaType = mediaType;
			this.mState = callState;
			this.mMute = false;
			base.init();
			base.SigCompId = sipStack.SigCompId;
		}

		public MyAVSession(MySipStack sipStack, CallSession session, MediaType mediaType, InviteState callState, TrunkCallParam callParam) : base(sipStack)
		{
			this.mSession = ((session == null) ? new CallSession(sipStack.WrappedStack) : session);
			this.mMediaType = mediaType;
			this.mState = callState;
			this.mMute = false;
			base.init();
			base.SigCompId = sipStack.SigCompId;
			if (callParam != null)
			{
				this.strCallType = callParam.strCallType;
				this.strPrioAttribute = callParam.strPrioAttribute;
				this.stre2ee = callParam.stre2ee;
				this.strduplex = callParam.strduplex;
				this.strfoaoroacsu = callParam.strfoaoroacsu;
				this.strpriority = callParam.strpriority;
				this.strcallerUDN = callParam.strcallerUDN;
				this.strOnlineCallID = callParam.strOnlineCallID;
				this.strCalledType = callParam.strCalledType;
			}
		}

		public MyAVSession(string remoteParty, MediaType mediaType, InviteState callState) : base(remoteParty, mediaType)
		{
			this.mMediaType = mediaType;
			this.mState = callState;
		}

		public bool AcceptCall()
		{
			return this.mSession.accept(null);
		}

		public bool HangUpCall(TrunkCallReleaseReason reason)
		{
			ActionConfig config = new ActionConfig();
			string strReleaseReason = string.Format("pttrelease;cause={0}", (byte)reason);
			config.addHeader("Ptt-Extension", strReleaseReason);
			bool result;
			if (this.connected)
			{
				result = this.mSession.hangup(config);
			}
			else if (base.IsOutgoing)
			{
				result = this.mSession.hangup(config);
			}
			else
			{
				result = this.mSession.reject(config);
			}
			return result;
		}

		public bool HangUpCallEx()
		{
			ActionConfig config = new ActionConfig();
			string strReleaseReason = string.Format("pttrelease;cause={0}", 64);
			config.addHeader("Ptt-Extension", strReleaseReason);
			return this.mSession.hangup(config);
		}

		public bool HoldCall()
		{
			return this.mSession.hold();
		}

		public bool ResumeCall()
		{
			return this.mSession.resume();
		}

		public bool Mute(bool mute, twrap_media_type_t media)
		{
			bool result;
			if (base.MediaSessionMgr != null)
			{
				if (base.MediaSessionMgr.producerSetInt32(media, "mute", mute ? 1 : 0))
				{
					this.mMute = mute;
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool SetVolume(int volume)
		{
			bool result;
			if (base.MediaSessionMgr != null)
			{
				bool ok = base.MediaSessionMgr.producerSetInt32(twrap_media_type_t.twrap_media_audio, "volume", volume);
				ok &= base.MediaSessionMgr.consumerSetInt32(twrap_media_type_t.twrap_media_audio, "volume", volume);
				result = ok;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool SendInfo(byte[] payload, string contentType)
		{
			bool result;
			if (payload != null && !string.IsNullOrEmpty(contentType))
			{
				System.IntPtr payloadPtr = System.Runtime.InteropServices.Marshal.AllocHGlobal(payload.Length);
				ActionConfig config = new ActionConfig();
				config.addHeader("Content-Type", contentType);
				System.Runtime.InteropServices.Marshal.Copy(payload, 0, payloadPtr, payload.Length);
				bool ret = this.mSession.sendInfo(payloadPtr, (uint)payload.Length, config);
				System.Runtime.InteropServices.Marshal.FreeHGlobal(payloadPtr);
				result = ret;
			}
			else
			{
				result = this.mSession.sendInfo(System.IntPtr.Zero, 0u);
			}
			return result;
		}

		public bool SendInfo(ActionConfig config)
		{
			bool result;
			if (config != null)
			{
				result = this.mSession.sendInfo(System.IntPtr.Zero, 0u, config);
			}
			else
			{
				result = this.mSession.sendInfo(System.IntPtr.Zero, 0u);
			}
			return result;
		}

		public bool SetProducerFlipped(bool flipped)
		{
			return base.MediaSessionMgr != null && base.MediaSessionMgr.producerSetInt32(twrap_media_type_t.twrap_media_video, "flip", flipped ? 1 : 0);
		}

		public bool SetFullscreen(bool fullscreen)
		{
			return base.MediaSessionMgr != null && base.MediaSessionMgr.consumerSetInt32(twrap_media_type_t.twrap_media_video, "fullscreen", fullscreen ? 1 : 0);
		}

		public bool SetEchoSupp(bool enabled)
		{
			return base.MediaSessionMgr.sessionSetInt32(twrap_media_type_t.twrap_media_audio, "echo-supp", enabled ? 1 : 0);
		}

		public bool IsSecure()
		{
			return base.MediaSessionMgr != null && base.MediaSessionMgr.sessionGetInt32(twrap_media_type_t.twrap_media_audiovideo, "srtp-enabled") != 0;
		}

		public bool TransferCall(string transferUri)
		{
			return !string.IsNullOrEmpty(transferUri) && SipUri.isValid(transferUri) && this.mSession.transfer(transferUri);
		}

		public bool AcceptCallTransfer()
		{
			return this.mSession.acceptTransfer();
		}

		public bool RejectCallTransfer()
		{
			return this.mSession.rejectTransfer();
		}

		public bool MakeCall(string remoteUri, MediaAttr attribute)
		{
			this.outgoing = true;
			base.ToUri = remoteUri;
			ActionConfig config = new ActionConfig();
			bool ret = this.mSession.call(remoteUri, MediaTypeUtils.ConvertToNative(this.mMediaType), (int)attribute, config);
			config.Dispose();
			return ret;
		}

		public bool MakeCall(string remoteUri, MediaAttr mediaAttr, ActionConfig config)
		{
			this.outgoing = true;
			base.ToUri = remoteUri;
			bool ret = this.mSession.call(remoteUri, MediaTypeUtils.ConvertToNative(this.mMediaType), (int)mediaAttr, config);
			config.Dispose();
			return ret;
		}

		public bool MakeVideoPollCall(string remoteUri, ActionConfig config)
		{
			this.outgoing = true;
			base.ToUri = remoteUri;
			return this.mSession.call(remoteUri, MediaTypeUtils.ConvertToNative(this.mMediaType), 0, config);
		}

		public bool MakeVideoSharingCall(string remoteUri)
		{
			this.outgoing = true;
			ActionConfig config = new ActionConfig();
			bool ret = this.mSession.call(remoteUri, MediaTypeUtils.ConvertToNative(MediaType.Video), 0, config);
			config.Dispose();
			return ret;
		}

		public bool SendDTMF(int digit)
		{
			return this.mSession.sendDTMF(digit);
		}

		public bool Update(MediaType newMediaType, MediaAttr mediaAttr, ActionConfig config)
		{
			return this.mSession != null && this.mSession.call(base.ToUri, MediaTypeUtils.ConvertToNative(newMediaType), (int)mediaAttr);
		}

		public bool UpdateMediaAttribute(MediaType mediaType, MediaAttr attribute, ActionConfig config)
		{
			bool ret = this.mSession.update(MediaTypeUtils.ConvertToNative(mediaType), (int)attribute, config);
			config.Dispose();
			return ret;
		}
	}
}
