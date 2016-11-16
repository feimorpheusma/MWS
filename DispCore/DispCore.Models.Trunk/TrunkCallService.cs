using DispCore.Trunk.Types;
using System;
using System.ComponentModel;

namespace DispCore.Models.Trunk
{
	public class TrunkCallService : INotifyPropertyChanged
	{
		private TrunkCallType callType;

		private TrunkCallPrioAttr prioAttr;

		private System.DateTime setupTime;

		private bool e2ee;

		public event PropertyChangedEventHandler PropertyChanged;

		public TrunkCallType CallType
		{
			get
			{
				return this.callType;
			}
			set
			{
				this.callType = value;
				this.OnPropertyChanged("CallType");
			}
		}

		public TrunkCallPrioAttr PrioAttr
		{
			get
			{
				return this.prioAttr;
			}
			set
			{
				this.prioAttr = value;
				this.OnPropertyChanged("PrioAttr");
			}
		}

		public System.DateTime SetupTime
		{
			get
			{
				return this.setupTime;
			}
			set
			{
				this.setupTime = value;
				this.OnPropertyChanged("SetupTime");
			}
		}

		public bool E2ee
		{
			get
			{
				return this.e2ee;
			}
			set
			{
				this.e2ee = value;
				this.OnPropertyChanged("E2ee");
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
