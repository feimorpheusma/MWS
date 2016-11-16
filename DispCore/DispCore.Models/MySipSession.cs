using DispCore.Utils;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.ComponentModel;

namespace DispCore.Models
{
	public abstract class MySipSession : INotifyPropertyChanged, System.IDisposable
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MySipSession));

		protected MySipStack sipStack;

		protected bool connected;

		protected bool outgoing;

		protected string fromUri;

		protected string toUri;

		protected string compId;

		protected string remotePartyUri;

		protected bool isGroupSession;

		protected long id = -1L;

		protected bool m_Disposed;

		protected System.DateTime time;

		protected System.DateTime startTime;

		protected short code;

		public event PropertyChangedEventHandler PropertyChanged;

		public long Id
		{
			get
			{
				if (this.id == -1L)
				{
					this.id = (long)((ulong)this.Session.getId());
				}
				return this.id;
			}
		}

		public MySipStack Stack
		{
			get
			{
				return this.sipStack;
			}
		}

		public bool IsConnected
		{
			get
			{
				return this.connected;
			}
			set
			{
				this.connected = value;
				this.OnPropertyChanged("IsConnected");
			}
		}

		public string FromUri
		{
			get
			{
				return this.fromUri;
			}
			set
			{
				this.fromUri = value;
				this.fromUri = UriUtils.GetValidSipUri(this.fromUri);
				if (!this.Session.setFromUri(this.fromUri))
				{
					MySipSession.LOG.Error(string.Format("{0} is invalid for as FromUri", value));
				}
			}
		}

		public string ToUri
		{
			get
			{
				return this.toUri;
			}
			set
			{
				this.toUri = value;
				this.toUri = UriUtils.GetValidSipUri(this.toUri);
				if (!this.Session.setToUri(this.toUri))
				{
					MySipSession.LOG.Error(string.Format("{0} is invalid for as toUri", value));
				}
			}
		}

		public string RemotePartyUri
		{
			get
			{
				if (string.IsNullOrEmpty(this.remotePartyUri))
				{
					this.remotePartyUri = (this.outgoing ? this.toUri : this.fromUri);
				}
				return string.IsNullOrEmpty(this.remotePartyUri) ? "(null)" : this.remotePartyUri;
			}
			set
			{
				this.remotePartyUri = value;
			}
		}

		public string SigCompId
		{
			get
			{
				return this.compId;
			}
			set
			{
				if (this.compId != null && this.compId != value)
				{
					this.Session.removeSigCompCompartment();
				}
				this.compId = value;
				if (value != null)
				{
					this.Session.addSigCompCompartment(this.compId);
				}
			}
		}

		public bool IsOutgoing
		{
			get
			{
				return this.outgoing;
			}
			set
			{
				this.outgoing = value;
			}
		}

		public System.DateTime StartTime
		{
			get
			{
				return this.startTime;
			}
			set
			{
				this.startTime = value;
			}
		}

		public System.DateTime Time
		{
			get
			{
				return this.time;
			}
		}

		public short Code
		{
			get
			{
				return this.code;
			}
			set
			{
				this.code = value;
				this.OnPropertyChanged("Code");
			}
		}

		public bool IsGroupSession
		{
			get;
			set;
		}

		protected abstract SipSession Session
		{
			get;
		}

		protected bool Disposed
		{
			get
			{
				return this.m_Disposed;
			}
		}

		public MySipSession(MySipStack sipStack)
		{
			this.sipStack = sipStack;
			this.outgoing = false;
			this.time = System.DateTime.Now;
		}

		public MySipSession(string remoteParty, MediaType mediaType)
		{
			this.id = 100L;
			System.Random ran = new System.Random();
			this.id = (long)ran.Next(10000, 99999);
			this.remotePartyUri = remoteParty;
			this.outgoing = false;
			this.time = System.DateTime.Now;
		}

		~MySipSession()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (!this.m_Disposed)
			{
				if (this.Session != null)
				{
					((System.IDisposable)this.Session).Dispose();
				}
				this.m_Disposed = true;
			}
		}

		public virtual void PreDispose()
		{
		}

		protected void init()
		{
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
