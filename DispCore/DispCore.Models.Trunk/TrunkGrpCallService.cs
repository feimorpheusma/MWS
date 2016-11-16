using DispCore.Types.Trunk;
using System;
using System.Collections.Generic;

namespace DispCore.Models.Trunk
{
	public class TrunkGrpCallService : TrunkCallService
	{
		private TrunkUserCallStatusTypes status;

		private string callingUdn;

		private string onlineCallId;

		private System.Collections.Generic.List<string> grpCallMembers;

		public TrunkUserCallStatusTypes Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
				base.OnPropertyChanged("Status");
			}
		}

		public string CallingUdn
		{
			get
			{
				return this.callingUdn;
			}
			set
			{
				this.callingUdn = value;
				base.OnPropertyChanged("CallingUdn");
			}
		}

		public string OnlineCallId
		{
			get
			{
				return this.onlineCallId;
			}
			set
			{
				this.onlineCallId = value;
				base.OnPropertyChanged("OnlineCallId");
			}
		}

		public System.Collections.Generic.List<string> CallMembers
		{
			get
			{
				return this.grpCallMembers;
			}
			set
			{
				this.grpCallMembers = value;
				base.OnPropertyChanged("CallMembers");
			}
		}

		public TrunkGrpCallService()
		{
			this.grpCallMembers = new System.Collections.Generic.List<string>();
		}
	}
}
