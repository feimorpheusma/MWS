using System;
using System.ComponentModel;

namespace DispCore.Models.Trunk
{
	public class TrunkOnlineCallService : TrunkUserCallService
	{
		private System.DateTime temilTime;

		public new event PropertyChangedEventHandler PropertyChanged;

		public System.DateTime TemilTime
		{
			get
			{
				return this.temilTime;
			}
			set
			{
				this.temilTime = value;
				this.OnPropertyChanged("TemilTime");
			}
		}

		protected new void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
