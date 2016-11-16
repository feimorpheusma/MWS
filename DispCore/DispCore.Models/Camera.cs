using DispCore.Types;
using System;

namespace DispCore.Models
{
	public class Camera : Person
	{
		public Camera(string name, string displayName, string uri, bool isLocal, ContactItem parent) : base(name, displayName, uri, isLocal, parent)
		{
			this.type = ContactType.Camera;
		}
	}
}
