using System;

namespace DispCore.Events
{
	public class XcapEventArgs : MyEventArgs
	{
		public const string EXTRA_CONTENT = "content";

		private readonly XcapEventTypes type;

		private readonly string phrase;

		private readonly short code;

		public XcapEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public short Code
		{
			get
			{
				return this.code;
			}
		}

		public string Phrase
		{
			get
			{
				return this.phrase;
			}
		}

		public XcapEventArgs(XcapEventTypes type, short code, string phrase)
		{
			this.type = type;
			this.code = code;
			this.phrase = phrase;
		}
	}
}
