using DispCore.Events;
using DispCore.Events.Sip;
using DispCore.Models;
using DispCore.Models.Trunk;
using System;
using System.Collections.Generic;

namespace DispCore.Services
{
	public interface IStackService : IService
	{
		event System.EventHandler<StackEventArgs> onStackEvent;

		event System.EventHandler<HeartbeartEventArgs> onHeartbeatEvent;

		event System.EventHandler<RegistrationEventArgs> onRegistrationEvent;

		event System.EventHandler<SubscriptionEventArgs> onSubscriptionEvent;

		event System.EventHandler<MessageEventArgs> onMessageEvent;

		event System.EventHandler<DgnaEventArgs> onDgnaEvent;

		event System.EventHandler<VideoSendEventArgs> onVideoSendEvent;

		event System.EventHandler<AddressListEventArgs> onAddressListEvent;

		event System.EventHandler<CallEventArgs> onCallEvent;

		event System.EventHandler<PttEventArgs> onPttEvent;

		event System.EventHandler<XcapEventArgs> onXcapEvent;

		MySipStack SipStack
		{
			get;
		}

		bool SipStackStarted
		{
			get;
		}

		MyXcapStack XCapStack
		{
			get;
		}

		System.Collections.Generic.List<TrunkOnlineCallService> OnlineCallStatus
		{
			get;
		}

		bool SipStackCfg();

		bool StartSipStack();

		bool StopSipStack();

		bool ConfigXcapStack();

		bool StartXcapStack();

		bool StopXcapStack();

		bool XcapPrepare();

		bool XcapUnPrepare();

		bool XcapIsReady();

		MyXcapMessage GetDocument(string url);

		MyXcapMessage GetElement(string url);

		MyXcapMessage GetAttribute(string url);

		MyXcapMessage DeleteDocument(string url);

		MyXcapMessage DeleteElement(string url);

		MyXcapMessage DeleteAttribute(string url);

		MyXcapMessage PutDocument(string url, byte[] payload, uint len, string contentType);

		MyXcapMessage PutElement(string url, byte[] payload, uint len);

		MyXcapMessage PutAttribute(string url, byte[] payload, uint len);

		bool DownloadDocuments();

		bool AddGroup(Group group);

		bool AddPerson(Person contact, string groupName);

		bool DeletePerson(Person contact, string groupName);

		bool DeleteGroup(Group group);
	}
}
