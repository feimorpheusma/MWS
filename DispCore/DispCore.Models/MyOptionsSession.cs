using log4net;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public class MyOptionsSession : MySipSession
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyOptionsSession));

		private readonly OptionsSession session;

		protected override SipSession Session
		{
			get
			{
				return this.session;
			}
		}

		public MyOptionsSession(MySipStack sipStack, string toUri) : base(sipStack)
		{
			this.session = new OptionsSession(sipStack.WrappedStack);
			base.init();
			base.ToUri = toUri;
			base.SigCompId = sipStack.SigCompId;
		}

		public bool Send(ActionConfig config)
		{
			return this.session.send(config);
		}

		public bool Send()
		{
			return this.session.send();
		}

		public bool Accept(ActionConfig config)
		{
			return this.session.accept(config);
		}

		public bool Accept()
		{
			return this.session.accept();
		}

		public bool Reject(ActionConfig config)
		{
			return this.session.reject(config);
		}

		public bool Reject()
		{
			return this.session.reject();
		}
	}
}
