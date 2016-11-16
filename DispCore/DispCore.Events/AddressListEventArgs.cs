using System;

namespace DispCore.Events
{
	public class AddressListEventArgs : MyEventArgs
	{
		public AddressListEventTypes type;

		public string contentType;

		public byte[] content;

		public AddressListEventArgs(AddressListEventTypes type, string contentType, byte[] content)
		{
			this.type = type;
			this.contentType = contentType;
			this.content = content;
		}
	}
}
