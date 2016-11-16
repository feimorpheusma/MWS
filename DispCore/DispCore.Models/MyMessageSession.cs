using DispCore.Utils;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.Text;

namespace DispCore.Models
{
	public class MyMessageSession : MySipSession
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MyMessageSession));

		private readonly MessagingSession session;

		private static int SMS_MR = 0;

		private byte[] payload;

		private MessageSendingStatus sendingStatus;

		private string localPort;

		private string localIP;

		private string strRemoteSender;

		protected override SipSession Session
		{
			get
			{
				return this.session;
			}
		}

		public MessageSendingStatus SendingStatus
		{
			get
			{
				return this.sendingStatus;
			}
			set
			{
				this.sendingStatus = value;
				base.OnPropertyChanged("SendingStatus");
			}
		}

		public byte[] Payload
		{
			set
			{
				this.payload = value;
			}
		}

		public string Content
		{
			get
			{
				string result;
				if (this.payload == null)
				{
					result = "";
				}
				else
				{
					result = System.Text.Encoding.UTF8.GetString(this.payload);
				}
				return result;
			}
		}

		public string LocalPort
		{
			get
			{
				return this.localPort;
			}
			set
			{
				this.localPort = value;
			}
		}

		public string LocalIP
		{
			get
			{
				return this.localIP;
			}
			set
			{
				this.localIP = value;
			}
		}

		public string RemoteSender
		{
			get
			{
				return this.strRemoteSender;
			}
			set
			{
				this.strRemoteSender = value;
			}
		}

		public MyMessageSession(MySipStack sipStack, MessagingSession session, string toUri) : base(sipStack)
		{
			this.session = ((session == null) ? new MessagingSession(sipStack.WrappedStack) : session);
			base.init();
			base.ToUri = UriUtils.GetValidSipUri(toUri);
			base.StartTime = System.DateTime.Now;
			base.SigCompId = sipStack.SigCompId;
		}

		public bool SendBinaryMessage(string text, string SMSC)
		{
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				string dstSipUri = base.ToUri;
				string SMSCPhoneNumber;
				string dstPhoneNumber;
				if ((SMSCPhoneNumber = UriUtils.GetValidPhoneNumber(SMSC)) != null && (dstPhoneNumber = UriUtils.GetValidPhoneNumber(dstSipUri)) != null)
				{
					base.ToUri = SMSC;
					this.session.addHeader("Content-Type", "application/vnd.3gpp.sms");
					this.session.addHeader("Content-Transfer-Encoding", "binary");
					this.session.addHeader("Contact", string.Format("<{0};transport=udp>", this.fromUri));
					RPMessage rpMessage = SMSEncoder.encodeSubmit(++MyMessageSession.SMS_MR, SMSCPhoneNumber, dstPhoneNumber, text);
					bool ret = this.session.send(rpMessage.getPayload());
					rpMessage.Dispose();
					if (MyMessageSession.SMS_MR >= 255)
					{
						MyMessageSession.SMS_MR = 0;
					}
					result = ret;
				}
				else
				{
					MyMessageSession.LOG.Error(string.Format("SMSC={0} or RemoteUri={1} is invalid", SMSC, dstSipUri));
					result = this.SendTextMessage(text);
				}
			}
			return result;
		}

		public bool SendTextMessage(string text, string contentType)
		{
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				this.payload = System.Text.Encoding.UTF8.GetBytes(text);
				this.session.addHeader("Content-Type", string.IsNullOrEmpty(contentType) ? "text/plain;charset=UTF-8" : contentType);
				this.session.addHeader("Contact", string.Format("<{0};transport=udp>", this.fromUri));
				bool ret = this.session.send(this.payload);
				result = ret;
			}
			return result;
		}

		public bool SendTextMessage(string text, string contentType, string strPTTExtenstion)
		{
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				this.payload = System.Text.Encoding.UTF8.GetBytes(text);
				this.session.addHeader("Ptt-Extension", strPTTExtenstion);
				if (text != null && contentType != null)
				{
					this.session.addHeader("Content-Type", string.IsNullOrEmpty(contentType) ? "text/plain;charset=UTF-8" : contentType);
				}
				bool ret = this.session.send(this.payload);
				result = ret;
			}
			return result;
		}

		public bool SendTextX686Message(string text, string contentType)
		{
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				this.session.addHeader("app_type", "IMS messaging/Out-mode messaging");
				this.session.addHeader("Content-Type", "text/plain;charset=UTF-8");
				this.payload = System.Text.Encoding.UTF8.GetBytes(text);
				bool ret = this.session.send(this.payload);
				result = ret;
			}
			return result;
		}

		public bool SendBtrunkMessage(string text, string contentType, string strMsgType, string strE2ee, string strMsgMode)
		{
			bool result;
			if (text == null)
			{
				result = false;
			}
			else
			{
				string strPttMsgHeard = string.Format("pttmsg;msgtype={0};e2ee={1}; msgmode={2}", strMsgType, strE2ee, strMsgMode);
				result = this.SendTextMessage(text, contentType, strPttMsgHeard);
			}
			return result;
		}

		public bool SendTextMessage(string text)
		{
			return this.SendTextMessage(text, null);
		}
	}
}
