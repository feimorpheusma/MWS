using System;

namespace DispCore.Models
{
	public class CallStatusService
	{
		private string strCallStatus;

		private string strCallType;

		private string strDuplexStatus;

		private string strOnlineCallID;

		private string strPrioAttribute;

		private string strE2ee;

		private string strSetupTime;

		private string strCallingUDN;

		private string strCalledUDN;

		public string CallStatus
		{
			get
			{
				return this.strCallStatus;
			}
		}

		public string CallType
		{
			get
			{
				return this.strCallType;
			}
		}

		public string DuplexStatus
		{
			get
			{
				return this.strDuplexStatus;
			}
		}

		public string OnlineCallID
		{
			get
			{
				return this.strOnlineCallID;
			}
		}

		public string PrioAttribute
		{
			get
			{
				return this.strPrioAttribute;
			}
		}

		public string E2ee
		{
			get
			{
				return this.strE2ee;
			}
		}

		public string SetupTime
		{
			get
			{
				return this.strSetupTime;
			}
		}

		public string CallingUDN
		{
			get
			{
				return this.strCallingUDN;
			}
		}

		public string CalledUDN
		{
			get
			{
				return this.strCalledUDN;
			}
		}

		public CallStatusService(string callStatus, string callType, string onlineCallID, string duplexStatus, string prioAttribute, string e2ee, string setupTime, string callingUDN, string calledUDN)
		{
			this.strCallStatus = callStatus;
			this.strCallType = callType;
			this.strDuplexStatus = this.strDuplexStatus;
			this.strOnlineCallID = onlineCallID;
			this.strPrioAttribute = prioAttribute;
			this.strE2ee = e2ee;
			this.strSetupTime = setupTime;
			this.strCallingUDN = callingUDN;
			this.strCalledUDN = calledUDN;
		}
	}
}
