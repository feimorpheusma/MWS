using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
{
	public class MyRegistrationSession : MySipSession
	{
		private readonly RegistrationSession session;

		protected override SipSession Session
		{
			get
			{
				return this.session;
			}
		}

		public MyRegistrationSession(MySipStack sipStack) : base(sipStack)
		{
			this.session = new RegistrationSession(sipStack.WrappedStack);
			base.init();
			base.SigCompId = sipStack.SigCompId;
			this.session.addHeader("Ptt-Extension", "pttregister");
		}

		public bool register()
		{
			return this.session.register_();
		}

		public bool unregister()
		{
			return this.session.unRegister();
		}
	}
}
