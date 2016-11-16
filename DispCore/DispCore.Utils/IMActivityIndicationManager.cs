using DispCore.Events;
using System;
using System.Collections.Generic;

namespace DispCore.Utils
{
	public class IMActivityIndicationManager
	{
		private System.Collections.Generic.IDictionary<string, IMActivityIndicator> entries = null;

		public event System.EventHandler SendMessageEvent;

		public event System.EventHandler RemoteStateChangedEvent;

		public IMActivityIndicationManager()
		{
			this.entries = new System.Collections.Generic.Dictionary<string, IMActivityIndicator>();
		}

		public void AddEntry(string uriString)
		{
			lock (this.entries)
			{
				if (!this.entries.ContainsKey(uriString))
				{
					IMActivityIndicator entry = new IMActivityIndicator(uriString);
					entry.RemoteStateChangedEvent += new System.EventHandler(this.entry_RemoteStateChangedEvent);
					entry.SendMessageEvent += new System.EventHandler(this.entry_SendMessageEvent);
					this.entries.Add(uriString, entry);
				}
			}
		}

		public void RemoveEntry(string uriString)
		{
			this.RemoveEntry(uriString, true);
		}

		public void Reset()
		{
			lock (this.entries)
			{
				foreach (System.Collections.Generic.KeyValuePair<string, IMActivityIndicator> kvp in this.entries)
				{
					this.RemoveEntry(kvp.Key, false);
				}
				this.entries.Clear();
			}
		}

		public void StopAll()
		{
			lock (this.entries)
			{
				foreach (System.Collections.Generic.KeyValuePair<string, IMActivityIndicator> kvp in this.entries)
				{
					kvp.Value.StopAll();
				}
			}
		}

		public void OnComposing()
		{
			lock (this.entries)
			{
				foreach (System.Collections.Generic.KeyValuePair<string, IMActivityIndicator> kvp in this.entries)
				{
					kvp.Value.OnComposing();
				}
			}
		}

		public void OnContentSent()
		{
			lock (this.entries)
			{
				foreach (System.Collections.Generic.KeyValuePair<string, IMActivityIndicator> kvp in this.entries)
				{
					kvp.Value.OnContentSent();
				}
			}
		}

		public void OnContentReceived(string uriString)
		{
			lock (this.entries)
			{
				if (this.entries.ContainsKey(uriString))
				{
					this.entries[uriString].OnContentReceived();
				}
			}
		}

		public void OnIndicationReceived(string uriString, string xmlindication)
		{
			lock (this.entries)
			{
				if (this.entries.ContainsKey(uriString))
				{
					this.entries[uriString].OnIndicationReceived(xmlindication);
				}
			}
		}

		public string GetMessageIndicator()
		{
			string result;
			lock (this.entries)
			{
				using (System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, IMActivityIndicator>> enumerator = this.entries.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						System.Collections.Generic.KeyValuePair<string, IMActivityIndicator> kvp = enumerator.Current;
						result = kvp.Value.GetMessageIndicator();
						return result;
					}
				}
			}
			result = string.Empty;
			return result;
		}

		private void RemoveEntry(string uriString, bool delete)
		{
			lock (this.entries)
			{
				if (this.entries.ContainsKey(uriString))
				{
					this.entries[uriString].RemoteStateChangedEvent -= new System.EventHandler(this.entry_RemoteStateChangedEvent);
					this.entries[uriString].SendMessageEvent -= new System.EventHandler(this.entry_SendMessageEvent);
					this.entries[uriString].StopAll();
					this.entries.Remove(uriString);
				}
			}
		}

		private void entry_SendMessageEvent(object sender, System.EventArgs e)
		{
			EventHandlerTrigger.TriggerEvent(this.SendMessageEvent, sender);
		}

		private void entry_RemoteStateChangedEvent(object sender, System.EventArgs e)
		{
			EventHandlerTrigger.TriggerEvent(this.RemoteStateChangedEvent, sender);
		}
	}
}
