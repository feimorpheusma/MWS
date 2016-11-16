using DispCore.Utils;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Sip
{
	public class MySubscriptionSession : MySipSession
	{
		public enum EVENT_PACKAGE_TYPE
		{
			CONFERENCE,
			DIALOG,
			MESSAGE_SUMMARY,
			PRESENCE,
			PRESENCE_LIST,
			REG,
			SIP_PROFILE,
			UA_PROFILE,
			WINFO,
			XCAP_DIFF
		}

		private readonly SubscriptionSession session;

		private readonly MySubscriptionSession.EVENT_PACKAGE_TYPE eventPackage;

		protected override SipSession Session
		{
			get
			{
				return this.session;
			}
		}

		public MySubscriptionSession.EVENT_PACKAGE_TYPE EventPackage
		{
			get
			{
				return this.eventPackage;
			}
		}

		public MySubscriptionSession(MySipStack sipStack, string toUri, MySubscriptionSession.EVENT_PACKAGE_TYPE eventPackage) : base(sipStack)
		{
			this.session = new SubscriptionSession(sipStack.WrappedStack);
			this.eventPackage = eventPackage;
			base.init();
			base.SigCompId = sipStack.SigCompId;
			switch (eventPackage)
			{
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.CONFERENCE:
				this.session.addHeader("Event", "conference");
				this.session.addHeader("Accept", "application/conference-info+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.DIALOG:
				this.session.addHeader("Event", "dialog");
				this.session.addHeader("Accept", "application/dialog-info+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.MESSAGE_SUMMARY:
				this.session.addHeader("Event", "message-summary");
				this.session.addHeader("Accept", "application/simple-message-summary");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PRESENCE:
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PRESENCE_LIST:
				this.session.addHeader("Event", "presence");
				if (eventPackage == MySubscriptionSession.EVENT_PACKAGE_TYPE.PRESENCE_LIST)
				{
					this.session.addHeader("Supported", "eventlist");
				}
				this.session.addHeader("Accept", string.Format("{0}, {1}, {2}, {3}", new object[]
				{
					"multipart/related",
					"application/pidf+xml",
					"application/rlmi+xml",
					"application/rpid+xml"
				}));
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.REG:
				this.session.addHeader("Event", "reg");
				this.session.addHeader("Accept", "application/reginfo+xml");
				this.session.setSilentHangup(true);
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.SIP_PROFILE:
				this.session.addHeader("Event", "sip-profile");
				this.session.addHeader("Accept", "application/vnd.oma.im.deferred-list+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.UA_PROFILE:
				this.session.addHeader("Event", "ua-profile");
				this.session.addHeader("Accept", "application/xcap-diff+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.WINFO:
				this.session.addHeader("Event", "presence.winfo");
				this.session.addHeader("Accept", "application/watcherinfo+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.XCAP_DIFF:
				this.session.addHeader("Event", "xcap-diff");
				this.session.addHeader("Accept", "application/xcap-diff+xml");
				break;
			}
			base.ToUri = UriUtils.GetValidSipUri(toUri);
			this.fromUri = UriUtils.GetValidSipUri(this.fromUri);
			this.session.addHeader("Allow-Events", "refer, presence, presence.winfo, xcap-diff, conference");
		}

		public bool Subscribe()
		{
			return this.session.subscribe();
		}

		public bool UnSubscribe()
		{
			return this.session.unSubscribe();
		}
	}
}
