using DispCore.Types.Trunk;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Trunk
{
	public class TrunkMessageSession : MyMessageSession
	{
		private TrunkMsgType msgType;

		private bool e2ee;

		public TrunkMsgType MsgType
		{
			get
			{
				return this.msgType;
			}
			set
			{
				this.msgType = value;
			}
		}

		public bool E2ee
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

		public TrunkMessageSession(MySipStack sipStack, MessagingSession session, string toUri) : base(sipStack, session, toUri)
		{
		}
	}
}
