using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public abstract class MyInviteSession : MySipSession
	{
		protected MediaType mMediaType;

		protected MediaSessionMgr mMediaSessionMgr = null;

		protected ProxyVideoProducer mProxyVideoProduce = null;

		protected InviteState mState;

		public MediaType MediaType
		{
			get
			{
				return this.mMediaType;
			}
			set
			{
				this.mMediaType = value;
				base.OnPropertyChanged("MediaType");
			}
		}

		public virtual InviteState State
		{
			get
			{
				return this.mState;
			}
			set
			{
				this.mState = value;
				base.OnPropertyChanged("State");
			}
		}

		public bool IsActive
		{
			get
			{
				return this.State != InviteState.NONE && this.State != InviteState.TERMINATING && this.State != InviteState.TERMINATED;
			}
		}

		public MediaSessionMgr MediaSessionMgr
		{
			get
			{
				if (this.mMediaSessionMgr == null)
				{
					this.mMediaSessionMgr = (this.Session as InviteSession).getMediaMgr();
				}
				return this.mMediaSessionMgr;
			}
		}

		public ProxyVideoProducer ProxyVideoProduce
		{
			get
			{
				if (this.mProxyVideoProduce == null)
				{
					ProxyPlugin plunginProduce = (this.Session as InviteSession).getMediaMgr().findProxyPluginProducer(twrap_media_type_t.twrap_media_video);
					this.mProxyVideoProduce = (plunginProduce as ProxyVideoProducer);
				}
				return this.mProxyVideoProduce;
			}
		}

		protected MyInviteSession(MySipStack sipStack) : base(sipStack)
		{
			this.mState = InviteState.NONE;
		}

		public MyInviteSession(string remoteParty, MediaType mediaType) : base(remoteParty, mediaType)
		{
			this.mState = InviteState.NONE;
		}

		public override void PreDispose()
		{
			if (this.mMediaSessionMgr != null)
			{
				this.mMediaSessionMgr.Dispose();
				this.mMediaSessionMgr = null;
			}
		}
	}
}
