using DispCore.Events;
using DispCore.Models;
using DispCore.Models.Trunk;
using DispCore.Trunk.Types;
using DispCore.Types;
using DispCore.Types.Trunk;
using DispCore.Utils;
using DispCore.Utils.Trunk;
using org.doubango.tinyWRAP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace DispCore.Services.Impl
{
	public class ServiceRealizeService : IServiceRealizeService, IService
	{
		protected SessionManager avSessionMgr;

		protected SessionManager msgSessionMgr;

		protected SessionManager vDisSessionMgr;

		private ServiceManager serviceManager;

		private IStackService stackService;

		public event System.EventHandler<ServiceSessionChangedEventArgs> onServiceSessionChangedEvent;

		public SessionManager AvSessionMgr
		{
			get
			{
				return this.avSessionMgr;
			}
		}

		public SessionManager DisSessionMgr
		{
			get
			{
				return this.vDisSessionMgr;
			}
		}

		public SessionManager MsgSessionMgr
		{
			get
			{
				return this.msgSessionMgr;
			}
		}

		private MyAVSession CreateOutgoingSession(MySipStack sipStack, CallSession session, MediaType mediaType, string remoteUri, MediaAttr attribute)
		{
			MyAVSession result;
			if (remoteUri == null || remoteUri == "")
			{
				MessageBox.Show("请输入被叫号码！");
				result = null;
			}
			else
			{
				remoteUri = UriUtils.GetValidSipUri(remoteUri);
				MyAVSession avSession = this.FindAVSession(remoteUri);
				if (avSession != null)
				{
					avSession.HangUpCallEx();
				}
				if (this.FindAVSession(remoteUri) != null)
				{
					MessageBox.Show("该用户已在呼叫中！");
					result = null;
				}
				else
				{
					avSession = new MyAVSession(sipStack, session, mediaType, InviteState.INPROGRESS);
					avSession.FromUri = UriUtils.GetValidSipUri(this.serviceManager.ConfigurationService.IdentityCfg.Impu);
					if (avSession != null)
					{
						avSession.MakeCall(remoteUri, attribute);
					}
					result = avSession;
				}
			}
			return result;
		}

		private MyAVSession CreateOutgoingSession(MySipStack sipStack, CallSession session, MediaType mediaType, string remoteUri, MediaAttr attribute, TrunkCallParam param)
		{
			MyAVSession result;
			if (remoteUri == null || remoteUri == "")
			{
				MessageBox.Show("请输入被叫号码！");
				result = null;
			}
			else
			{
				remoteUri = UriUtils.GetValidSipUri(remoteUri);
				MyAVSession avSession = this.FindAVSession(remoteUri);
				if (avSession != null)
				{
					avSession.HangUpCallEx();
				}
				if (this.FindAVSession(remoteUri) != null)
				{
					MessageBox.Show("该用户已在呼叫中！");
					result = null;
				}
				else
				{
					avSession = new MyAVSession(sipStack, session, mediaType, InviteState.INPROGRESS, param);
					avSession.FromUri = UriUtils.GetValidSipUri(this.serviceManager.ConfigurationService.IdentityCfg.Impu);
					string strPttPara = string.Format("{0};{1}={2};{3}={4};{5}={6};{7}={8};{9}={10};", new object[]
					{
						"pttcall",
						"calltype",
						param.strCallType,
						"PrioAttribute",
						param.strPrioAttribute,
						"e2ee",
						param.stre2ee,
						"duplex",
						param.strduplex,
						"foaoroacsu",
						param.strfoaoroacsu
					});
					ActionConfig config = new ActionConfig();
					config.addHeader("Ptt-Extension", strPttPara);
					if (avSession != null)
					{
						avSession.MakeCall(remoteUri, attribute, config);
					}
					config.Dispose();
					result = avSession;
				}
			}
			return result;
		}

		public MyAVSession CreateOutgoingSession(MySipStack sipStack, MediaType mediaType, string remoteUri, MediaAttr attribute)
		{
			return this.CreateOutgoingSession(sipStack, null, mediaType, remoteUri, attribute);
		}

		public MyAVSession CreateOutgoingSession(MySipStack sipStack, MediaType mediaType, string remoteUri, MediaAttr attribute, TrunkCallParam param)
		{
			return this.CreateOutgoingSession(sipStack, null, mediaType, remoteUri, attribute, param);
		}

		public MyAVSession CreateOutgoingSession(MySipStack sipStack, MediaType mediaType, string remoteUri, MediaAttr attribute, ActionConfig config)
		{
			MyAVSession result;
			if (remoteUri == null || remoteUri == "")
			{
				MessageBox.Show("请输入被叫号码！");
				result = null;
			}
			else
			{
				remoteUri = UriUtils.GetValidSipUri(remoteUri);
				MyAVSession avSession = this.FindAVSession(remoteUri);
				if (avSession != null)
				{
					avSession.HangUpCallEx();
				}
				if (this.FindAVSession(remoteUri) != null)
				{
					MessageBox.Show("该用户已在呼叫中！");
					result = null;
				}
				else
				{
					avSession = new MyAVSession(sipStack, null, mediaType, InviteState.INPROGRESS);
					avSession.FromUri = UriUtils.GetValidSipUri(this.serviceManager.ConfigurationService.IdentityCfg.Impu);
					if (avSession != null)
					{
						avSession.MakeCall(remoteUri, attribute, config);
					}
					result = avSession;
				}
			}
			return result;
		}

		public ServiceRealizeService(ServiceManager manager)
		{
			this.serviceManager = manager;
			this.avSessionMgr = new SessionManager();
			this.msgSessionMgr = new SessionManager();
			this.vDisSessionMgr = new SessionManager();
		}

		public bool Start()
		{
			this.stackService = this.serviceManager.StackService;
			this.stackService.onCallEvent += new System.EventHandler<CallEventArgs>(this.OnCallEvent);
			this.stackService.onMessageEvent += new System.EventHandler<MessageEventArgs>(this.OnMessageEvent);
			this.stackService.onVideoSendEvent += new System.EventHandler<VideoSendEventArgs>(this.OnVideoSendEvent);
			return true;
		}

		public bool Stop()
		{
			bool result;
			if (this.stackService == null)
			{
				result = false;
			}
			else
			{
				this.stackService.onCallEvent -= new System.EventHandler<CallEventArgs>(this.OnCallEvent);
				this.stackService.onVideoSendEvent -= new System.EventHandler<VideoSendEventArgs>(this.OnVideoSendEvent);
				result = true;
			}
			return result;
		}

		public void ReceiveCall(CallEventArgs e)
		{
			CallSession callSession = e.GetExtra("session") as CallSession;
			if (callSession != null)
			{
				twrap_media_type_t sessionType = (twrap_media_type_t)e.GetExtra("sessiontype");
				SipMessage sipMessage = e.GetExtra("sipemessage") as SipMessage;
				MediaType media = MediaTypeUtils.ConvertFromNative(sessionType);
				MyAVSession avSession = new MyAVSession(this.stackService.SipStack, callSession, media, InviteState.INCOMING);
				avSession.State = InviteState.INCOMING;
				avSession.RemotePartyUri = sipMessage.getSipHeaderValue("f");
				string callType = sipMessage.getSipHeaderParamValue("Call-Info", "type");
				if (callType != null && callType == "group_call")
				{
					avSession.IsGroupSession = true;
				}
				string strHeard = sipMessage.getSipHeaderValue("Ptt-Extension");
				string strCallType = TrunkUitls.GetPTTExtension(strHeard, "calltype");
				if (strCallType != null && strCallType.Length > 0 && int.Parse(strCallType.Trim()) >= 4 && int.Parse(strCallType.Trim()) <= 7)
				{
					avSession.IsGroupSession = true;
				}
				callType = sipMessage.getSipHeaderValue("APP_TYPE");
				if (callType != null && callType.Contains("groupcall"))
				{
					avSession.IsGroupSession = true;
				}
				string strUser = UriUtils.GetUserName(avSession.RemotePartyUri);
				ContactItem contactItem = this.serviceManager.ContactService.FindItem(strUser, ContactType.Any);
				if (contactItem != null)
				{
					if (contactItem.FindAVSession(media) != null)
					{
						avSession.HangUpCall(TrunkCallReleaseReason.TCRL_GEN_RESEAVE);
						avSession.Dispose();
						return;
					}
					contactItem.AddAVSession(avSession);
				}
				string strfoaoroacsu = TrunkUitls.GetPTTExtension(strHeard, "foaoroacsu");
				avSession.Foaoroacsu = strfoaoroacsu;
				lock (this.avSessionMgr)
				{
					this.avSessionMgr.AddSession(avSession.Id, avSession);
				}
				this.serviceManager.SoundService.PlayTone(Tone.TONE_RING, true, avSession.Id);
				ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_INCOMING_SESSION, avSession.Id, avSession.RemotePartyUri);
				args.AddExtra("session", avSession);
				EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
			}
		}

		public void ReceiveLongMessage(CallEventArgs e)
		{
			MyMsrpSession session = e.GetExtra("session") as MyMsrpSession;
			if (session != null)
			{
				lock (this.msgSessionMgr)
				{
					MyMessageSession msgSession = new MyMessageSession(this.stackService.SipStack, null, (string)e.GetExtra("from"));
					msgSession.IsOutgoing = false;
					msgSession.RemotePartyUri = session.RemotePartyUri;
					msgSession.SendingStatus = MessageSendingStatus.MSS_NONE;
					System.IO.FileInfo fileReceive = new System.IO.FileInfo(session.FilePath);
					msgSession.Payload = System.Text.Encoding.UTF8.GetBytes("接受文件:" + fileReceive.Name);
					this.msgSessionMgr.AddSession(msgSession.Id, msgSession);
					ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_MSG_SESSION, msgSession.Id, msgSession.RemotePartyUri);
					args.AddExtra("session", msgSession);
					EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
				}
				session.Accept();
			}
		}

		public void OnCallEvent(object sender, CallEventArgs e)
		{
			switch (e.Type)
			{
			case CallEventTypes.CALL_INCOMING:
			{
				CallSession callSession = e.GetExtra("session") as CallSession;
				if (callSession != null)
				{
					this.ReceiveCall(e);
				}
				else
				{
					this.ReceiveLongMessage(e);
				}
				break;
			}
			case CallEventTypes.CALL_INPROGRESS:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.INPROGRESS;
				}
				break;
			}
			case CallEventTypes.CALL_RINGING:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.REMOTE_RINGING;
					this.serviceManager.SoundService.PlayTone(Tone.TONE_RINGBACK, true, sipSession.Id);
				}
				break;
			}
			case CallEventTypes.CALL_CONNECTED:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.INCALL;
					(sipSession as MyInviteSession).StartTime = System.DateTime.Now;
					sipSession.IsConnected = true;
					this.serviceManager.SoundService.StopPlay(sipSession.Id);
				}
				break;
			}
			case CallEventTypes.CALL_DISCONNECTED:
			{
				MyAVSession avSession = this.FindAVSession(e.SessionId);
				if (avSession != null)
				{
					avSession.State = InviteState.TERMINATED;
					avSession.Code = (short)e.GetExtra("code");
					this.serviceManager.SoundService.StopPlay(avSession.Id);
					if ((int)avSession.Code != tinyWRAP.tsip_event_code_dialog_terminated)
					{
						avSession.State = InviteState.POST_TERMINATED;
						switch (avSession.Code)
						{
						case 403:
							this.serviceManager.SoundService.PlayTone(Tone.TONE_FORBIDDEN, false, avSession.Id);
							break;
						case 404:
							this.serviceManager.SoundService.PlayTone(Tone.TONE_NOTFOUND, false, avSession.Id);
							break;
						default:
							this.serviceManager.SoundService.PlayTone(Tone.TONE_SERVICE_UNAVAILABLE, false, avSession.Id);
							break;
						}
					}
					if (!avSession.IsOutgoing && !avSession.IsConnected)
					{
						avSession.IsMissed = true;
						avSession.State = InviteState.POST_TERMINATED;
					}
					this.ClearSesion(e.SessionId);
					ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.DEL_SESSION, e.SessionId, avSession.RemotePartyUri);
					args.AddExtra("session", avSession);
					EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
				}
				break;
			}
			case CallEventTypes.CALL_LOCAL_HOLD_OK:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.LOCAL_HELD;
				}
				break;
			}
			case CallEventTypes.CALL_LOCAL_RESUME_OK:
			case CallEventTypes.CALL_REMOTE_RESUME:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.INCALL;
				}
				break;
			}
			case CallEventTypes.CALL_REMOTE_HOLD:
			{
				MySipSession sipSession = this.FindAVSession(e.SessionId);
				if (sipSession != null)
				{
					(sipSession as MyInviteSession).State = InviteState.REMOTE_HELD;
				}
				break;
			}
			case CallEventTypes.CALL_MEDIA_UPDATED:
			{
				MyAVSession avSession = this.FindAVSession(e.SessionId);
				InviteEvent orignEvent = (InviteEvent)e.GetExtra("orignevent");
				if (avSession != null && orignEvent != null)
				{
					twrap_media_type_t newMediaType = orignEvent.getMediaType();
					avSession.MediaType = MediaTypeUtils.ConvertFromNative(newMediaType);
				}
				break;
			}
			}
		}

		public void OnMessageEvent(object sender, MessageEventArgs e)
		{
			MessageEventTypes type = e.Type;
			if (type == MessageEventTypes.INCOMING)
			{
				lock (this.msgSessionMgr)
				{
					MessagingSession orginSession = (MessagingSession)e.GetExtra("session");
					string strPPI = (string)e.GetExtra("PPI");
					MyMessageSession msgSession = this.msgSessionMgr.FindSession(e.SessionId) as MyMessageSession;
					if (msgSession == null)
					{
						msgSession = new MyMessageSession(this.stackService.SipStack, orginSession, (string)e.GetExtra("from"));
					}
					msgSession.IsOutgoing = false;
					msgSession.RemoteSender = strPPI;
					msgSession.RemotePartyUri = (string)e.GetExtra("from");
					msgSession.SendingStatus = MessageSendingStatus.MSS_NONE;
					msgSession.Payload = e.Payload;
					this.msgSessionMgr.AddSession(msgSession.Id, msgSession);
					ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_MSG_SESSION, msgSession.Id, msgSession.RemotePartyUri);
					args.AddExtra("session", msgSession);
					EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
				}
			}
		}

		private void OnVideoSendEvent(object sender, VideoSendEventArgs e)
		{
			string strUdn = e.GetExtra("UDN") as string;
			string strResult = e.GetExtra("pttVideoForwardReport") as string;
			string strResultText = "";
			if (strResult != null && !(strResult == string.Empty))
			{
				strResult = strResult.Trim();
				try
				{
					string[] vReslust = strResult.Split(new char[]
					{
						';'
					});
					if (vReslust.Length > 2)
					{
						string strVideoId = vReslust[1].Trim();
						string[] vVideoId = strVideoId.Split(new char[]
						{
							'='
						});
						if (vVideoId != null && vVideoId.Length > 1)
						{
							strVideoId = vVideoId[1];
						}
						int i = 2;
						while (i < vReslust.Length)
						{
							string strUDNResult = vReslust[i];
							if (strUDNResult != null && strUDNResult != string.Empty)
							{
								string[] vUDNResultValue = strUDNResult.Trim().Split(new char[]
								{
									','
								});
								if (vUDNResultValue != null && vUDNResultValue.Length >= 3)
								{
									string UDN = vUDNResultValue[0];
									string uType = vUDNResultValue[1];
									string result = vUDNResultValue[2];
									string[] vUDN = null;
									string[] vVesult = null;
									if (UDN != null && UDN != string.Empty)
									{
										vUDN = UDN.Split(new char[]
										{
											'='
										});
									}
									if (result != null && result != string.Empty)
									{
										vVesult = result.Split(new char[]
										{
											'='
										});
									}
									if (vUDN != null && vUDN.Length > 0 && vVesult != null && vVesult.Length > 0)
									{
										string strResulstValue = vVesult[1];
										switch (int.Parse(strResulstValue.Trim()))
										{
										case 0:
										{
											TrunkVideoDispSession senstion = new TrunkVideoDispSession(vUDN[1].Trim(), strVideoId, MediaType.Video, InviteState.NONE);
											this.vDisSessionMgr.AddSession(senstion.Id, senstion);
											break;
										}
										case 1:
											MessageBox.Show(string.Format("视频转发给：{0}，{1}，失败码：{2}", vUDN[1].Trim(), "终端不支持视频", strResulstValue));
											break;
										case 2:
											MessageBox.Show(string.Format("视频转发给：{0}，{1}，失败码：{2}", vUDN[1].Trim(), "终端拒绝", strResulstValue));
											break;
										case 3:
										{
											MessageBox.Show(string.Format("视频转发给：{0}，{1}，失败码：{2}", vUDN[1].Trim(), "终端主动释放", strResulstValue));
											TrunkVideoDispSession sension = this.FindVDispSession(vUDN[1].Trim()) as TrunkVideoDispSession;
											if (sension != null)
											{
												this.RemoveVDispSession(sension.Id);
											}
											break;
										}
										}
									}
								}
							}
							IL_2CC:
							i++;
							continue;
							goto IL_2CC;
						}
					}
				}
				catch
				{
					MessageBox.Show(string.Format("视频转发给：{0}，{1}", strUdn, "异常：" + strResultText));
				}
			}
		}

		public void AddContactAVSession(MyAVSession avSession)
		{
			if (avSession != null)
			{
				string strUser = UriUtils.GetUserName(avSession.RemotePartyUri);
				ContactItem contact = this.serviceManager.ContactService.FindItem(strUser, ContactType.Any);
				if (contact != null)
				{
					contact.AddAVSession(avSession);
				}
			}
		}

		public void DelContactAVSession(MyAVSession avSession)
		{
			if (avSession != null)
			{
				string strUser = UriUtils.GetUserName(avSession.RemotePartyUri);
				ContactItem contact = this.serviceManager.ContactService.FindItem(strUser, ContactType.Any);
				if (contact != null)
				{
					contact.DelAVSession(avSession);
				}
			}
		}

		public MyAVSession FindAVSession(long sessionId)
		{
			MySipSession session = this.avSessionMgr.FindSession(sessionId);
			return (MyAVSession)session;
		}

		public MyAVSession FindAVSession(string strUri)
		{
			strUri = UriUtils.GetValidSipUri(strUri);
			MyAVSession result;
			if (strUri == null || strUri == string.Empty)
			{
				result = null;
			}
			else
			{
				foreach (MySipSession session in this.avSessionMgr.Sessions)
				{
					if ((session.RemotePartyUri != null && session.RemotePartyUri.Equals(strUri, System.StringComparison.InvariantCultureIgnoreCase)) || (session.ToUri != null && session.ToUri.Equals(strUri, System.StringComparison.InvariantCultureIgnoreCase)))
					{
						MyAVSession ses = session as MyAVSession;
						result = ses;
						return result;
					}
				}
				result = null;
			}
			return result;
		}

		public void ClearSesion(long lSensionId)
		{
			MyAVSession avSession = this.FindAVSession(lSensionId);
			if (avSession != null)
			{
				this.DelContactAVSession(avSession);
				avSession.Dispose();
				this.RemoveAVSession(lSensionId);
			}
		}

		public bool RemoveAVSession(long sessionId)
		{
			MySipSession session = this.avSessionMgr.FindSession(sessionId);
			if (session != null)
			{
				this.avSessionMgr.DelSession(session);
			}
			return true;
		}

		public MySipSession FindMsgSession(long sessionId)
		{
			return this.msgSessionMgr.FindSession(sessionId);
		}

		public MySipSession FindVDispSession(long sessionId)
		{
			return this.vDisSessionMgr.FindSession(sessionId);
		}

		public MySipSession FindVDispSession(string strUDN)
		{
			MySipSession result;
			foreach (MySipSession sension in this.vDisSessionMgr.Sessions)
			{
				if (sension.RemotePartyUri.Equals(strUDN, System.StringComparison.InvariantCultureIgnoreCase))
				{
					result = sension;
					return result;
				}
			}
			result = null;
			return result;
		}

		public bool RemoveVDispSession(long sessionId)
		{
			MySipSession session = this.vDisSessionMgr.FindSession(sessionId);
			if (session != null)
			{
				this.vDisSessionMgr.DelSession(session);
			}
			return true;
		}

		public MyAVSession AudioCall(string remoteUri, bool triggerEvent, byte foaoroacsu, byte PrioAttribute)
		{
			TrunkCallParam param = new TrunkCallParam();
			param.strCallType = string.Format("{0}", 1);
			param.strPrioAttribute = string.Format("{0}", PrioAttribute);
			param.strfoaoroacsu = string.Format("{0}", foaoroacsu);
			param.strduplex = string.Format("{0}", 1);
			param.stre2ee = string.Format("{0}", 1);
			param.strpriority = "255";
			param.strCalledType = string.Format("{0}", 3);
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, remoteUri, MediaAttr.Sendrecv, param);
			MyAVSession result;
			if (avSession == null)
			{
				result = null;
			}
			else
			{
				this.avSessionMgr.AddSession(avSession.Id, avSession);
				if (triggerEvent)
				{
					ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_OUTGOING_SESSION, avSession.Id, avSession.RemotePartyUri);
					args.AddExtra("session", avSession);
					EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
				}
				this.AddContactAVSession(avSession);
				result = avSession;
			}
			return result;
		}

		public MyAVSession VideoCall(string remoteUri, bool triggerEvent)
		{
			TrunkCallParam param = new TrunkCallParam();
			param.strCallType = string.Format("{0}", 2);
			param.strPrioAttribute = string.Format("{0}", 0);
			param.strfoaoroacsu = string.Format("{0}", 0);
			param.strduplex = string.Format("{0}", 1);
			param.stre2ee = string.Format("{0}", 1);
			param.strpriority = "255";
			param.strCalledType = string.Format("{0}", 3);
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.AudioVideo, remoteUri, MediaAttr.Sendrecv, param);
			MyAVSession result;
			if (avSession == null)
			{
				result = null;
			}
			else
			{
				if (avSession != null)
				{
					this.avSessionMgr.AddSession(avSession.Id, avSession);
					if (triggerEvent)
					{
						ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_OUTGOING_SESSION, avSession.Id, avSession.RemotePartyUri);
						args.AddExtra("session", avSession);
						EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
					}
				}
				this.AddContactAVSession(avSession);
				result = avSession;
			}
			return result;
		}

		public MyAVSession VideoOnlyCall(string remoteUri, bool triggerEvent)
		{
			TrunkCallParam param = new TrunkCallParam();
			param.strCallType = string.Format("{0}", 3);
			param.strPrioAttribute = string.Format("{0}", 0);
			param.strfoaoroacsu = string.Format("{0}", 0);
			param.strduplex = string.Format("{0}", 1);
			param.stre2ee = string.Format("{0}", 1);
			param.strpriority = "255";
			param.strCalledType = string.Format("{0}", 3);
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Video, remoteUri, MediaAttr.Sendrecv, param);
			MyAVSession result;
			if (avSession == null)
			{
				result = null;
			}
			else
			{
				if (avSession != null)
				{
					this.avSessionMgr.AddSession(avSession.Id, avSession);
					if (triggerEvent)
					{
						ServiceSessionChangedEventArgs args = new ServiceSessionChangedEventArgs(ServiceSessionChangedEventTypes.NEW_OUTGOING_SESSION, avSession.Id, avSession.RemotePartyUri);
						args.AddExtra("session", avSession);
						EventHandlerTrigger.TriggerEvent<ServiceSessionChangedEventArgs>(this.onServiceSessionChangedEvent, this, args);
					}
				}
				this.AddContactAVSession(avSession);
				result = avSession;
			}
			return result;
		}

		public MyAVSession VideoPollCall(string remoteUri, bool triggerEvent)
		{
			MyAVSession result;
			if (this.stackService == null)
			{
				result = null;
			}
			else
			{
				TrunkCallParam param = new TrunkCallParam();
				param.strCallType = string.Format("{0}", 20);
				param.strPrioAttribute = string.Format("{0}", 0);
				param.strduplex = string.Format("{0}", 1);
				param.stre2ee = string.Format("{0}", 1);
				string strPttPara = string.Format("{0};{1}={2};{3}={4};{5}={6};{7}={8};", new object[]
				{
					"pttcall",
					"calltype",
					param.strCallType,
					"PrioAttribute",
					param.strPrioAttribute,
					"e2ee",
					param.stre2ee,
					"duplex",
					param.strduplex
				});
				ActionConfig config = new ActionConfig();
				config.addHeader("Ptt-Extension", strPttPara);
				MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Video, remoteUri, MediaAttr.Recvonly, config);
				if (avSession == null)
				{
					result = null;
				}
				else
				{
					this.avSessionMgr.AddSession(avSession.Id, avSession);
					this.AddContactAVSession(avSession);
					result = avSession;
				}
			}
			return result;
		}

		public MyAVSession VideoPushCall(string remoteUri, bool triggerEvent)
		{
			TrunkCallParam param = new TrunkCallParam();
			param.strCallType = string.Format("{0}", 23);
			param.strPrioAttribute = string.Format("{0}", 0);
			param.strduplex = string.Format("{0}", 1);
			param.stre2ee = string.Format("{0}", 1);
			string strPttPara = string.Format("{0};{1}={2};{3}={4};{5}={6};{7}={8};", new object[]
			{
				"pttcall",
				"calltype",
				param.strCallType,
				"PrioAttribute",
				param.strPrioAttribute,
				"e2ee",
				param.stre2ee,
				"duplex",
				param.strduplex
			});
			ActionConfig config = new ActionConfig();
			config.addHeader("Ptt-Extension", strPttPara);
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Video, remoteUri, MediaAttr.Sendonly, config);
			MyAVSession result;
			if (avSession == null)
			{
				result = null;
			}
			else
			{
				this.avSessionMgr.AddSession(avSession.Id, avSession);
				this.AddContactAVSession(avSession);
				result = avSession;
			}
			return result;
		}

		public MyAVSession AmbianceListenCall(string remoteUri)
		{
			TrunkCallParam param = new TrunkCallParam();
			param.strCallType = string.Format("{0}", 16);
			param.strPrioAttribute = string.Format("{0}", 0);
			param.strduplex = string.Format("{0}", 1);
			param.stre2ee = string.Format("{0}", 1);
			string strPttPara = string.Format("{0};{1}={2};{3}={4};{5}={6};{7}={8};", new object[]
			{
				"pttcall",
				"calltype",
				param.strCallType,
				"PrioAttribute",
				param.strPrioAttribute,
				"e2ee",
				param.stre2ee,
				"duplex",
				param.strduplex
			});
			ActionConfig config = new ActionConfig();
			config.addHeader("Ptt-Extension", strPttPara);
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, remoteUri, MediaAttr.Recvonly, config);
			MyAVSession result;
			if (avSession == null)
			{
				result = null;
			}
			else
			{
				this.avSessionMgr.AddSession(avSession.Id, avSession);
				this.AddContactAVSession(avSession);
				result = avSession;
			}
			return result;
		}

		public bool ForceInCall(string remoteUri, string onlineCallId)
		{
			return this.P2PBreakInCall(remoteUri);
		}

		public bool P2PBreakInCall(string remoteUri)
		{
			bool result;
			if (remoteUri == null || remoteUri == "")
			{
				MessageBox.Show("请输入号码！");
				result = false;
			}
			else
			{
				MyAVSession avSession = this.FindAVSession(remoteUri);
				if (avSession != null)
				{
					MessageBox.Show("调度台已与该用户建立呼叫，不能执行此操作!");
					result = false;
				}
				else
				{
					ContactItem contact = this.serviceManager.ContactService.FindItem(remoteUri, ContactType.Person);
					if (contact == null)
					{
						MessageBox.Show("被叫用户不存在！");
						result = false;
					}
					else
					{
						Person p = contact as Person;
						if (p.CallIntances == null || p.CallIntances.Count <= 0)
						{
							MessageBox.Show("获取被叫用户呼叫的通话标识失败！");
							result = false;
						}
						else
						{
							TrunkUserCallService callSer = p.CallIntances[0] as TrunkUserCallService;
							string strPttPara = string.Format("pttinsert;OnlineCallID ={0};UDN={1};calltype={2}", callSer.OnlineCallID, remoteUri, callSer.CallType);
							ActionConfig config = new ActionConfig();
							config.addHeader("Ptt-Extension", strPttPara);
							avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.AudioVideo, remoteUri, MediaAttr.Sendrecv, config);
							if (avSession == null)
							{
								result = false;
							}
							else
							{
								if (avSession != null)
								{
									avSession.MakeCall(remoteUri, MediaAttr.Sendrecv);
									this.avSessionMgr.AddSession(avSession.Id, avSession);
									this.AddContactAVSession(avSession);
								}
								config.Dispose();
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		public bool P2PBreakOffCall(string remoteUri)
		{
			this.SendMessage(remoteUri, TrunkMsgOperaterType.TMT_QCQC, null, null);
			return true;
		}

		public bool GrpBreakInCall(string remoteUri)
		{
			return this.GrpBreakInCall(remoteUri);
		}

		public bool GrpBreakOffCall(string remoteUri)
		{
			return this.P2PBreakOffCall(remoteUri);
		}

		public bool StopAudioMonitorCall(string remoteUri)
		{
			return false;
		}

		public bool HoldCall(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			return avSession != null && avSession.HoldCall();
		}

		public bool ResumeCall(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			return avSession != null && avSession.ResumeCall();
		}

		public bool TransferCall(long sessionId)
		{
			return true;
		}

		public bool AudioMonitorCall(string remoteUri)
		{
			bool result;
			if (remoteUri == null || remoteUri == "")
			{
				MessageBox.Show("请输入号码！");
				result = false;
			}
			else
			{
				ContactItem cnt = this.serviceManager.ContactService.FindItem(remoteUri, ContactType.Person);
				if (cnt == null)
				{
					MessageBox.Show("输入号码的用户不存在！");
					result = false;
				}
				else
				{
					Person p = cnt as Person;
					if (p.CallIntances.Count == 0)
					{
						MessageBox.Show("获取该用户的呼叫状态出错！");
					}
					TrunkUserCallService callservice = p.CallIntances[0] as TrunkUserCallService;
					if (callservice == null || callservice.OnlineCallID == null || callservice.OnlineCallID == string.Empty)
					{
						MessageBox.Show("获取该用户的通话唯一标识失败，可能无法监听！");
					}
					string strPttPara = string.Format("pttDL;OnlineCallID ={0}", callservice.OnlineCallID);
					ActionConfig config = new ActionConfig();
					config.addHeader("Ptt-Extension", strPttPara);
					MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, remoteUri, MediaAttr.Recvonly, config);
					if (avSession == null)
					{
						result = false;
					}
					else
					{
						if (avSession != null)
						{
							avSession.MakeCall(remoteUri, MediaAttr.Recvonly);
							this.avSessionMgr.AddSession(avSession.Id, avSession);
							this.AddContactAVSession(avSession);
						}
						config.Dispose();
						result = true;
					}
				}
			}
			return result;
		}

		public bool AudioMonitorCall(string remoteUri, string onlineCallId)
		{
			ActionConfig config = new ActionConfig();
			config.addHeader("ServiceType", "monitor");
			MyAVSession avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, remoteUri, MediaAttr.Recvonly, config);
			bool result;
			if (avSession == null)
			{
				result = false;
			}
			else
			{
				if (avSession != null)
				{
					this.avSessionMgr.AddSession(avSession.Id, avSession);
					this.AddContactAVSession(avSession);
				}
				result = true;
			}
			return result;
		}

		public bool AudioMonitorCall(int resId)
		{
			return true;
		}

		public bool StopAudioMonitorCall(int resId)
		{
			return false;
		}

		public MyMessageSession SendMessage(string remoteUri, string content, string strMsgMode, bool bE2ee)
		{
			MyMessageSession result;
			if (remoteUri == null || remoteUri.Length == 0 || content == null || content.Length == 0)
			{
				result = null;
			}
			else
			{
				MyMessageSession messageSession = new MyMessageSession(this.stackService.SipStack, null, remoteUri);
				messageSession.IsOutgoing = true;
				messageSession.SendBtrunkMessage(content, "text/plain;charset=UTF-8", "1", string.Format("{0}", bE2ee ? 1 : 0), strMsgMode);
				this.msgSessionMgr.AddSession(messageSession.Id, messageSession);
				result = messageSession;
			}
			return result;
		}

		public MyMessageSession SendMessage(string remoteUri, TrunkMsgOperaterType OperaterType, string type, string content)
		{
			MyMessageSession result;
			if (remoteUri == null || remoteUri.Length == 0)
			{
				result = null;
			}
			else
			{
				if (content == null)
				{
					content = "";
				}
				string strPttHeardValue = "";
				switch (OperaterType)
				{
				case TrunkMsgOperaterType.TMT_DYNGRP:
					strPttHeardValue = "pttDGNA";
					goto IL_C3;
				case TrunkMsgOperaterType.TMT_USERKILL:
					strPttHeardValue = string.Format("pttstun;UDN={0}", remoteUri);
					goto IL_C3;
				case TrunkMsgOperaterType.TMT_USERSTUN:
					strPttHeardValue = string.Format("pttstun;UDN={0}", remoteUri);
					goto IL_C3;
				case TrunkMsgOperaterType.TMT_USERREVIVE:
					strPttHeardValue = string.Format("pttrevive;UDN={0}", remoteUri);
					goto IL_C3;
				case TrunkMsgOperaterType.TMT_QCQC:
				{
					MyAVSession sension = this.FindAVSession(remoteUri);
					if (sension != null)
					{
						strPttHeardValue = string.Format("pttdismantle;OnlineCallID={0}", sension.OnlineCallID);
					}
					goto IL_C3;
				}
				}
				result = null;
				return result;
				IL_C3:
				MyMessageSession messageSession = new MyMessageSession(this.stackService.SipStack, null, remoteUri);
				messageSession.IsOutgoing = true;
				messageSession.FromUri = this.serviceManager.ConfigurationService.IdentityCfg.Impu;
				messageSession.LocalPort = this.serviceManager.ConfigurationService.NetworkCfg.LocalPort;
				messageSession.LocalIP = this.serviceManager.ConfigurationService.NetworkCfg.LocalIP;
				messageSession.SendTextMessage(content, type, strPttHeardValue);
				this.msgSessionMgr.AddSession(messageSession.Id, messageSession);
				result = messageSession;
			}
			return result;
		}

		public MyAVSession GroupAudioCall(string groupUri)
		{
			MyAVSession avSession = this.FindAVSession(groupUri);
			MyAVSession result;
			if (avSession == null)
			{
				TrunkCallParam param = new TrunkCallParam();
				param.strCallType = string.Format("{0}", 4);
				param.strPrioAttribute = string.Format("{0}", 0);
				param.strfoaoroacsu = string.Format("{0}", 1);
				param.strduplex = string.Format("{0}", 1);
				param.stre2ee = string.Format("{0}", 1);
				param.strpriority = "255";
				param.strCalledType = string.Format("{0}", 3);
				avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, groupUri, MediaAttr.Sendonly, param);
				if (avSession == null)
				{
					result = null;
				}
				else
				{
					if (avSession != null)
					{
						this.avSessionMgr.AddSession(avSession.Id, avSession);
						this.AddContactAVSession(avSession);
					}
					result = avSession;
				}
			}
			else
			{
				this.RequestPTT(avSession.Id);
				result = null;
			}
			return result;
		}

		public MyAVSession GroupVideoCall(string groupUri, ServiceArgs args)
		{
			MyAVSession avSession = this.FindAVSession(groupUri);
			MyAVSession result;
			if (avSession == null)
			{
				TrunkCallParam param = new TrunkCallParam();
				param.strCallType = string.Format("{0}", 5);
				param.strPrioAttribute = string.Format("{0}", 0);
				param.strfoaoroacsu = string.Format("{0}", 1);
				param.strduplex = string.Format("{0}", 1);
				param.stre2ee = string.Format("{0}", 1);
				param.strpriority = "255";
				param.strCalledType = string.Format("{0}", 3);
				avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.AudioVideo, groupUri, MediaAttr.Sendonly, param);
				if (avSession == null)
				{
					result = null;
				}
				else
				{
					if (avSession != null)
					{
						this.avSessionMgr.AddSession(avSession.Id, avSession);
						this.AddContactAVSession(avSession);
					}
					result = avSession;
				}
			}
			else
			{
				this.RequestPTT(avSession.Id);
				result = null;
			}
			return result;
		}

		public MyAVSession AudioMulticastCall(string groupUri)
		{
			MyAVSession avSession = this.FindAVSession(groupUri);
			MyAVSession result;
			if (avSession == null)
			{
				TrunkCallParam param = new TrunkCallParam();
				param.strCallType = string.Format("{0}", 8);
				param.strPrioAttribute = string.Format("{0}", 0);
				param.strfoaoroacsu = string.Format("{0}", 1);
				param.strduplex = string.Format("{0}", 1);
				param.stre2ee = string.Format("{0}", 1);
				param.strpriority = "255";
				param.strCalledType = string.Format("{0}", 3);
				avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.Audio, groupUri, MediaAttr.Sendonly, param);
				if (avSession == null)
				{
					result = null;
				}
				else
				{
					if (avSession != null)
					{
						this.avSessionMgr.AddSession(avSession.Id, avSession);
						this.AddContactAVSession(avSession);
					}
					result = avSession;
				}
			}
			else
			{
				this.RequestPTT(avSession.Id);
				result = null;
			}
			return result;
		}

		public MyAVSession VideoMulticastCall(string groupUri, ServiceArgs args)
		{
			MyAVSession avSession = this.FindAVSession(groupUri);
			MyAVSession result;
			if (avSession == null)
			{
				TrunkCallParam param = new TrunkCallParam();
				param.strCallType = string.Format("{0}", 9);
				param.strPrioAttribute = string.Format("{0}", 0);
				param.strfoaoroacsu = string.Format("{0}", 1);
				param.strduplex = string.Format("{0}", 1);
				param.stre2ee = string.Format("{0}", 1);
				param.strpriority = "255";
				param.strCalledType = string.Format("{0}", 3);
				avSession = this.CreateOutgoingSession(this.stackService.SipStack, MediaType.AudioVideo, groupUri, MediaAttr.Sendonly, param);
				if (avSession == null)
				{
					result = null;
				}
				else
				{
					if (avSession != null)
					{
						this.avSessionMgr.AddSession(avSession.Id, avSession);
						this.AddContactAVSession(avSession);
					}
					result = avSession;
				}
			}
			else
			{
				this.RequestPTT(avSession.Id);
				result = null;
			}
			return result;
		}

		public void GroupVideoPushCall(string groupUri, ServiceArgs args)
		{
		}

		public void ForceInGroupCall(string remoteUri, ServiceArgs args)
		{
		}

		public void AudioMonitorGroupCall(string groupUri, ServiceArgs args)
		{
		}

		public void ConfereceCall(string strGdn, bool bVideo)
		{
			MyAVSession avSession = this.FindAVSession(strGdn);
			if (avSession == null)
			{
				MessageBox.Show("License受限!");
			}
			else
			{
				MessageBox.Show("该组会议已发起!");
			}
		}

		public bool AcceptCall(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			if (avSession != null)
			{
				avSession.AcceptCall();
			}
			return true;
		}

		public bool AcceptCall(MyAVSession avSession)
		{
			if (avSession != null)
			{
				avSession.AcceptCall();
			}
			return true;
		}

		public bool ReleaseCall(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			return avSession != null && avSession.HangUpCall(TrunkCallReleaseReason.TCRL_GEN_RESEAVE);
		}

		public bool UpdateMedia(long sessionId, MediaType newMediaType, MediaAttr mediaAttr)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			return avSession != null && avSession.Update(newMediaType, mediaAttr, null);
		}

		public string GetUserName()
		{
			return this.serviceManager.ConfigurationService.IdentityCfg.DisplayName;
		}

		private string GetPTTPayload(string strPTTType, string strPN, string strIN, string strIP, string strPort, string strAction, string strResult)
		{
			return string.Concat(new string[]
			{
				"PTT.Type:",
				strPTTType,
				"\r\nPTT.PhoneNumber:",
				strPN,
				"\r\nPTT.IncludeNumber:",
				strIN,
				"\r\nPTT.VideoIP:",
				strIP,
				"\r\nPTT.VideoPort:",
				strPort,
				"\r\nPTT.Action:",
				strAction,
				"\r\nPTT.Result:",
				strResult
			});
		}

		public bool RequestPTT(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			if (avSession != null)
			{
				ActionConfig config = new ActionConfig();
				config.addHeader("Ptt-Extension", "pttrequest");
				if (avSession != null)
				{
					avSession.UpdateMediaAttribute(avSession.MediaType, MediaAttr.Sendonly, config);
				}
				config.Dispose();
			}
			return true;
		}

		public bool ReleasePTT(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			if (avSession != null)
			{
				ActionConfig config = new ActionConfig();
				string strInfo = string.Format("{0};cause={1}", "pttreleasefloor", TrunkCallReleaseReason.TCRL_GEN_RESEAVE);
				config.addHeader("Ptt-Extension", strInfo);
				if (avSession != null)
				{
					avSession.UpdateMediaAttribute(avSession.MediaType, MediaAttr.Recvonly, config);
				}
				config.Dispose();
			}
			return true;
		}

		public bool StartVideoForward(string strResVideoId, string strVideoIdType, System.Collections.Generic.List<UserAndType> listDstUser)
		{
			bool result;
			if (strResVideoId == null || strResVideoId.Length == 0 || listDstUser == null || listDstUser.Count == 0)
			{
				MessageBox.Show("请选择用户");
				result = false;
			}
			else
			{
				string strPttHeardValue = string.Format("pttVideoForward;VideoIdType={0};VideoId={1};", strVideoIdType, strResVideoId);
				foreach (UserAndType User in listDstUser)
				{
					string text = strPttHeardValue;
					strPttHeardValue = string.Concat(new string[]
					{
						text,
						"UDN=",
						User.strUser,
						",utype=",
						User.strUserType,
						";"
					});
				}
				MyMessageSession messageSession = new MyMessageSession(this.stackService.SipStack, null, listDstUser[0].strUser);
				messageSession.IsOutgoing = true;
				messageSession.SendTextMessage("", null, strPttHeardValue);
				this.msgSessionMgr.AddSession(messageSession.Id, messageSession);
				result = true;
			}
			return result;
		}

		public bool StopVideoForward(string strResVideoId, string strVideoIdType, System.Collections.Generic.List<UserAndType> listDstUser)
		{
			bool result;
			if (strResVideoId == null || strResVideoId.Length == 0 || listDstUser == null || listDstUser.Count == 0)
			{
				MessageBox.Show("请选择用户");
				result = false;
			}
			else
			{
				string strPttHeardValue = string.Format("pttVideoTerminate;VideoIdType={0};VideoId={1};", strVideoIdType, strResVideoId);
				foreach (UserAndType User in listDstUser)
				{
					string text = strPttHeardValue;
					strPttHeardValue = string.Concat(new string[]
					{
						text,
						"UDN=",
						User.strUser,
						",utype=",
						User.strUserType,
						";"
					});
				}
				MyMessageSession messageSession = new MyMessageSession(this.stackService.SipStack, null, listDstUser[0].strUser);
				messageSession.IsOutgoing = true;
				messageSession.SendTextMessage("", null, strPttHeardValue);
				this.msgSessionMgr.AddSession(messageSession.Id, messageSession);
				result = true;
			}
			return result;
		}

		public bool CreateGroup(bool isTempGrp, string groupName, int priority, int maxPeriod, System.Collections.Generic.List<string> userList, string strGroupGDN)
		{
			bool result;
			try
			{
				if (isTempGrp || userList == null || userList.Count == 0)
				{
					result = false;
					return result;
				}
				XmlDocument doc = new XmlDocument();
				XmlNode node = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
				doc.AppendChild(node);
				XmlElement root = doc.CreateElement("pttgroupmanage");
				doc.AppendChild(root);
				XmlAttribute nodeRA = doc.CreateAttribute("action", "");
				nodeRA.Value = "create";
				root.Attributes.Append(nodeRA);
				XmlNode rootInfo = doc.CreateNode(XmlNodeType.Element, "pttdgnagrpinfo", null);
				root.AppendChild(rootInfo);
				XmlNode nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				XmlAttribute nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "GDN";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = strGroupGDN;
				nodeP.Attributes.Append(nodePAtr);
				nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "GroupName";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = groupName;
				nodeP.Attributes.Append(nodePAtr);
				nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "priority";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = string.Format("{0}", priority);
				nodeP.Attributes.Append(nodePAtr);
				XmlNode rootlist = doc.CreateNode(XmlNodeType.Element, "pttdgnagrpmbrlist", null);
				root.AppendChild(rootlist);
				XmlNode nodeRecords = this.CreateChildNode(doc, rootlist, "records", "", "count", string.Format("{0}", userList.Count));
				foreach (string strUser in userList)
				{
					XmlNode nodeRecord = this.CreateChildNode(doc, nodeRecords, "record", "", "operate", "Add");
					XmlNode nodeUDN = this.CreateChildNode(doc, nodeRecord, "UDN", strUser, "utype", "1");
					XmlNode nodePri = this.CreateChildNode(doc, nodeRecord, "TalkPriority", string.Format("{0}", priority), null, null);
				}
				System.IO.MemoryStream stream = new System.IO.MemoryStream();
				doc.Save(stream);
				string strXml = System.Text.Encoding.UTF8.GetString(stream.ToArray());
				if (strXml == null || strXml == string.Empty)
				{
					result = false;
					return result;
				}
				this.SendMessage(strGroupGDN, TrunkMsgOperaterType.TMT_DYNGRP, "application/pttdgnagrpmbrlist+xml", strXml.Trim());
			}
			catch (System.Exception ex_33E)
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public XmlNode CreateChildNode(XmlDocument doc, XmlNode PreNode, string strName, string strValue, string strAttName, string strAttValue)
		{
			XmlNode node = doc.CreateNode(XmlNodeType.Element, strName, null);
			node.InnerText = strValue;
			PreNode.AppendChild(node);
			if (strAttName != null)
			{
				XmlAttribute nodeAtr = doc.CreateAttribute(strAttName, "");
				nodeAtr.Value = strAttValue;
				node.Attributes.Append(nodeAtr);
			}
			return node;
		}

		public bool DeleteDYGroup(Group g)
		{
			bool result;
			try
			{
				if (g == null)
				{
					result = false;
					return result;
				}
				XmlDocument doc = new XmlDocument();
				XmlNode node = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
				doc.AppendChild(node);
				XmlElement root = doc.CreateElement("pttgroupmanage");
				doc.AppendChild(root);
				XmlAttribute nodeRA = doc.CreateAttribute("action", "");
				nodeRA.Value = "delete";
				root.Attributes.Append(nodeRA);
				XmlNode rootInfo = doc.CreateNode(XmlNodeType.Element, "pttdgnagrpinfo", null);
				root.AppendChild(rootInfo);
				XmlNode nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				XmlAttribute nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "GDN";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = g.GDN;
				nodeP.Attributes.Append(nodePAtr);
				nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "GroupName";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = g.Name;
				nodeP.Attributes.Append(nodePAtr);
				nodeP = doc.CreateNode(XmlNodeType.Element, "p", null);
				rootInfo.AppendChild(nodeP);
				nodePAtr = doc.CreateAttribute("t", "");
				nodePAtr.Value = "priority";
				nodeP.Attributes.Append(nodePAtr);
				nodePAtr = doc.CreateAttribute("v", "");
				nodePAtr.Value = string.Format("{0}", "");
				nodeP.Attributes.Append(nodePAtr);
				XmlNode rootlist = doc.CreateNode(XmlNodeType.Element, "pttdgnagrpmbrlist", null);
				root.AppendChild(rootlist);
				System.Collections.Generic.List<ContactItem> listUser = g.Children;
				XmlNode nodeRecords = this.CreateChildNode(doc, rootlist, "records", "", "count", string.Format("{0}", listUser.Count));
				foreach (ContactItem userCotact in listUser)
				{
					Person p = userCotact as Person;
					XmlNode nodeRecord = this.CreateChildNode(doc, nodeRecords, "record", "", "operate", "Delete");
					XmlNode nodeUDN = this.CreateChildNode(doc, nodeRecord, "UDN", p.UDN, "utype", "1");
					XmlNode nodePri = this.CreateChildNode(doc, nodeRecord, "TalkPriority", string.Format("{0}", ""), null, null);
				}
				System.IO.MemoryStream stream = new System.IO.MemoryStream();
				doc.Save(stream);
				string strXml = System.Text.Encoding.UTF8.GetString(stream.ToArray());
				if (strXml == null || strXml == string.Empty)
				{
					result = false;
					return result;
				}
				this.SendMessage(g.GDN, TrunkMsgOperaterType.TMT_DYNGRP, "application/pttdgnagrpmbrlist+xml", strXml.Trim());
			}
			catch (System.Exception ex_351)
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool DeleteGroup(Group group)
		{
			bool result;
			if (null == group)
			{
				result = false;
			}
			else
			{
				if (this.DeleteDYGroup(group))
				{
				}
				result = true;
			}
			return result;
		}

		public bool DeleteX686Group(Group p2Delete)
		{
			bool result;
			foreach (ContactItem pItem in p2Delete.Children)
			{
				Person p = pItem as Person;
				if (!this.XcapContactHandle(p.UDN, p2Delete.GDN, p2Delete.Name, 1))
				{
					result = false;
					return result;
				}
				System.Threading.Thread.Sleep(100);
			}
			string xcap_ui = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
			string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
			string xcap_root = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
			string strIdentifier = "/public-group/users/" + xcap_ui + "/" + p2Delete.Name;
			string url = xcap_root + strIdentifier;
			MyXcapMessage xcapMessage = this.stackService.DeleteDocument(url);
			result = (xcapMessage != null);
			return result;
		}

		public bool CreateX686Group(bool isTempGrp, string groupName, int priority, int maxPeriod, System.Collections.Generic.List<string> userList, string strGroupGDN)
		{
			bool result;
			if (!this.XcapGroupAdd(groupName, strGroupGDN))
			{
				result = false;
			}
			else
			{
				foreach (string strUser in userList)
				{
					this.XcapContactHandle(strUser, strGroupGDN, groupName, 0);
					System.Threading.Thread.Sleep(100);
				}
				result = true;
			}
			return result;
		}

		public bool XcapGroupAdd(string groupName, string strGroupGDN)
		{
			string xcap_ui = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
			string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
			string xcap_root = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
			string strIdentifier = "/public-group/users/" + xcap_ui + "/" + strGroupGDN;
			string url = xcap_root + strIdentifier;
			string strSuperId = "1";
			string strMax = "100";
			string strGroupLevel = "2";
			string strGroupURi = UriUtils.GetValidSipUri(strGroupGDN);
			string strPayLoad = string.Concat(new string[]
			{
				"<public-group xmlns=\"com:cmcc:public-group\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"> <list name=\"",
				groupName,
				"\" uri=\"",
				strGroupURi,
				"\" superIdx=\"",
				strSuperId,
				"\" displayName=\"",
				groupName,
				"\" max=\"",
				strMax,
				"\" groupLevel=\"",
				strGroupLevel,
				"\"></list><meta-data><creator>",
				xcap_ui,
				"</creator><identifier>",
				strIdentifier,
				"</identifier><timestamp>2015-11-01 00:00:00</timestamp><duration>3600</duration><need-permit>1</need-permit></meta-data></public-group>"
			});
			byte[] payload = System.Text.Encoding.UTF8.GetBytes(strPayLoad);
			MyXcapMessage xcapMessage = this.stackService.PutDocument(url, payload, (uint)payload.Length, "application/public-group+xml");
			return xcapMessage != null;
		}

		private bool XcapContactHandle(string strPersonUdn, string strGroupGDN, string groupName, byte byTag)
		{
			string strContactUri = UriUtils.GetValidSipUri(strPersonUdn);
			string xcap_ui = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
			string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
			string xcap_root = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
			string strGroupURi = UriUtils.GetValidSipUri(strGroupGDN);
			string url = string.Concat(new string[]
			{
				xcap_root,
				"/public-group/users/",
				xcap_ui,
				"/",
				groupName,
				"/~~/public-group/list%5b@uri=%22",
				strGroupURi,
				"%22%5d/entry%5b@uri=%22",
				strPersonUdn,
				"%22%5d "
			});
			string strPaylod = string.Concat(new string[]
			{
				"<entry uri=\"",
				strContactUri,
				"\" name=\"",
				strPersonUdn,
				"\" owner=\"false\" status=\"active\"><display-name>",
				strPersonUdn,
				"</display-name></entry>"
			});
			byte[] payload = System.Text.Encoding.UTF8.GetBytes(strPaylod);
			MyXcapMessage xcapMessage = this.stackService.PutElement(url, payload, (uint)payload.Length);
			return xcapMessage != null;
		}

		public bool RefreshLocalVideo(long sessionId)
		{
			MyAVSession avSession = this.FindAVSession(sessionId);
			bool result;
			if (avSession != null)
			{
				avSession.MediaSessionMgr.codecSetInt32(twrap_media_type_t.twrap_media_video, "action", 0);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
