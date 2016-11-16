using System;
using System.Collections.Generic;

namespace DispCore.Events
{
	public class MyEventArgs : System.EventArgs
	{
		private readonly System.Collections.Generic.IDictionary<string, object> extras;

		public MyEventArgs()
		{
			this.extras = new System.Collections.Generic.Dictionary<string, object>();
		}

		public object GetExtra(string key)
		{
			object result;
			if (this.extras.ContainsKey(key))
			{
				result = this.extras[key];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public MyEventArgs AddExtra(string key, object value)
		{
			if (!this.extras.ContainsKey(key))
			{
				this.extras.Add(key, value);
			}
			return this;
		}
	}
}
