using System;

namespace DispCore.Events.Sip
{
	public class RegistrationEventArgs : MyEventArgs
	{
		public const string EXTRA_CAUSE = "cause";

		public const string EXTRA_KICKEDIP = "kickedip";

		private readonly RegistrationEventTypes type;

		private readonly short sipCode;

		private readonly string phrase;

		public RegistrationEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public short SipCode
		{
			get
			{
				return this.sipCode;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public RegistrationEventArgs(RegistrationEventTypes type, short sipCode, string phrase)
		{
			this.type = type;
			this.sipCode = sipCode;
			this.phrase = phrase;
		}
	}
}
