using DispCore.Models.Trunk;
using DispCore.Trunk.Types;
using DispCore.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DispCore.Models
{
	public class ContactItem : INotifyPropertyChanged
	{
		protected ContactType type;

		protected string name;

		protected string displayName;

		protected string uri;

		protected ContactItem parent;

		protected System.Collections.Generic.List<ContactItem> children;

		protected bool isLocal;

		protected ObservableCollection<TrunkCallService> callInstances;

		protected ObservableCollection<MyAVSession> avSessions;

		public event PropertyChangedEventHandler PropertyChanged;

		public ContactType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
				this.OnPropertyChanged("Name");
			}
		}

		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				this.displayName = value;
				this.OnPropertyChanged("DisplayName");
			}
		}

		public string Uri
		{
			get
			{
				return this.uri;
			}
			set
			{
				this.uri = value;
				this.OnPropertyChanged("Uri");
			}
		}

		public ContactItem Parent
		{
			get
			{
				return this.parent;
			}
			set
			{
				this.parent = value;
			}
		}

		public bool IsLocal
		{
			get
			{
				return this.isLocal;
			}
			set
			{
				this.isLocal = value;
			}
		}

		public System.Collections.Generic.List<ContactItem> Children
		{
			get
			{
				return this.children;
			}
			set
			{
				this.children = value;
			}
		}

		public ObservableCollection<TrunkCallService> CallIntances
		{
			get
			{
				return this.callInstances;
			}
			set
			{
				this.callInstances = value;
			}
		}

		public ObservableCollection<MyAVSession> AvSessions
		{
			get
			{
				return this.avSessions;
			}
		}

		public ContactItem(string name, string displayName, string uri, bool isLocal, ContactItem parent)
		{
			this.name = name;
			this.displayName = displayName;
			this.uri = uri;
			this.parent = parent;
			this.isLocal = isLocal;
			this.callInstances = new ObservableCollection<TrunkCallService>();
			this.avSessions = new ObservableCollection<MyAVSession>();
		}

		public bool AddAVSession(MyAVSession avSession)
		{
			this.avSessions.Add(avSession);
			return true;
		}

		public bool DelAVSession(MyAVSession avSession)
		{
			if (this.avSessions.Count<MyAVSession>() > 0 && this.avSessions.Contains(avSession))
			{
				this.avSessions.Remove(avSession);
			}
			return true;
		}

		public MyAVSession FindAVSession(MediaType media)
		{
			MyAVSession result;
			foreach (MyAVSession session in this.avSessions)
			{
				if ((session.MediaType & media) == media)
				{
					result = session;
					return result;
				}
			}
			result = null;
			return result;
		}

		public TrunkCallService FindCallService(TrunkCallType callType)
		{
			TrunkCallService result;
			using (System.Collections.Generic.IEnumerator<TrunkCallService> enumerator = this.callInstances.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					TrunkCallService item = enumerator.Current;
					item.CallType = callType;
					result = item;
					return result;
				}
			}
			result = null;
			return result;
		}

		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
