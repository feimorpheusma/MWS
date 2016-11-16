using System;

namespace DispCore.Events
{
	public class StatusEventArgs : MyEventArgs
	{
		private readonly StatusEventTypes type;

		public StatusEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public StatusEventArgs(StatusEventTypes type)
		{
			this.type = type;
		}
	}
}
