using DispCore.Utils;
using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models
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
			XCAP_DIFF,
			CALL,
			PTT_MEMBRELATION_SUB,
			PTT_REG_SUB,
			PTT_UECALL_SUB,
			PTT_GRCALL_SUB,
			PTT_ONLINECALL_SUB
		}

		private readonly SubscriptionSession session;

		private readonly MySubscriptionSession.EVENT_PACKAGE_TYPE eventPackage;

		private string strSubHeader;

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
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_MEMBRELATION_SUB:
				this.session.addHeader("Event", "MembershipAttributes");
				this.session.addHeader("Accept", "application/pttmembershipinfo+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_REG_SUB:
				this.session.addHeader("Event", "UERegisterStatus");
				this.session.addHeader("Accept", "application/pttuereginfo+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_UECALL_SUB:
				this.session.addHeader("Event", "UECallStatus");
				this.session.addHeader("Accept", "application/pttuecallinfo+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_GRCALL_SUB:
				this.session.addHeader("Event", "GroupCallStatus");
				this.session.addHeader("Accept", "application/pttgroupcallinfo+xml");
				break;
			case MySubscriptionSession.EVENT_PACKAGE_TYPE.PTT_ONLINECALL_SUB:
				this.session.addHeader("Event", "OnLineCallStatus");
				this.session.addHeader("Accept", "application/pttsysonlinecallinfo+xml");
				break;
			}
			base.ToUri = UriUtils.GetValidSipUri(toUri);
		}

		public bool Subscribe(string strUheader)
		{
			this.session.removeHeader("Ptt-Extension");
			this.session.addHeader("Ptt-Extension", strUheader);
			this.strSubHeader = strUheader;
			return this.session.subscribe();
		}

		public bool Subscribe()
		{
			return this.session.subscribe();
		}

		public bool UnSubscribe()
		{
			if (this.strSubHeader != null && this.strSubHeader != string.Empty)
			{
				this.session.addHeader("Ptt-Extension", this.strSubHeader);
			}
			return this.session.unSubscribe();
		}
	}
}
