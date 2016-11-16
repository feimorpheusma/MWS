using DispCore.Utils;
using System;

namespace DispCore.Models.History
{
	public class ShortMessageHistory : HistoryItem, System.IComparable<ShortMessageHistory>
	{
		private string content;

		private bool delivered;

		private bool isOutgoing;

		private string remoteNumber;

		private System.DateTime startTime;

		private new System.DateTime date;

		private new long sipSessionId;

		public string Content
		{
			get
			{
				return this.content;
			}
			set
			{
				this.content = value;
			}
		}

		public bool IsDelivered
		{
			get
			{
				return this.delivered;
			}
			set
			{
				this.delivered = value;
			}
		}

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

		public bool IsOutgoing
		{
			get
			{
				return this.isOutgoing;
			}
			set
			{
				this.isOutgoing = value;
			}
		}

		private ShortMessageHistory() : this(null, null, 0L, false)
		{
		}

		public ShortMessageHistory(string remoteParty, string Content, long id, bool isOut) : base(MediaType.ShortMessage, remoteParty)
		{
			this.startTime = this.date;
			this.date = base.Date;
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
			this.sipSessionId = base.SipSessionId;
			this.content = Content;
			this.sipSessionId = id;
			this.isOutgoing = isOut;
		}

		public ShortMessageHistory(string remoteParty, long id, bool isOut) : base(MediaType.ShortMessage, remoteParty)
		{
			this.startTime = this.date;
			this.date = base.Date;
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
			this.sipSessionId = base.SipSessionId;
			this.sipSessionId = id;
			this.isOutgoing = isOut;
		}

		public ShortMessageHistory(string remoteParty) : base(MediaType.ShortMessage, remoteParty)
		{
			this.startTime = this.date;
			this.date = base.Date;
			this.remoteNumber = UriUtils.GetUserName(remoteParty);
			this.sipSessionId = base.SipSessionId;
		}

		int System.IComparable<ShortMessageHistory>.CompareTo(ShortMessageHistory other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException("other");
			}
			return other.Date.CompareTo(this.Date);
		}
	}
}
