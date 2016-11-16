using System;

namespace DispCore.Events
{
	public class HistoryEventArgs : MyEventArgs
	{
		public const string EXTRA_EVENT = "event";

		public readonly HistoryEventTypes type;

		public HistoryEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public HistoryEventArgs(HistoryEventTypes type)
		{
			this.type = type;
		}
	}
}
