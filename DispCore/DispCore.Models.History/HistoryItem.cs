using DispCore.Utils;
using System;
using System.ComponentModel;

namespace DispCore.Models.History
{
	public abstract class HistoryItem : System.IComparable<HistoryItem>, INotifyPropertyChanged
	{
		public enum StatusType
		{
			Outgoing = 1,
			Incoming,
			Missed = 4,
			Failed = 8,
			All = 15
		}

		protected MediaType mediaType;

		protected string remoteParty;

		protected bool seen;

		protected HistoryItem.StatusType status;

		protected System.DateTime date;

		protected string displayName;

		protected long sipSessionId;

		public event PropertyChangedEventHandler PropertyChanged;

		public MediaType MediaType
		{
			get
			{
				return this.mediaType;
			}
			set
			{
				this.mediaType = value;
			}
		}

		public string RemoteParty
		{
			get
			{
				return this.remoteParty;
			}
			set
			{
				this.remoteParty = value;
			}
		}

		public System.DateTime Date
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

		public bool Seen
		{
			get
			{
				return this.seen;
			}
			set
			{
				this.seen = value;
			}
		}

		public HistoryItem.StatusType Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		public long SipSessionId
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

		protected HistoryItem()
		{
			this.status = HistoryItem.StatusType.Missed;
			this.date = System.DateTime.Now;
		}

		protected HistoryItem(MediaType mediaType, string remoteParty) : this()
		{
			this.mediaType = mediaType;
			this.remoteParty = UriUtils.GetUserName(remoteParty);
		}

		protected HistoryItem(MediaType mediaType, string remoteParty, long id) : this()
		{
			this.mediaType = mediaType;
			this.remoteParty = UriUtils.GetUserName(remoteParty);
			this.sipSessionId = id;
		}

		public int CompareTo(HistoryItem other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException("other");
			}
			return other.Date.CompareTo(this.Date);
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
