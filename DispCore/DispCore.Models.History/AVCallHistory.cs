using DispCore.Utils;
using System;
using System.ComponentModel;

namespace DispCore.Models.History
{
	public class AVCallHistory : HistoryItem
	{
		protected string remoteNumber;

		protected bool isOutgoing;

		protected new MediaType mediaType;

		protected System.DateTime startTime;

		protected System.DateTime endTime;

		protected System.TimeSpan connectedTime;

		protected new System.DateTime date;

		protected new long sipSessionId;

		protected bool isConnected;

		public new event PropertyChangedEventHandler PropertyChanged;

		public string RemoteNumber
		{
			get
			{
				return this.remoteNumber;
			}
			set
			{
				this.remoteNumber = value;
			}
		}

		public System.DateTime StartTime
		{
			get
			{
				return this.startTime;
			}
			set
			{
				this.startTime = value;
			}
		}

		public System.DateTime EndTime
		{
			get
			{
				return this.endTime;
			}
			set
			{
				this.endTime = value;
			}
		}

		public System.TimeSpan ConnectedTime
		{
			get
			{
				return this.connectedTime;
			}
			set
			{
				this.ConnectedTime = value;
			}
		}

		public bool IsOutgoing
		{
			get
			{
				return this.isOutgoing;
			}
			set
			{
				this.isOutgoing = value;
				this.OnPropertyChanged("IsGoingOut");
			}
		}

		public new System.DateTime Date
		{
			get
			{
				return this.date;
			}
			set
			{
				this.date = value;
			}
		}

		public bool IsConnected
		{
			get
			{
				return this.isConnected;
			}
			set
			{
				this.isConnected = value;
				this.OnPropertyChanged("IsConnected");
			}
		}

		public new long SipSessionId
		{
			get
			{
				return this.sipSessionId;
			}
			set
			{
				this.sipSessionId = value;
			}
		}

		private AVCallHistory() : this(false, null, 0L)
		{
		}

		public AVCallHistory(bool video, string remoteParty, long id) : base(video ? MediaType.AudioVideo : MediaType.Audio, remoteParty)
		{
			this.startTime = this.date;
			this.date = base.Date;
			this.isConnected = this.seen;
			if (this.status == HistoryItem.StatusType.Incoming || this.status == HistoryItem.StatusType.Outgoing)
			{
				this.isConnected = true;
			}
			else
			{
				this.isConnected = false;
			}
			if (this.status == HistoryItem.StatusType.Outgoing || this.status == HistoryItem.StatusType.Failed)
			{
				this.isOutgoing = true;
			}
			else
			{
				this.isOutgoing = false;
			}
			int t = this.endTime.CompareTo(this.startTime);
			this.sipSessionId = id;
			if (t < 0)
			{
				this.connectedTime = System.TimeSpan.Zero;
			}
			else
			{
				this.connectedTime = this.endTime.Subtract(this.startTime);
			}
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
		}

		public AVCallHistory(bool video, string remoteParty, long id, bool isOutGoing, bool isConnect) : base(video ? MediaType.AudioVideo : MediaType.Audio, remoteParty)
		{
			this.startTime = this.date;
			this.date = base.Date;
			this.isOutgoing = isOutGoing;
			this.isConnected = isConnect;
			int t = this.endTime.CompareTo(this.startTime);
			this.sipSessionId = id;
			if (t < 0)
			{
				this.connectedTime = System.TimeSpan.Zero;
			}
			else
			{
				this.connectedTime = this.endTime.Subtract(this.startTime);
			}
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
		}

		public AVCallHistory(bool video, System.DateTime starttime, System.DateTime endtime, string remoteParty, long id, bool isOutgoing, bool isConnect) : base(video ? MediaType.AudioVideo : MediaType.Audio, remoteParty)
		{
			this.startTime = starttime;
			this.endTime = endtime;
			this.IsOutgoing = isOutgoing;
			this.date = base.Date;
			this.sipSessionId = id;
			this.isConnected = isConnect;
			int t = this.endTime.CompareTo(this.startTime);
			if (t > 0)
			{
				this.connectedTime = this.endTime.Subtract(this.startTime);
			}
			else
			{
				this.connectedTime = System.TimeSpan.Zero;
			}
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
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
