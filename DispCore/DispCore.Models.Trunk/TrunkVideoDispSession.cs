using DispCore.Trunk.Types;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Trunk
{
	public class TrunkVideoDispSession : MyAVSession
	{
		private TrunkCallType callType;

		private string strVideoId;

		private string strDstObjId;

		private string strFormat;

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

		public string VideoId
		{
			get
			{
				return this.strVideoId;
			}
			set
			{
				this.strVideoId = value;
			}
		}

		public string DstObjId
		{
			get
			{
				return this.strDstObjId;
			}
			set
			{
				this.strDstObjId = value;
			}
		}

		public string VideoFormat
		{
			get
			{
				return this.strFormat;
			}
			set
			{
				this.strFormat = value;
			}
		}

		public TrunkVideoDispSession(MySipStack sipStack, CallSession session, MediaType mediaType, InviteState callState) : base(sipStack, session, mediaType, callState)
		{
			this.callType = TrunkCallType.TCT_DUMMY_VIDEO_DISPATCH;
		}

		public TrunkVideoDispSession(string remoteParty, string VideoId, MediaType mediaType, InviteState callState) : base(remoteParty, mediaType, callState)
		{
			this.callType = TrunkCallType.TCT_DUMMY_VIDEO_DISPATCH;
			this.strVideoId = VideoId;
			this.strDstObjId = remoteParty;
			this.strFormat = base.MediaType.ToString();
		}
	}
}
