using System;

namespace DispCore.Events
{
	public class StackEventArgs : MyEventArgs
	{
		private readonly StackEventTypes type;

		private readonly string phrase;

		public StackEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public StackEventArgs(StackEventTypes type, string phrase)
		{
			this.type = type;
			this.phrase = phrase;
		}
	}
}
