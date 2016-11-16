using DispCore.Types.Trunk;
using System;

namespace DispCore.Models.Trunk
{
	public class TrunkUserCallService : TrunkCallService
	{
		private TrunkUserCallStatusTypes status;

		private int direction;

		private string calledUDN;

		private string callingUDN;

		private string onlineCallID;

		private bool duplex;

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

		public string CalledUDN
		{
			get
			{
				return this.calledUDN;
			}
			set
			{
				this.calledUDN = value;
				base.OnPropertyChanged("CalledUDN");
			}
		}

		public string CallingUDN
		{
			get
			{
				return this.callingUDN;
			}
			set
			{
				this.callingUDN = value;
				base.OnPropertyChanged("CallingUDN");
			}
		}

		public int Direction
		{
			get
			{
				return this.direction;
			}
			set
			{
				this.direction = value;
			}
		}

		public bool Duplex
		{
			get
			{
				return this.duplex;
			}
			set
			{
				this.duplex = value;
				base.OnPropertyChanged("Duplex");
			}
		}

		public string OnlineCallID
		{
			get
			{
				return this.onlineCallID;
			}
			set
			{
				this.onlineCallID = value;
			}
		}
	}
}
