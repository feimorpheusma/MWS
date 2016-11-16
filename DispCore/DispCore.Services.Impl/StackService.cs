using DispCore.Events;
using DispCore.Events.Sip;
using DispCore.Models;
using DispCore.Models.Cfg;
using DispCore.Models.Rls.resource_lists;
using DispCore.Models.Trunk;
using DispCore.Types;
using DispCore.Types.Trunk;
using DispCore.Utils;
using DispCore.Utils.Trunk;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Services.Impl
{
	public class StackService : IStackService, IService
	{
		internal class MySipCallback : SipCallback
		{
			private readonly StackService stackService;

			private ServiceManager serviceManager;

			internal MySipCallback(ServiceManager manager, StackService stackService)
			{
				this.serviceManager = manager;
				this.stackService = stackService;
			}

			public override int OnRegistrationEvent(RegistrationEvent e)
			{
				return 0;
			}

			public override int OnPublicationEvent(PublicationEvent e)
			{
				return 0;
			}

			public override int OnInfoEvent(InfoEvent e)
			{
				int result;
				switch (e.getType())
				{
				case tsip_info_event_type_t.tsip_i_info:
				{
					SipMessage message = e.getSipMessage();
					InfoSession session = e.getSession();
					if (session == null)
					{
						session = e.takeSessionOwnership();
					}
					if (session == null)
					{
						StackService.LOG.Error("Failed to take session ownership");
					}
					if (message == null)
					{
						StackService.LOG.Error("Invalid message");
						session.reject();
						session.Dispose();
						result = 0;
						return result;
					}
					string from = message.getSipHeaderValue("f");
					string contentType = message.getSipHeaderValue("c");
					byte[] bytes = message.getSipContent();
					string strHeard = message.getSipHeaderValue("Ptt-Extension");
					string strAlertType = TrunkUitls.GetPTTExtension(strHeard, "Alerttype");
					string strUdn = TrunkUitls.GetPTTExtension(strHeard, "UDN");
					PttEventArgs args = new PttEventArgs(PttEventTypes.PTT_INFO, (long)((ulong)session.getId()), e.getPhrase(), bytes);
					args.AddExtra("Alerttype", strAlertType);
					args.AddExtra("Alerttype", strUdn);
					args.AddExtra("callid", message.getSipHeaderValue("Call-ID"));
					args.AddExtra("content-Type", (contentType == null) ? "unknown/unknown" : contentType);
					args.FromUri = from;
					EventHandlerTrigger.TriggerEvent<PttEventArgs>(this.stackService.onPttEvent, this.stackService, args);
					session.accept();
					session.Dispose();
					break;
				}
				}
				result = 0;
				return result;
			}

			public override int OnMessagingEvent(MessagingEvent e)
			{
				tsip_message_event_type_t type = e.getType();
				SipMessage message = e.getSipMessage();
				MessagingSession session = e.getSession();
				int result;
				switch (type)
				{
				case tsip_message_event_type_t.tsip_i_message:
				{
					if (session == null)
					{
						session = e.takeSessionOwnership();
					}
					if (session == null)
					{
						StackService.LOG.Error("Failed to take session ownership");
					}
					if (message == null)
					{
						StackService.LOG.Error("Invalid message");
						session.reject();
						session.Dispose();
						result = 0;
						return result;
					}
					uint sessionId = session.getId();
					string from = message.getSipHeaderValue("f");
					string contentType = message.getSipHeaderValue("c");
					byte[] content = message.getSipContent();
					string extension = message.getSipHeaderValue("Ptt-Extension");
					string strRemoteSender = message.getSipHeaderValue("P-Asserted-Identity");
					if (extension != null && extension.Contains("pttmsg"))
					{
						if (content != null)
						{
							MessageEventArgs eargs = new MessageEventArgs((long)((ulong)sessionId), MessageEventTypes.INCOMING, e.getPhrase(), content);
							eargs.AddExtra("code", e.getCode()).AddExtra("from", from).AddExtra("content-Type", (contentType == null) ? "unknown/unknown" : contentType).AddExtra("session", session).AddExtra("PPI", strRemoteSender);
							EventHandlerTrigger.TriggerEvent<MessageEventArgs>(this.stackService.onMessageEvent, this.stackService, eargs);
						}
					}
					else if (extension != null && extension.Contains("reDGNA"))
					{
						string strDgnResult = TrunkUitls.GetPTTExtension(extension, "DGNAresult");
						string strUdn = TrunkUitls.GetPTTExtension(extension, "UDN");
						DgnaEventArgs eargs2 = new DgnaEventArgs(DgnaEventTypes.DGNA_REPORT, e.getPhrase(), content);
						eargs2.AddExtra("UDN", strUdn).AddExtra("from", from).AddExtra("content-Type", (contentType == null) ? "unknown/unknown" : contentType).AddExtra("DGNAresult", strDgnResult);
						EventHandlerTrigger.TriggerEvent<DgnaEventArgs>(this.stackService.onDgnaEvent, this.stackService, eargs2);
					}
					else if (extension != null && extension.Contains("pttVideoForwardReport"))
					{
						string strUdn = TrunkUitls.GetPTTExtension(extension, "UDN");
						VideoSendEventArgs eargs3 = new VideoSendEventArgs(VideoSendEventTypes.VIDEOSEND_REPORT);
						eargs3.AddExtra("UDN", strUdn).AddExtra("pttVideoForwardReport", extension);
						EventHandlerTrigger.TriggerEvent<VideoSendEventArgs>(this.stackService.onVideoSendEvent, this.stackService, eargs3);
					}
					else if (extension != null && extension.Contains("pttpushaddrlist"))
					{
						AddressListEventArgs eargs4 = new AddressListEventArgs(AddressListEventTypes.ADDRESS_PUSH, message.getSipHeaderValue("c"), message.getSipContent());
						EventHandlerTrigger.TriggerEvent<AddressListEventArgs>(this.stackService.onAddressListEvent, this.stackService, eargs4);
					}
					else if (content != null)
					{
						MessageEventArgs eargs = new MessageEventArgs((long)((ulong)sessionId), MessageEventTypes.INCOMING, e.getPhrase(), content);
						eargs.AddExtra("code", e.getCode()).AddExtra("from", from).AddExtra("content-Type", (contentType == null) ? "unknown/unknown" : contentType).AddExtra("session", session);
						EventHandlerTrigger.TriggerEvent<MessageEventArgs>(this.stackService.onMessageEvent, this.stackService, eargs);
					}
					session.accept();
					session.Dispose();
					break;
				}
				case tsip_message_event_type_t.tsip_ao_message:
				{
					if (session == null || message == null)
					{
						StackService.LOG.Error("Failed to take session ownership");
						result = -1;
						return result;
					}
					short sipCode = message.getResponseCode();
					uint sessionId = session.getId();
					if (sipCode > 199 && sipCode < 300)
					{
						MessageEventArgs eargs = new MessageEventArgs((long)((ulong)sessionId), MessageEventTypes.SUCCESS, e.getPhrase(), null);
						EventHandlerTrigger.TriggerEvent<MessageEventArgs>(this.stackService.onMessageEvent, this.stackService, eargs);
					}
					else if (sipCode >= 300)
					{
						MessageEventArgs eargs = new MessageEventArgs((long)((ulong)sessionId), MessageEventTypes.FAILURE, e.getPhrase(), null);
						EventHandlerTrigger.TriggerEvent<MessageEventArgs>(this.stackService.onMessageEvent, this.stackService, eargs);
					}
					break;
				}
				}
				result = 0;
				return result;
			}

			public override int OnSubscriptionEvent(SubscriptionEvent e)
			{
				int result;
				switch (e.getType())
				{
				case tsip_subscribe_event_type_t.tsip_i_notify:
				{
					SubscriptionSession session = e.getSession();
					SipMessage message = e.getSipMessage();
					if (message == null)
					{
						StackService.LOG.Error("Null message");
						result = -1;
						return result;
					}
					string from = message.getSipHeaderValue("f");
					string contentType = message.getSipHeaderValue("c");
					byte[] content = message.getSipContent();
					if (string.IsNullOrEmpty(contentType) || content == null)
					{
						StackService.LOG.Error("Invalid content");
						result = -1;
						return result;
					}
					short code = e.getCode();
					string phrase = e.getPhrase();
					if (session != null)
					{
						SubscriptionEventArgs eargs = new SubscriptionEventArgs(SubscriptionEventTypes.INCOMING_NOTIFY, (long)((ulong)session.getId()), code, phrase, content, contentType, from);
						string ctype = message.getSipHeaderParamValue("c", "type");
						eargs.AddExtra("ContentTypeType", (ctype == null) ? string.Empty : ctype.Replace("\"", string.Empty));
						string start = message.getSipHeaderParamValue("c", "start");
						eargs.AddExtra("ContentTypeStart", (start == null) ? string.Empty : start.Replace("\"", string.Empty));
						string boundary = message.getSipHeaderParamValue("c", "boundary");
						eargs.AddExtra("ContentTypeBoundary", (boundary == null) ? string.Empty : boundary.Replace("\"", string.Empty));
						EventHandlerTrigger.TriggerEvent<SubscriptionEventArgs>(this.stackService.onSubscriptionEvent, this.stackService, eargs);
					}
					break;
				}
				}
				result = 0;
				return result;
			}

			public override int OnDialogEvent(DialogEvent e)
			{
				string phrase = e.getPhrase();
				short code = e.getCode();
				SipSession session = e.getBaseSession();
				SipMessage message = e.getSipMessage();
				int result;
				if (session == null)
				{
					StackService.LOG.Info(string.Format("OnDialogEvent ({0}) with Null session", phrase));
					result = 0;
				}
				else
				{
					uint sessionId = session.getId();
					short sipCode = (message != null && message.isResponse()) ? message.getResponseCode() : code;
					StackService.LOG.Info(string.Format("OnDialogEvent ({0})", phrase));
					if ((int)code == tinyWRAP.tsip_event_code_dialog_connecting)
					{
						if (this.serviceManager.AccessNetworkService.RegSession != null && this.serviceManager.AccessNetworkService.RegSession.Id == (long)((ulong)sessionId))
						{
							EventHandlerTrigger.TriggerEvent<RegistrationEventArgs>(this.stackService.onRegistrationEvent, this.stackService, new RegistrationEventArgs(RegistrationEventTypes.REGISTRATION_INPROGRESS, code, phrase));
						}
						else if (this.serviceManager.ServiceRealizeService.FindAVSession((long)((ulong)sessionId)) != null)
						{
							CallEventArgs eargs = new CallEventArgs(CallEventTypes.CALL_INPROGRESS, (long)((ulong)sessionId), phrase);
							eargs.AddExtra("code", code);
							EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, eargs);
						}
					}
					else if ((int)code == tinyWRAP.tsip_event_code_dialog_connected)
					{
						if (this.serviceManager.AccessNetworkService.RegSession != null && this.serviceManager.AccessNetworkService.RegSession.Id == (long)((ulong)sessionId))
						{
							this.serviceManager.AccessNetworkService.RegSession.IsConnected = true;
							string _defaultIdentity = this.stackService.SipStack.WrappedStack.getPreferredIdentity();
							if (!string.IsNullOrEmpty(_defaultIdentity))
							{
								this.serviceManager.StatusService.defaultIdentity = _defaultIdentity;
							}
							EventHandlerTrigger.TriggerEvent<RegistrationEventArgs>(this.stackService.onRegistrationEvent, this.stackService, new RegistrationEventArgs(RegistrationEventTypes.REGISTRATION_OK, code, phrase));
						}
						else if (this.serviceManager.ServiceRealizeService.FindAVSession((long)((ulong)sessionId)) != null)
						{
							EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_CONNECTED, (long)((ulong)sessionId), phrase));
						}
					}
					else if ((int)code == tinyWRAP.tsip_event_code_dialog_terminating)
					{
						if (this.serviceManager.AccessNetworkService.RegSession != null && this.serviceManager.AccessNetworkService.RegSession.Id == (long)((ulong)sessionId))
						{
							StackService.LOG.Info("OnDialogEvent (Unregistering)");
							EventHandlerTrigger.TriggerEvent<RegistrationEventArgs>(this.stackService.onRegistrationEvent, this.stackService, new RegistrationEventArgs(RegistrationEventTypes.UNREGISTRATION_INPROGRESS, code, phrase));
						}
						else if (this.serviceManager.ServiceRealizeService.FindAVSession((long)((ulong)sessionId)) != null)
						{
							EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_TERMWAIT, (long)((ulong)sessionId), phrase));
						}
					}
					else if ((int)code == tinyWRAP.tsip_event_code_dialog_terminated)
					{
						if (this.serviceManager.AccessNetworkService.RegSession != null && this.serviceManager.AccessNetworkService.RegSession.Id == (long)((ulong)sessionId))
						{
							StackService.LOG.Info("OnDialogEvent (Unregistered)");
							EventHandlerTrigger.TriggerEvent<RegistrationEventArgs>(this.stackService.onRegistrationEvent, this.stackService, new RegistrationEventArgs(RegistrationEventTypes.UNREGISTRATION_OK, code, phrase));
						}
						else if (this.serviceManager.ServiceRealizeService.FindAVSession((long)((ulong)sessionId)) != null)
						{
							CallEventArgs eargs = new CallEventArgs(CallEventTypes.CALL_DISCONNECTED, (long)((ulong)sessionId), phrase);
							eargs.AddExtra("code", sipCode);
							EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, eargs);
						}
					}
					result = 0;
				}
				return result;
			}

			public override int OnStackEvent(StackEvent e)
			{
				short code = e.getCode();
				string phrase = e.getPhrase();
				StackService.LOG.Info(string.Format("OnStackEvent ({0})", phrase));
				if ((int)code == tinyWRAP.tsip_event_code_stack_started)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.STARTED;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.START_OK, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_starting)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.STARTING;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.STARING, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_failed_to_start)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.STOPPED;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.START_NOK, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_failed_to_stop)
				{
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.STOP_NOK, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_stopping)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.STOPPING;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.STOPPING, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_stopped)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.STOPPED;
						this.stackService.sipStackStarted = false;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.STOP_OK, phrase));
				}
				else if ((int)code == tinyWRAP.tsip_event_code_stack_disconnected)
				{
					if (this.stackService.SipStack != null)
					{
						this.stackService.SipStack.State = MySipStack.STACK_STATE.DISCONNECTED;
					}
					EventHandlerTrigger.TriggerEvent<StackEventArgs>(this.stackService.onStackEvent, this.stackService, new StackEventArgs(StackEventTypes.DISCONNECTED, phrase));
				}
				return 0;
			}

			public override int OnInviteEvent(InviteEvent e)
			{
				tsip_invite_event_type_t type = e.getType();
				short code = e.getCode();
				string phrase = e.getPhrase();
				InviteSession session = e.getSession();
				int result;
				switch (type)
				{
				case tsip_invite_event_type_t.tsip_i_newcall:
				case tsip_invite_event_type_t.tsip_i_ect_newcall:
				{
					if (session != null)
					{
						StackService.LOG.Error("Invalid incoming session");
						session.hangup(null);
						result = -1;
						return result;
					}
					SipMessage message = e.getSipMessage();
					if (message == null)
					{
						StackService.LOG.Error("Invalid message");
						result = -1;
						return result;
					}
					twrap_media_type_t sessionType = e.getMediaType();
					string extension = message.getSipHeaderValue("Ptt-Extension");
					switch (sessionType)
					{
					case twrap_media_type_t.twrap_media_audio:
					case twrap_media_type_t.twrap_media_video:
					case twrap_media_type_t.twrap_media_audiovideo:
					case twrap_media_type_t.twrap_media_t140:
					case (twrap_media_type_t)9:
					case (twrap_media_type_t)11:
						if ((session = e.takeCallSessionOwnership()) == null)
						{
							StackService.LOG.Error("Failed to take audio/video session ownership");
							result = -1;
							return result;
						}
						if (type == tsip_invite_event_type_t.tsip_i_newcall)
						{
							CallEventArgs eargs = new CallEventArgs(CallEventTypes.CALL_INCOMING, (long)((ulong)session.getId()), phrase);
							eargs.AddExtra("calltype", TrunkUitls.GetPTTExtension(extension, "calltype")).AddExtra("callattribute", TrunkUitls.GetPTTExtension(extension, "PrioAttribute")).AddExtra("e2ee", TrunkUitls.GetPTTExtension(extension, "e2ee")).AddExtra("duplex", TrunkUitls.GetPTTExtension(extension, "duplex")).AddExtra("foaoroacsu", TrunkUitls.GetPTTExtension(extension, "foaoroacsu")).AddExtra("sessiontype", sessionType).AddExtra("sipemessage", message).AddExtra("session", session);
							EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, eargs);
						}
						goto IL_30A;
					case twrap_media_type_t.twrap_media_msrp:
					{
						if ((session = e.takeMsrpSessionOwnership()) == null)
						{
							StackService.LOG.Error("Failed to take MSRP session ownership");
							result = -1;
							return result;
						}
						MyMsrpSession msrpSession = MyMsrpSession.TakeIncomingSession(this.stackService.SipStack, session as MsrpSession, message);
						if (msrpSession == null)
						{
							StackService.LOG.Error("Failed to create new session");
							session.hangup(null);
							((System.IDisposable)session).Dispose();
							result = 0;
							return result;
						}
						CallEventArgs eargs = new CallEventArgs(CallEventTypes.CALL_INCOMING, msrpSession.Id, phrase);
						eargs.AddExtra("session", msrpSession);
						EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, eargs);
						goto IL_30A;
					}
					}
					StackService.LOG.Error("Invalid media type");
					result = 0;
					return result;
					IL_30A:
					break;
				}
				case tsip_invite_event_type_t.tsip_i_request:
				{
					SipMessage message = e.getSipMessage();
					if (message != null)
					{
						if (message.getRequestType() == tsip_request_type_t.tsip_INFO)
						{
							string extension = message.getSipHeaderValue("Ptt-Extension");
							string from = message.getSipHeaderValue("f");
							string contentType = message.getSipHeaderValue("c");
							byte[] bytes = message.getSipContent();
							PttEventArgs args = new PttEventArgs(PttEventTypes.PTT_INFO, (long)((ulong)session.getId()), e.getPhrase(), bytes);
							args.AddExtra("Alerttype", TrunkUitls.GetPTTExtension(extension, "Alerttype"));
							args.AddExtra("UDN", TrunkUitls.GetPTTExtension(extension, "UDN"));
							args.AddExtra("callid", message.getSipHeaderValue("Call-ID"));
							args.AddExtra("content-Type", (contentType == null) ? "unknown/unknown" : contentType);
							args.FromUri = from;
							EventHandlerTrigger.TriggerEvent<PttEventArgs>(this.stackService.onPttEvent, this.stackService, args);
						}
						else if (message.getRequestType() == tsip_request_type_t.tsip_INVITE)
						{
							string extension = message.getSipHeaderValue("Ptt-Extension");
							byte[] bytes = message.getSipContent();
							if (extension == "pttaccept")
							{
								PttEventArgs eargs2 = new PttEventArgs(PttEventTypes.PTT_ACCEPT, (long)((ulong)session.getId()), e.getPhrase(), bytes);
								EventHandlerTrigger.TriggerEvent<PttEventArgs>(this.stackService.onPttEvent, this.stackService, eargs2);
							}
							else if (extension == "pttreleasefloor")
							{
								PttEventArgs eargs2 = new PttEventArgs(PttEventTypes.PTT_RELEASE, (long)((ulong)session.getId()), e.getPhrase(), bytes);
								EventHandlerTrigger.TriggerEvent<PttEventArgs>(this.stackService.onPttEvent, this.stackService, eargs2);
							}
							else if (extension == "pttwaiting")
							{
								PttEventArgs eargs2 = new PttEventArgs(PttEventTypes.PTT_WAITING, (long)((ulong)session.getId()), e.getPhrase(), bytes);
								EventHandlerTrigger.TriggerEvent<PttEventArgs>(this.stackService.onPttEvent, this.stackService, eargs2);
							}
						}
					}
					break;
				}
				case tsip_invite_event_type_t.tsip_ao_request:
				{
					SipMessage message = e.getSipMessage();
					if (message == null)
					{
						StackService.LOG.Error("Invalid message");
						result = -1;
						return result;
					}
					string extension = message.getSipHeaderValue("Ptt-Extension");
					if (code == 180 && session != null)
					{
						EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_RINGING, (long)((ulong)session.getId()), phrase));
					}
					break;
				}
				case tsip_invite_event_type_t.tsip_m_early_media:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_EARLY_MEDIA, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_updating:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_MEDIA_UPDATING, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_updated:
				{
					CallEventArgs eargs = new CallEventArgs(CallEventTypes.CALL_MEDIA_UPDATED, (long)((ulong)session.getId()), phrase);
					eargs.AddExtra("orignevent", e);
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, eargs);
					break;
				}
				case tsip_invite_event_type_t.tsip_m_local_hold_ok:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_LOCAL_HOLD_OK, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_local_hold_nok:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_LOCAL_HOLD_NOK, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_local_resume_ok:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_LOCAL_RESUME_OK, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_local_resume_nok:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_LOCAL_RESUME_NOK, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_remote_hold:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_REMOTE_HOLD, (long)((ulong)session.getId()), phrase));
					break;
				case tsip_invite_event_type_t.tsip_m_remote_resume:
					EventHandlerTrigger.TriggerEvent<CallEventArgs>(this.stackService.onCallEvent, this.stackService, new CallEventArgs(CallEventTypes.CALL_REMOTE_RESUME, (long)((ulong)session.getId()), phrase));
					break;
				}
				result = 0;
				return result;
			}

			public override int OnOptionsEvent(OptionsEvent e)
			{
				tsip_options_event_type_t type = e.getType();
				OptionsSession ptSession = e.getSession();
				SipMessage message = e.getSipMessage();
				switch (type)
				{
				case tsip_options_event_type_t.tsip_i_options:
					if (ptSession == null)
					{
						if ((ptSession = e.takeSessionOwnership()) != null)
						{
							string extension = message.getSipHeaderValue("Ptt-Extension");
							if (extension == "pttkickoff")
							{
								RegistrationEventArgs eargs = new RegistrationEventArgs(RegistrationEventTypes.NETWORK_KICKOFF, e.getCode(), e.getPhrase());
								eargs.AddExtra("cause", TrunkUitls.GetPTTExtension(extension, "Cause")).AddExtra("kickedip", TrunkUitls.GetPTTExtension(extension, "KickedIP"));
								EventHandlerTrigger.TriggerEvent<RegistrationEventArgs>(this.stackService.onRegistrationEvent, this.stackService, eargs);
							}
							ActionConfig config = new ActionConfig();
							config.addHeader("Allow", "PRACK, INVITE, ACK, BYE, CANCEL, UPDATE, SUBSCRIBE, NOTIFY, REFER, MESSAGE, OPTIONS");
							ptSession.accept(config);
							ptSession.Dispose();
							config.Dispose();
						}
					}
					break;
				case tsip_options_event_type_t.tsip_ao_options:
					if (e.takeSessionOwnership() != null)
					{
						string extension = message.getSipHeaderValue("Ptt-Extension");
						if (extension == "pttheartbeat")
						{
							HeartbeartEventArgs eargs2 = new HeartbeartEventArgs(HeartbeatEventTypes.HEARTBEAT_RESPONSE, (long)e.getCode(), e.getPhrase());
							EventHandlerTrigger.TriggerEvent<HeartbeartEventArgs>(this.stackService.onHeartbeatEvent, this.stackService, eargs2);
						}
					}
					break;
				}
				return 0;
			}
		}

		internal class MySipDebugCallback : DDebugCallback
		{
			internal MySipDebugCallback()
			{
			}

			public override int OnDebugInfo(string message)
			{
				StackService.LOG.Info(message);
				return 0;
			}

			public override int OnDebugWarn(string message)
			{
				StackService.LOG.Warn(message);
				return 0;
			}

			public override int OnDebugError(string message)
			{
				StackService.LOG.Error(message);
				return 0;
			}

			public override int OnDebugFatal(string message)
			{
				StackService.LOG.Fatal(message);
				return 0;
			}
		}

		private MySipStack sipStack;

		private bool sipStackStarted = false;

		private MySipStack.Preferences sipPreferences;

		private StackService.MySipCallback sipCallback;

		private StackService.MySipDebugCallback sipDebugCallback;

		private MyXcapStack xcapStack;

		private bool prepared;

		private bool bOMADirectory;

		private bool bResourceLists;

		private bool bRLS;

		private bool bPresRules;

		private bool bOMAPresRules;

		private bool bOMAPresenceContent;

		private string strRlsPresUri;

		private string strAvatar;

		private bool bReady;

		private XcapSelector xcapSelector;

		private Semaphore synchronizer;

		private System.Collections.Generic.IDictionary<string, string> xcapDocumentsUris;

		private XcapCallback callback;

		private static readonly ILog LOG = LogManager.GetLogger(typeof(StackService));

		private ServiceManager serviceManager;

		private System.Collections.Generic.List<TrunkOnlineCallService> onlineCallStatus;

		public event System.EventHandler<StackEventArgs> onStackEvent;

		public event System.EventHandler<HeartbeartEventArgs> onHeartbeatEvent;

		public event System.EventHandler<RegistrationEventArgs> onRegistrationEvent;

		public event System.EventHandler<SubscriptionEventArgs> onSubscriptionEvent;

		public event System.EventHandler<MessageEventArgs> onMessageEvent;

		public event System.EventHandler<DgnaEventArgs> onDgnaEvent;

		public event System.EventHandler<VideoSendEventArgs> onVideoSendEvent;

		public event System.EventHandler<AddressListEventArgs> onAddressListEvent;

		public event System.EventHandler<CallEventArgs> onCallEvent;

		public event System.EventHandler<PttEventArgs> onPttEvent;

		public event System.EventHandler<XcapEventArgs> onXcapEvent;

		public bool SipStackStarted
		{
			get
			{
				return this.sipStackStarted;
			}
		}

		public MySipStack SipStack
		{
			get
			{
				return this.sipStack;
			}
		}

		internal int Timeout
		{
			get
			{
				int result;
				if (this.xcapStack == null)
				{
					string strTimeOut = this.serviceManager.ConfigurationService.ContactsCfg.XcapTimeout;
					result = 6000;
				}
				else
				{
					result = this.xcapStack.Timeout;
				}
				return result;
			}
		}

		internal Semaphore Synchronizer
		{
			get
			{
				return this.synchronizer;
			}
		}

		public MyXcapStack XCapStack
		{
			get
			{
				return this.xcapStack;
			}
		}

		public System.Collections.Generic.List<TrunkOnlineCallService> OnlineCallStatus
		{
			get
			{
				return this.onlineCallStatus;
			}
			set
			{
				this.onlineCallStatus = value;
			}
		}

		private bool LoadSipStackCfg()
		{
			this.sipPreferences.realm = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.REALM, Configuration.DEFAULT_NETWORK_REALM);
			this.sipPreferences.impi = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPI, Configuration.DEFAULT_IDENTITY_IMPI);
			this.sipPreferences.impu = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.IMPU, Configuration.DEFAULT_IDENTITY_IMPU);
			this.sipPreferences.password = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.IDENTITY, Configuration.ConfEntry.PASSWORD, Configuration.DEFAULT_IDENTITY_PASSWORD);
			this.sipPreferences.local_ip = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_IP, Configuration.DEFAULT_NETWORK_LOCAL_IP);
			this.sipPreferences.local_port = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.LOCAL_PORT, Configuration.DEFAULT_NETWORK_LOCAL_PORT);
			tmedia_srtp_type_t srtpType = (tmedia_srtp_type_t)System.Enum.Parse(typeof(tmedia_srtp_type_t), this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.SRTP_TYPE, Configuration.DEFAULT_SECURITY_SRTP_TYPE), true);
			this.sipPreferences.dtls_srtp = ((srtpType & tmedia_srtp_type_t.tmedia_srtp_type_dtls) == tmedia_srtp_type_t.tmedia_srtp_type_dtls);
			this.sipPreferences.pcscf_host = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_HOST, StringUtils.nullptr);
			this.sipPreferences.pcscf_port = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_PORT, Configuration.DEFAULT_NETWORK_PCSCF_PORT);
			this.sipPreferences.transport = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.TRANSPORT, Configuration.DEFAULT_NETWORK_TRANSPORT);
			this.sipPreferences.ipversion = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.IP_VERSION, Configuration.DEFAULT_NETWORK_IP_VERSION);
			this.sipPreferences.akaAmf = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IMSAKA_AMF, Configuration.DEFAULT_IMSAKA_AMF);
			this.sipPreferences.akaOpID = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IMSAKA_OPID, Configuration.DEFAULT_IMSAKA_OPID);
			this.sipPreferences.nattUseStun = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NATT, Configuration.ConfEntry.USE_STUN_FOR_SIP, Configuration.DEFAULT_NATT_USE_STUN_FOR_SIP);
			this.sipPreferences.nattStunDisc = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NATT, Configuration.ConfEntry.STUN_DISCO, Configuration.DEFAULT_NATT_STUN_DISCO);
			this.sipPreferences.stunServer = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NATT, Configuration.ConfEntry.STUN_SERVER, Configuration.DEFAULT_NATT_STUN_SERVER);
			this.sipPreferences.stunPort = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NATT, Configuration.ConfEntry.STUN_PORT, Configuration.DEFAULT_NATT_STUN_PORT);
			this.sipPreferences.dnsDiscovery = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.PCSCF_DISCOVERY_DNS, Configuration.DEFAULT_NETWORK_PCSCF_DISCOVERY_DNS);
			this.sipPreferences.earlyIms = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.EARLY_IMS, Configuration.DEFAULT_NETWORK_EARLY_IMS);
			this.sipPreferences.enableSigComp = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.NETWORK, Configuration.ConfEntry.SIGCOMP, Configuration.DEFAULT_NETWORK_SIGCOMP);
			this.sipPreferences.ipsec_secagree = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IPSEC_SEC_AGREE, Configuration.DEFAULT_SECURITY_IPSEC_SEC_AGREE);
			this.sipPreferences.algo = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IPSEC_ALGO, Configuration.DEFAULT_SECURITY_IPSEC_ALGO);
			this.sipPreferences.ealgo = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IPSEC_EALGO, Configuration.DEFAULT_SECURITY_IPSEC_EALGO);
			this.sipPreferences.mode = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IPSEC_MODE, Configuration.DEFAULT_SECURITY_IPSEC_MODE);
			this.sipPreferences.proto = this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.SECURITY, Configuration.ConfEntry.IPSEC_PROTO, Configuration.DEFAULT_SECURITY_IPSEC_PROTO);
			this.sipPreferences.codec = (long)this.serviceManager.ConfigurationService.Get(Configuration.ConfFolder.MEDIA, Configuration.ConfEntry.CODECS, Configuration.DEFAULT_MEDIA_CODECS);
			return true;
		}

		public bool StartSipStack()
		{
			this.LoadSipStackCfg();
			if (this.sipDebugCallback == null)
			{
				this.sipDebugCallback = new StackService.MySipDebugCallback();
			}
			if (this.sipCallback == null)
			{
				this.sipCallback = new StackService.MySipCallback(this.serviceManager, this);
			}
			if (this.sipStack == null)
			{
				this.sipStack = new MySipStack(this.sipCallback, this.sipPreferences);
				this.sipStack.WrappedStack.setDebugCallback(this.sipDebugCallback);
			}
			else
			{
				this.sipStack.SetPreferences(this.sipPreferences);
			}
			bool result;
			if (this.sipStack.WrappedStack.start())
			{
				this.sipStackStarted = true;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public bool SipStackCfg()
		{
			this.LoadSipStackCfg();
			if (this.SipStack != null)
			{
				this.SipStack.SetPreferences();
			}
			return true;
		}

		public bool StopSipStack()
		{
			return this.sipStack == null || !this.sipStackStarted || this.sipStack.WrappedStack.stop();
		}

		public bool ConfigXcapStack()
		{
			this.callback = new MySyncXcapCallback(this);
			this.xcapDocumentsUris = new System.Collections.Generic.Dictionary<string, string>();
			return true;
		}

		public bool StartXcapStack()
		{
			this.bReady = false;
			this.synchronizer = new Semaphore(0, 1);
			return true;
		}

		public bool StopXcapStack()
		{
			this.bReady = false;
			this.callback.Dispose();
			this.xcapDocumentsUris.Clear();
			if (this.synchronizer != null)
			{
				this.synchronizer.Close();
				this.synchronizer = null;
			}
			return true;
		}

		public bool XcapPrepare()
		{
			bool result;
			if (this.prepared)
			{
				StackService.LOG.Debug("XCAP service already prepared");
				result = true;
			}
			else
			{
				string xcap_ui = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
				string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
				string xcap_root = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
				string strXcapTimeout = this.serviceManager.ConfigurationService.ContactsCfg.XcapTimeout;
				int xcap_timeout = 6000;
				if (this.xcapStack == null)
				{
					this.xcapStack = new MyXcapStack(this.callback, xcap_ui, xcap_password, xcap_root, xcap_timeout);
					this.xcapSelector = new XcapSelector(this.xcapStack.Stack);
				}
				else if (!this.xcapStack.Configure(xcap_ui, xcap_password, xcap_root, xcap_timeout))
				{
					StackService.LOG.Error("Failed to configure the XCAP stack");
					result = false;
					return result;
				}
				if (this.prepared = this.xcapStack.Start())
				{
					this.xcapStack.AddHeader("Connection", "Close");
					this.xcapStack.AddHeader("User-Agent", "XDM-client/OMA1.0");
					this.xcapStack.AddHeader("X-3GPP-Intended-Identity", this.xcapStack.XUI);
				}
				else
				{
					StackService.LOG.Error("Failed to start XCAP Stack");
					MessageBox.Show("启动XCAP协议栈失败!");
				}
				result = this.prepared;
			}
			return result;
		}

		public bool XcapUnPrepare()
		{
			bool result;
			if (!this.prepared)
			{
				StackService.LOG.Warn("XCAP service not prepared");
				result = true;
			}
			else
			{
				this.xcapDocumentsUris.Clear();
				if (this.xcapStack.Stop())
				{
					this.prepared = false;
				}
				else
				{
					StackService.LOG.Error("Failed to stop the XCAP stack");
				}
				result = !this.prepared;
			}
			return result;
		}

		public bool XcapIsReady()
		{
			return this.bReady;
		}

		public MyXcapMessage GetDocument(string url)
		{
			return this.xcapStack.GetDocument(url);
		}

		public bool DownloadDocuments()
		{
			bool result;
			if (!this.prepared)
			{
				StackService.LOG.Error("XCAP sevice not prepared");
				result = false;
			}
			else
			{
				this.bReady = false;
				this.xcapDocumentsUris.Clear();
				this.strRlsPresUri = null;
				string xcap_uri = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
				string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
				string strXcapRoot = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
				lock (this.xcapSelector)
				{
					lock (this.xcapSelector)
					{
						this.xcapSelector.reset();
						this.xcapSelector.setAUID("org.openmobilealliance.group - usage - list");
						string xcapCapsUrl = this.xcapSelector.getString();
					}
					if (this.xcapStack.IsRunning)
					{
						string xcapCapsUrl = strXcapRoot + "/org.openmobilealliance.group-usage-list/users/" + xcap_uri + "/index";
						MyXcapMessage xcapMessage = this.xcapStack.GetDocument(xcapCapsUrl);
						if (xcapMessage != null)
						{
							if (!this.HandleResourceListsEvent(xcapMessage.Code, xcapMessage.Content))
							{
								StackService.LOG.Error("Failed to handle 'resource-lists' document");
							}
						}
						else
						{
							StackService.LOG.Error("Failed to get 'org.openmobilealliance.pres-content' document");
						}
					}
					else
					{
						StackService.LOG.Warn("XCAP Stack not running");
					}
				}
				this.bReady = true;
				result = true;
			}
			return result;
		}

		private bool HandleResourceListsEvent(short code, byte[] content)
		{
			bool result;
			try
			{
				if (StackService.IsSuccessCode(code))
				{
					resourcelists rlist = this.Deserialize(content, typeof(resourcelists)) as resourcelists;
					if (rlist == null || rlist.list == null)
					{
						result = false;
						return result;
					}
					result = this.FromResouceListToContacts(rlist);
					return result;
				}
				else if (code == 404)
				{
				}
			}
			catch (System.Exception e)
			{
				StackService.LOG.Error("Failed to handle 'resource-lists' event", e);
				result = false;
				return result;
			}
			result = false;
			return result;
		}

		private object Deserialize(byte[] content, System.Type type)
		{
			object result = null;
			if (content != null)
			{
				XmlReaderSettings settings = new XmlReaderSettings();
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream(content))
				{
					using (XmlReader reader = XmlReader.Create(stream, settings))
					{
						XmlSerializer xmlSerializer = new XmlSerializer(type);
						try
						{
							result = xmlSerializer.Deserialize(reader);
						}
						catch (System.Exception e)
						{
							StackService.LOG.Error("Failed to deserialize xml content", e);
						}
					}
				}
			}
			else
			{
				StackService.LOG.Error("Null content");
			}
			return result;
		}

		private byte[] Serialize(object content, bool withoutHeader, bool withoutXsn, XmlSerializerNamespaces namespaceSerializer)
		{
			byte[] xmlResult;
			try
			{
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
				{
					using (XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings
					{
						Encoding = new System.Text.UTF8Encoding(false),
						OmitXmlDeclaration = withoutHeader,
						Indent = true
					}))
					{
						XmlSerializer serializer = new XmlSerializer(content.GetType());
						if (namespaceSerializer != null)
						{
							serializer.Serialize(xmlWriter, content, namespaceSerializer);
						}
						else
						{
							serializer.Serialize(xmlWriter, content);
						}
					}
					xmlResult = stream.ToArray();
				}
			}
			catch (System.Exception e)
			{
				StackService.LOG.Error("Serialization failed", e);
				xmlResult = new byte[0];
			}
			return xmlResult;
		}

		private bool FromResouceListToContacts(resourcelists rlist)
		{
			System.Collections.Generic.List<ContactItem> freshGroups = new System.Collections.Generic.List<ContactItem>();
			System.Collections.Generic.List<ContactItem> freshContacts = new System.Collections.Generic.List<ContactItem>();
			ContactItem contctPre = this.serviceManager.ContactService.AddressBook;
			listType[] list2 = rlist.list;
			for (int i = 0; i < list2.Length; i++)
			{
				listType list = list2[i];
				if (list != null && list.name != null)
				{
					this.GetGroupContact(list, contctPre);
				}
			}
			return true;
		}

		private void GetGroupContact(listType listGroup, ContactItem contctParent)
		{
			IContactService cntService = this.serviceManager.ContactService;
			Group group = null;
			if (listGroup != null && listGroup.name != null)
			{
				string strGroupDisName = listGroup.name;
				if (listGroup.displayname != null)
				{
					strGroupDisName = listGroup.displayname.Value;
				}
				string strUil = UriUtils.GetValidSipUri(listGroup.name);
				group = new Group(listGroup.name, strGroupDisName, strUil, false, contctParent);
				lock (cntService)
				{
					cntService.AddGroup(group, contctParent);
				}
				foreach (entryType entry in listGroup.EntryTypes)
				{
					this.EntryToContact(entry, group.Name, group);
				}
			}
			foreach (listType list in listGroup.ListTypeLists)
			{
				if (list != null && list.name != null)
				{
					if (group != null)
					{
						this.GetGroupContact(list, group);
					}
				}
			}
		}

		private void EntryToContact(entryType entry, string groupName, Group group)
		{
			string strDispName = (entry.displayname == null) ? null : entry.displayname.Value;
			string strUil = UriUtils.GetValidSipUri(entry.uri);
			IContactService cntService = this.serviceManager.ContactService;
			lock (cntService)
			{
				if (entry.uri.Contains("9999"))
				{
					Camera caContact = new Camera(UriUtils.GetUserName(entry.uri), strDispName, strUil, false, null);
					ContactItem itemFind = cntService.FindItem("888888888", ContactType.Group);
					if (itemFind == null)
					{
						Group groupCamera = new Group("888888888", "Camera", "sip:888888888@test.com", true, group.Parent);
						groupCamera.GrpType = TrunkGroupTypes.TGT_CAMERA;
						cntService.AddGroup(groupCamera, group.Parent);
						cntService.AddPerson2Group(groupCamera, caContact);
					}
					else
					{
						cntService.AddPerson2Group((Group)itemFind, caContact);
					}
				}
				else
				{
					Person psContact = new Person(UriUtils.GetUserName(entry.uri), strDispName, strUil, false, null);
					cntService.AddPerson2Group(group, psContact);
				}
			}
		}

		private static bool IsSuccessCode(short code)
		{
			return code > 199 && code < 300;
		}

		public MyXcapMessage GetElement(string url)
		{
			return this.xcapStack.GetElement(url);
		}

		public MyXcapMessage GetAttribute(string url)
		{
			return this.xcapStack.GetAttribute(url);
		}

		public MyXcapMessage DeleteDocument(string url)
		{
			return this.xcapStack.DeleteDocument(url);
		}

		public MyXcapMessage DeleteElement(string url)
		{
			return this.xcapStack.DeleteElement(url);
		}

		public MyXcapMessage DeleteAttribute(string url)
		{
			return this.xcapStack.DeleteAttribute(url);
		}

		public MyXcapMessage PutDocument(string url, byte[] payload, uint len, string contentType)
		{
			return this.xcapStack.PutDocument(url, payload, len, contentType);
		}

		public MyXcapMessage PutElement(string url, byte[] payload, uint len)
		{
			return this.xcapStack.PutElement(url, payload, len);
		}

		public MyXcapMessage PutAttribute(string url, byte[] payload, uint len)
		{
			return this.xcapStack.PutAttribute(url, payload, len);
		}

		public bool AvatarPublish(string base64Content, string mimeType)
		{
			bool result;
			if (!this.prepared)
			{
				StackService.LOG.Error("XCAP sevice not prepared");
				result = false;
			}
			else if (!this.bOMAPresenceContent)
			{
				StackService.LOG.Error("OMAPresenceContent not supported");
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		public bool AddGroup(Group group)
		{
			bool result;
			if (this.xcapStack == null)
			{
				result = false;
			}
			else
			{
				string xcap_uri = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
				string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
				string strXcapRoot = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
				string strIdentifier = "/public-group/users/" + xcap_uri + "/" + group.Name;
				string url = strXcapRoot + strIdentifier;
				string strxcappalm = "";
				string[] vxcaptemp = xcap_uri.Split(new char[]
				{
					'@'
				});
				if (vxcaptemp.Length > 1)
				{
					strxcappalm = vxcaptemp[1];
				}
				string strSuperId = "1";
				string strMax = "100";
				string strGroupLevel = "2";
				string strGroupURi = "sip:" + group.Name + "@" + strxcappalm;
				string strPayLoad = string.Concat(new string[]
				{
					"<public-group xmlns=\"com:cmcc:public-group\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"> <list name=\"",
					group.Name,
					"\" uri=\"",
					strGroupURi,
					"\" superIdx=\"",
					strSuperId,
					"\" displayName=\"",
					group.DisplayName,
					"\" max=\"",
					strMax,
					"\" groupLevel=\"",
					strGroupLevel,
					"\"></list><meta-data><creator>",
					xcap_uri,
					"</creator><identifier>",
					strIdentifier,
					"</identifier><timestamp>2014-06-23 14:59:48</timestamp><duration>3600</duration><need-permit>1</need-permit></meta-data></public-group>"
				});
				byte[] payload = System.Text.Encoding.UTF8.GetBytes(strPayLoad);
				MyXcapMessage xcapMessage = this.xcapStack.PutDocument(url, payload, (uint)payload.Length, "application/public-group+xml");
				result = (xcapMessage != null && StackService.IsSuccessCode(xcapMessage.Code));
			}
			return result;
		}

		public bool AddPerson(Person contact, string groupName)
		{
			bool result;
			if (this.xcapStack == null)
			{
				result = false;
			}
			else
			{
				string strContactName = contact.Uri;
				string xcap_uri = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
				string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
				string strXcapRoot = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
				string[] vxcaptemp = xcap_uri.Split(new char[]
				{
					'@'
				});
				string strxcappalm = "";
				if (vxcaptemp.Length > 1)
				{
					strxcappalm = vxcaptemp[1];
				}
				string strGroupURi = "sip:" + groupName + "@" + strxcappalm;
				string url = string.Concat(new string[]
				{
					strXcapRoot,
					"/public-group/users/",
					xcap_uri,
					"/",
					groupName,
					"/~~/public-group/list%5b@uri=%22",
					strGroupURi,
					"%22%5d/entry%5b@uri=%22",
					strContactName,
					"%22%5d "
				});
				char[] vSplit = new char[]
				{
					':',
					'@'
				};
				string[] vTemp = contact.Uri.Split(vSplit);
				if (vTemp != null && vTemp.Length > 1)
				{
					strContactName = vTemp[1];
				}
				string strPaylod = string.Concat(new string[]
				{
					"<entry uri=\"",
					contact.Uri,
					"\" name=\"",
					strContactName,
					"\" owner=\"false\" status=\"active\"><display-name>",
					contact.DisplayName,
					"</display-name></entry>"
				});
				byte[] payload = System.Text.Encoding.UTF8.GetBytes(strPaylod);
				MyXcapMessage xcapMessage = this.xcapStack.PutElement(url, payload, (uint)payload.Length);
				result = (xcapMessage != null && StackService.IsSuccessCode(xcapMessage.Code));
			}
			return result;
		}

		public bool DeletePerson(Person contact, string groupName)
		{
			string strContactName = contact.Uri;
			string strxcappalm = "";
			string xcap_uri = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
			string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
			string strXcapRoot = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
			string[] vxcaptemp = xcap_uri.Split(new char[]
			{
				'@'
			});
			if (vxcaptemp.Length > 1)
			{
				strxcappalm = vxcaptemp[1];
			}
			string strGroupURi = "sip:" + groupName + "@" + strxcappalm;
			string url = string.Concat(new string[]
			{
				strXcapRoot,
				"/public-group/users/",
				xcap_uri,
				"/",
				groupName,
				"/~~/public-group/list%5b@uri=%22",
				strGroupURi,
				"%22%5d/entry%5b@uri=%22",
				strContactName,
				"%22%5d "
			});
			MyXcapMessage xcapMessage = this.xcapStack.DeleteElement(url);
			return xcapMessage != null && StackService.IsSuccessCode(xcapMessage.Code);
		}

		public bool DeleteGroup(Group group)
		{
			string xcap_uri = this.serviceManager.ConfigurationService.ContactsCfg.XcapXui;
			string xcap_password = this.serviceManager.ConfigurationService.ContactsCfg.XcapPassword;
			string strXcapRoot = this.serviceManager.ConfigurationService.ContactsCfg.XcapRoot;
			string strIdentifier = "/public-group/users/" + xcap_uri + "/" + group.Name;
			string url = strXcapRoot + strIdentifier;
			MyXcapMessage xcapMessage = this.xcapStack.DeleteDocument(url);
			return xcapMessage != null && StackService.IsSuccessCode(xcapMessage.Code);
		}

		public StackService(ServiceManager manager)
		{
			this.serviceManager = manager;
			this.sipPreferences = new MySipStack.Preferences();
			this.onlineCallStatus = new System.Collections.Generic.List<TrunkOnlineCallService>();
		}

		public bool Start()
		{
			return true;
		}

		public bool Stop()
		{
			if (this.sipStackStarted)
			{
				this.StopSipStack();
			}
			return true;
		}
	}
}
