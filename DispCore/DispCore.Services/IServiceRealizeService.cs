using DispCore.Events;
using DispCore.Models;
using DispCore.Types.Trunk;
using System;
using System.Collections.Generic;

namespace DispCore.Services
{
	public interface IServiceRealizeService : IService
	{
		event System.EventHandler<ServiceSessionChangedEventArgs> onServiceSessionChangedEvent;

		SessionManager AvSessionMgr
		{
			get;
		}

		SessionManager MsgSessionMgr
		{
			get;
		}

		SessionManager DisSessionMgr
		{
			get;
		}

		MyAVSession FindAVSession(long sessionId);

		MySipSession FindMsgSession(long sessionId);

		MyAVSession AudioCall(string remoteUri, bool triggerEvent = false, byte foaoroacsu = 0, byte PrioAttribute = 0);

		MyAVSession VideoCall(string remoteUri, bool triggerEvent = false);

		MyAVSession VideoOnlyCall(string remoteUri, bool triggerEvent = false);

		MyAVSession VideoPollCall(string remoteUri, bool triggerEvent = false);

		MyAVSession VideoPushCall(string remoteUri, bool triggerEvent = false);

		MyAVSession AmbianceListenCall(string remoteUri);

		bool ForceInCall(string remoteUri, string onlineCallId);

		bool P2PBreakInCall(string remoteUri);

		bool P2PBreakOffCall(string remoteUri);

		bool GrpBreakInCall(string remoteUri);

		bool GrpBreakOffCall(string remoteUri);

		bool HoldCall(long sessionId);

		bool ResumeCall(long sessionId);

		bool TransferCall(long sessionId);

		bool AudioMonitorCall(string uri, string onlineCallId);

		bool AudioMonitorCall(string uri);

		bool StopAudioMonitorCall(string uri);

		MyMessageSession SendMessage(string remoteUri, string content, string strMsgMode, bool bE2ee);

		MyMessageSession SendMessage(string remoteUri, TrunkMsgOperaterType OperaterType, string type, string content);

		MyAVSession GroupAudioCall(string groupUri);

		MyAVSession GroupVideoCall(string groupUri, ServiceArgs args);

		MyAVSession AudioMulticastCall(string groupUri);

		MyAVSession VideoMulticastCall(string groupUri, ServiceArgs args);

		void GroupVideoPushCall(string groupUri, ServiceArgs args);

		void ForceInGroupCall(string remoteUri, ServiceArgs args);

		void AudioMonitorGroupCall(string groupUri, ServiceArgs args);

		bool CreateGroup(bool isTempGrp, string groupName, int priority, int maxPeriod, System.Collections.Generic.List<string> userList, string strGroupGDN);

		bool DeleteGroup(Group group);

		bool AcceptCall(long sessionId);

		bool AcceptCall(MyAVSession avSession);

		bool ReleaseCall(long sessionId);

		bool RequestPTT(long sessionId);

		bool ReleasePTT(long sessionId);

		bool UpdateMedia(long sessionId, MediaType newMediaType, MediaAttr mediaAttr);

		bool StartVideoForward(string strResVideoId, string strVideoIdType, System.Collections.Generic.List<UserAndType> listDstUser);

		bool StopVideoForward(string strResVideoId, string strVideoIdType, System.Collections.Generic.List<UserAndType> listDstUser);

		void ConfereceCall(string strGdn, bool bVideo);

		bool RefreshLocalVideo(long sessionId);

		void ClearSesion(long lSensionId);
	}
}
