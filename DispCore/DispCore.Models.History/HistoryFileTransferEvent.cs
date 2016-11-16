using System;
using System.Xml.Serialization;

namespace DispCore.Models.History
{
	[XmlRoot("HistoryFileTransferEvent")]
	[System.Serializable]
	public class HistoryFileTransferEvent : HistoryItem, System.IComparable<HistoryFileTransferEvent>
	{
		private string filePath;

		private MyMsrpSession msrpSession;

		[XmlElement("FilePath")]
		public string FilePath
		{
			get
			{
				return this.filePath;
			}
			set
			{
				this.filePath = value;
			}
		}

		[XmlIgnore]
		public MyMsrpSession MsrpSession
		{
			get
			{
				return this.msrpSession;
			}
			set
			{
				this.msrpSession = value;
			}
		}

		private HistoryFileTransferEvent() : this(null, null)
		{
		}

		public HistoryFileTransferEvent(string remoteParty, string filePath) : base(MediaType.FileTransfer, remoteParty)
		{
			this.filePath = filePath;
		}

		public int CompareTo(HistoryFileTransferEvent other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException("other");
			}
			return other.Date.CompareTo(base.Date);
		}
	}
}
