using DispCore.Trunk.Types;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Trunk
{
	public class TrunkAVSession : MyAVSession
	{
		private TrunkCallType callType;

		private long callAttribute;

		private bool duplex;

		private bool foaoroacsu;

		private bool e2ee;

		private int priority;

		private int onlineCallId;

		private int iWallDstObjId;

		public int WallDstObjId
		{
			get
			{
				return this.iWallDstObjId;
			}
			set
			{
				this.iWallDstObjId = value;
			}
		}

		public new TrunkCallType CallType
		{
			get
			{
				return this.callType;
			}
			set
			{
				this.callType = value;
			}
		}

		public long CallAttribute
		{
			get
			{
				return this.callAttribute;
			}
			set
			{
				this.callAttribute = value;
			}
		}

		public new bool Duplex
		{
			get
			{
				return this.duplex;
			}
			set
			{
				this.duplex = value;
			}
		}

		public new bool Foaoroacsu
		{
			get
			{
				return this.foaoroacsu;
			}
			set
			{
				this.foaoroacsu = value;
			}
		}

		public new bool E2ee
		{
			get
			{
				return this.e2ee;
			}
			set
			{
				this.e2ee = value;
			}
		}

		public new int Priority
		{
			get
			{
				return this.priority;
			}
			set
			{
				this.priority = value;
			}
		}

		public int OnlineCallId
		{
			get
			{
				return this.onlineCallId;
			}
			set
			{
				this.onlineCallId = value;
			}
		}

		public TrunkAVSession(MySipStack sipStack, CallSession session, MediaType mediaType, InviteState callState) : base(sipStack, session, mediaType, callState)
		{
			this.iWallDstObjId = -1;
		}
	}
}
