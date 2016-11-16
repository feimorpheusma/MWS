using System;

namespace DispCore.Models.Sip
{
	public class MyEvent
	{
		private string eventId;

		private string requestno;

		private EVENTTYPE eventType;

		private string trainId;

		private string eventContext;

		public string EventId
		{
			get
			{
				return this.eventId;
			}
			set
			{
				this.eventId = value;
			}
		}

		public string TrainId
		{
			get
			{
				return this.trainId;
			}
			set
			{
				this.trainId = value;
			}
		}

		public string Requestno
		{
			get
			{
				return this.requestno;
			}
			set
			{
				this.requestno = value;
			}
		}

		public EVENTTYPE EventType
		{
			get
			{
				return this.eventType;
			}
			set
			{
				this.eventType = value;
			}
		}

		public string EventContext
		{
			get
			{
				return this.eventContext;
			}
			set
			{
				this.eventContext = value;
			}
		}
	}
}
