using DispApp.Generated.im_iscomposing;
using DispCore.Events;
using log4net;
using System;
using System.IO;
using System.Text;
using System.Timers;
using System.Xml;
using System.Xml.Serialization;

namespace DispCore.Utils
{
	public class IMActivityIndicator
	{
		private const double TIMER_LOCAL_ACTIVE_VALUE = 60.0;

		private const double TIMER_LOCAL_IDLE_VALUE = 15.0;

		private const double TIMER_REMOTE_ACTIVE_VALUE = 120.0;

		private static readonly ILog LOG = LogManager.GetLogger(typeof(IMActivityIndicator));

		private bool is_local_active;

		private bool is_remote_active;

		private Timer systimer_local_active;

		private Timer systimer_local_idle;

		private Timer systimer_remote_active;

		private readonly string uriString;

		private event System.EventHandler sendMessageEvent;

		private event System.EventHandler remoteStateChangedEvent;

		public event System.EventHandler SendMessageEvent
		{
			add
			{
				this.sendMessageEvent += value;
			}
			remove
			{
				this.sendMessageEvent -= value;
			}
		}

		public event System.EventHandler RemoteStateChangedEvent
		{
			add
			{
				this.remoteStateChangedEvent += value;
			}
			remove
			{
				this.remoteStateChangedEvent -= value;
			}
		}

		public string UriString
		{
			get
			{
				return this.uriString;
			}
		}

		public bool IsRemoteActive
		{
			get
			{
				return this.is_remote_active;
			}
		}

		public IMActivityIndicator(string uriString)
		{
			this.uriString = uriString;
			this.systimer_local_active = new Timer(60000.0);
			this.systimer_local_idle = new Timer(15000.0);
			this.systimer_local_active.Elapsed += new ElapsedEventHandler(this.systimer_local_active_Elapsed);
			this.systimer_local_idle.Elapsed += new ElapsedEventHandler(this.systimer_local_idle_Elapsed);
			this.systimer_remote_active = new Timer();
			this.systimer_remote_active.AutoReset = false;
			this.systimer_remote_active.Elapsed += new ElapsedEventHandler(this.systimer_remote_active_Elapsed);
		}

		public void StopAll()
		{
			this.systimer_local_active.Stop();
			this.systimer_local_idle.Stop();
			this.systimer_remote_active.Stop();
		}

		public void OnComposing()
		{
			lock (this)
			{
				if (!this.is_local_active)
				{
					this.is_local_active = true;
					EventHandlerTrigger.TriggerEvent(this.sendMessageEvent, this);
				}
				this.StartLocalTimers();
			}
		}

		public void OnContentSent()
		{
			lock (this)
			{
				this.StopLocalTimers();
				this.is_local_active = false;
			}
		}

		public void OnContentReceived()
		{
			lock (this)
			{
				this.is_remote_active = false;
				EventHandlerTrigger.TriggerEvent(this.remoteStateChangedEvent, this);
			}
		}

		public void OnIndicationReceived(string xmlindication)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(isComposing));
				using (System.IO.MemoryStream stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlindication)))
				{
					isComposing state = serializer.Deserialize(stream) as isComposing;
					if (state != null && !string.IsNullOrEmpty(state.state))
					{
						this.is_remote_active = state.state.Equals("active");
						if (this.is_remote_active)
						{
							double refresh = 120.0;
							if (!string.IsNullOrEmpty(state.refresh))
							{
								if (!double.TryParse(state.refresh, out refresh))
								{
									return;
								}
								this.systimer_remote_active.Interval = refresh * 1000.0;
							}
							else
							{
								this.systimer_remote_active.Interval = refresh * 1000.0;
							}
							this.systimer_remote_active.Start();
						}
						else
						{
							this.systimer_remote_active.Stop();
						}
						EventHandlerTrigger.TriggerEvent(this.remoteStateChangedEvent, this);
					}
				}
			}
			catch (System.Exception e)
			{
				IMActivityIndicator.LOG.Error(e);
			}
		}

		public string GetMessageIndicator()
		{
			string message = string.Empty;
			isComposing obj = new isComposing();
			obj.state = (this.is_local_active ? "active" : "idle");
			obj.contenttype = "text/plain";
			if (this.is_local_active)
			{
				obj.refresh = 60.0.ToString();
			}
			try
			{
				using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
				{
					using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings
					{
						Encoding = new System.Text.UTF8Encoding(false),
						OmitXmlDeclaration = false,
						Indent = true
					}))
					{
						XmlSerializer serializer = new XmlSerializer(typeof(isComposing));
						serializer.Serialize(xmlWriter, obj);
						xmlWriter.Flush();
						xmlWriter.Close();
					}
					message = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
				}
			}
			catch (System.Exception e)
			{
				IMActivityIndicator.LOG.Error(e);
			}
			return message;
		}

		private void systimer_local_idle_Elapsed(object sender, ElapsedEventArgs e)
		{
			lock (this)
			{
				this.StopLocalTimers();
				if (this.is_local_active)
				{
					this.is_local_active = false;
					EventHandlerTrigger.TriggerEvent(this.sendMessageEvent, this);
				}
			}
		}

		private void systimer_local_active_Elapsed(object sender, ElapsedEventArgs e)
		{
			lock (this)
			{
				if (this.is_local_active)
				{
					EventHandlerTrigger.TriggerEvent(this.sendMessageEvent, this);
				}
			}
		}

		private void systimer_remote_active_Elapsed(object sender, ElapsedEventArgs e)
		{
			lock (this)
			{
				if (this.is_remote_active)
				{
					this.is_remote_active = false;
				}
				EventHandlerTrigger.TriggerEvent(this.remoteStateChangedEvent, this);
			}
		}

		private void StartLocalTimers()
		{
			if (this.systimer_local_active.Enabled)
			{
				this.systimer_local_active.Stop();
			}
			if (this.systimer_local_idle.Enabled)
			{
				this.systimer_local_idle.Stop();
			}
			this.systimer_local_active.Start();
			this.systimer_local_idle.Start();
		}

		private void StopLocalTimers()
		{
			this.systimer_local_active.Stop();
			this.systimer_local_idle.Stop();
		}
	}
}
