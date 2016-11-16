using System;

namespace DispCore.Events
{
	public class ContactEventArgs : MyEventArgs
	{
		public const string EXTRA_CONTACT = "contact";

		public const string EXTRA_GROUP = "group";

		public const string EXTRA_PARENT = "parent";

		private readonly ContactEventTypes type;

		public ContactEventTypes Type
		{
			get
			{
				return this.type;
			}
		}

		public ContactEventArgs(ContactEventTypes type)
		{
			this.type = type;
		}
	}
}
