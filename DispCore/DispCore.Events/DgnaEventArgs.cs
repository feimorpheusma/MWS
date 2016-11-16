using System;

namespace DispCore.Events
{
	public class DgnaEventArgs : MyEventArgs
	{
		public const string EXTRA_UDN = "UDN";

		public const string EXTRA_DGNARESULT = "DGNAresult";

		public const string EXTRA_REMOTE_PARTY = "from";

		public const string EXTRA_CONTENT_TYPE = "content-Type";

		public DgnaEventTypes type;

		private readonly byte[] payload;

		private readonly string phrase;

		public DgnaEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public byte[] Payload
		{
			get
			{
				return this.payload;
			}
		}

		public DgnaEventArgs(DgnaEventTypes type, string phrase, byte[] payload)
		{
			this.type = type;
			this.phrase = phrase;
			this.payload = payload;
		}
	}
}
