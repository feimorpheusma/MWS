using log4net;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public class MyPublicationSession : MySipSession
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyPublicationSession));

		private readonly PublicationSession session;

		protected override SipSession Session
		{
			get
			{
				return this.session;
			}
		}

		public MyPublicationSession(MySipStack sipStack, string toUri) : base(sipStack)
		{
		}
	}
}
