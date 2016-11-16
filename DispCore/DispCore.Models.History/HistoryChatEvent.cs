using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DispCore.Models.History
{
	[XmlRoot("ChatEvent")]
	[System.Serializable]
	public class HistoryChatEvent : HistoryItem, System.IComparable<HistoryChatEvent>
	{
		private System.Collections.Generic.List<ShortMessageHistory> messages;

		[XmlElement("Messages")]
		public System.Collections.Generic.List<ShortMessageHistory> Messages
		{
			get
			{
				if (this.messages == null)
				{
					this.messages = new System.Collections.Generic.List<ShortMessageHistory>();
				}
				return this.messages;
			}
			set
			{
				this.messages = value;
			}
		}

		private HistoryChatEvent() : this(null)
		{
		}

		public HistoryChatEvent(string remoteParty) : base(MediaType.Chat, remoteParty)
		{
		}

		public int CompareTo(HistoryChatEvent other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException("other");
			}
			return other.Date.CompareTo(base.Date);
		}
	}
}
