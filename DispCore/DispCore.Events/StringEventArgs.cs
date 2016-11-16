using System;

namespace DispCore.Events
{
	public class StringEventArgs : MyEventArgs
	{
		private readonly string value;

		public string Value
		{
			get
			{
				return this.value;
			}
		}

		public StringEventArgs(string value)
		{
			this.value = value;
		}
	}
}
