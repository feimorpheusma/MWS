using System;
using System.Collections.Generic;

namespace DispCore.Services
{
	public class ServiceArgs
	{
		private readonly System.Collections.Generic.IDictionary<string, object> extras;

		public ServiceArgs()
		{
			this.extras = new System.Collections.Generic.Dictionary<string, object>();
		}

		public object Get(string key)
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

		public ServiceArgs Add(string key, object value)
		{
			if (!this.extras.ContainsKey(key))
			{
				this.extras.Add(key, value);
			}
			return this;
		}
	}
}
