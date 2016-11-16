using DispCore.Utils;
using log4net;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public class MyInfoSession : MySipSession
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyInfoSession));

		private readonly InfoSession m_Session;

		protected override SipSession Session
		{
			get
			{
				return this.m_Session;
			}
		}

		public MyInfoSession(MySipStack sipStack, string toUri) : base(sipStack)
		{
			this.m_Session = new InfoSession(sipStack.WrappedStack);
			base.init();
			base.ToUri = UriUtils.GetValidSipUri(toUri);
			base.SigCompId = sipStack.SigCompId;
		}

		public bool Send(byte[] payload, string contentType)
		{
			bool result;
			if (payload != null && !string.IsNullOrEmpty(contentType))
			{
				ActionConfig config = new ActionConfig();
				config.addHeader("Content-Type", contentType);
				result = this.m_Session.send(payload, config);
			}
			else
			{
				result = this.m_Session.send(System.IntPtr.Zero, 0u);
			}
			return result;
		}

		public bool Send(byte[] payload, ActionConfig config)
		{
			bool result;
			if (payload != null && config != null)
			{
				result = this.m_Session.send(payload, config);
			}
			else
			{
				result = this.m_Session.send(System.IntPtr.Zero, 0u);
			}
			return result;
		}
	}
}
