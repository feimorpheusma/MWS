using DispCore.Events;
using DispCore.Models;
using DispCore.Models.History;
using DispCore.Utils;
using log4net;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Timers;
using System.Xml.Serialization;

namespace DispCore.Services.Impl
{
	public class HistoryService : IHistoryService, IService
	{
		private const string FILE_NAME = "history.xml";

		private ServiceManager serviceManager;

		private ObservableCollection<AVCallHistory> avHistories;

		private ObservableCollection<MyMessageSession> modelOfMessageList;

		private MyObservableCollection<MySipSession> avSessions;

		private MyObservableCollection<MySipSession> messageSessions;

		private MyObservableCollection<HistoryItem> events;

		private bool loading;

		private readonly System.Timers.Timer deferredSaveTimer;

		private readonly XmlSerializer xmlSerializer;

		private static readonly ILog LOG = LogManager.GetLogger(typeof(HistoryService));

		private string fileFullPath;

		public event System.EventHandler<HistoryEventArgs> onHistoryEvent;

		public ObservableCollection<AVCallHistory> AvHistories
		{
			get
			{
				return this.avHistories;
			}
		}

		public ObservableCollection<MyMessageSession> ModelOfMessageList
		{
			get
			{
				return this.modelOfMessageList;
			}
		}

		public bool Start()
		{
			this.fileFullPath = this.serviceManager.BuildStoragePath("history.xml");
			new System.Threading.Thread(new System.Threading.ThreadStart(this.LoadHistory)).Start();
			return true;
		}

		public bool Stop()
		{
			return true;
		}

		public HistoryService(ServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
			this.avSessions = serviceManager.ServiceRealizeService.AvSessionMgr.Sessions;
			this.messageSessions = serviceManager.ServiceRealizeService.MsgSessionMgr.Sessions;
			this.avHistories = new ObservableCollection<AVCallHistory>();
			this.modelOfMessageList = new ObservableCollection<MyMessageSession>();
			this.deferredSaveTimer = new System.Timers.Timer(2500.0);
			this.deferredSaveTimer.AutoReset = false;
			this.deferredSaveTimer.Elapsed += delegate(object param0, ElapsedEventArgs param1)
			{
				this.ImmediateSave();
			};
			this.xmlSerializer = new XmlSerializer(typeof(MyObservableCollection<HistoryItem>));
			this.avSessions.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnAvSessionCollectionChanged);
			this.messageSessions.CollectionChanged += new NotifyCollectionChangedEventHandler(this.OnMessageCollectionChanged);
		}

		public void OnAvSessionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				foreach (object item in e.NewItems)
				{
					MySipSession hisSession = item as MySipSession;
					AVCallHistory HisCall = new AVCallHistory(false, hisSession.RemotePartyUri, hisSession.Id, hisSession.IsOutgoing, false);
					HisCall.StartTime = System.DateTime.Now;
					HisCall.EndTime = System.DateTime.Now;
					this.avHistories.Add(HisCall);
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				foreach (object item in e.OldItems)
				{
					MySipSession hisSession = item as MySipSession;
					AVCallHistory cr = new AVCallHistory(false, hisSession.Time, System.DateTime.Now, hisSession.RemotePartyUri, hisSession.Id, hisSession.IsOutgoing, hisSession.IsConnected);
					for (int i = 0; i < this.avHistories.Count; i++)
					{
						if (this.avHistories[i].SipSessionId == hisSession.Id)
						{
							this.avHistories.Remove(this.avHistories[i]);
							this.avHistories.Add(cr);
						}
					}
				}
				break;
			case NotifyCollectionChangedAction.Reset:
				this.avHistories.Clear();
				break;
			}
		}

		public void OnMessageCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				foreach (object item in e.NewItems)
				{
					MyMessageSession MsgSession = item as MyMessageSession;
					MsgSession.PropertyChanged += new PropertyChangedEventHandler(this.MsgSession_PropertyChanged);
					this.modelOfMessageList.Add(MsgSession);
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				foreach (object item in e.OldItems)
				{
					MyMessageSession MsgSession = item as MyMessageSession;
					for (int i = 0; i < this.modelOfMessageList.Count; i++)
					{
						if (this.modelOfMessageList[i].Id == MsgSession.Id)
						{
							this.modelOfMessageList.Remove(this.modelOfMessageList[i]);
							this.modelOfMessageList.Add(MsgSession);
						}
					}
				}
				break;
			case NotifyCollectionChangedAction.Reset:
				this.modelOfMessageList.Clear();
				break;
			}
		}

		public void MsgSession_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}

		public void AddEvent(HistoryItem @event)
		{
			this.events.Insert(0, @event);
			HistoryEventArgs eargs = new HistoryEventArgs(HistoryEventTypes.ADDED);
			eargs.AddExtra("event", @event);
			EventHandlerTrigger.TriggerEvent<HistoryEventArgs>(this.onHistoryEvent, this, eargs);
			this.DeferredSave();
		}

		public void UpdateEvent(HistoryItem @event)
		{
			HistoryEventArgs eargs = new HistoryEventArgs(HistoryEventTypes.UPDATED);
			eargs.AddExtra("event", @event);
			EventHandlerTrigger.TriggerEvent<HistoryEventArgs>(this.onHistoryEvent, this, eargs);
			this.DeferredSave();
		}

		public void DeleteEvent(HistoryItem @event)
		{
			this.events.Remove(@event);
			HistoryEventArgs eargs = new HistoryEventArgs(HistoryEventTypes.REMOVED);
			eargs.AddExtra("event", @event);
			EventHandlerTrigger.TriggerEvent<HistoryEventArgs>(this.onHistoryEvent, this, eargs);
			this.DeferredSave();
		}

		public void DeleteEvent(int location)
		{
			if (location < 0 || location >= this.events.Count)
			{
				HistoryService.LOG.Error("Index OutOfRange");
			}
			else
			{
				HistoryItem @event = this.events[location];
				this.DeleteEvent(@event);
			}
		}

		public void Clear()
		{
			this.events.Clear();
			EventHandlerTrigger.TriggerEvent<HistoryEventArgs>(this.onHistoryEvent, this, new HistoryEventArgs(HistoryEventTypes.RESET));
			this.DeferredSave();
		}

		private void DeferredSave()
		{
			this.deferredSaveTimer.Stop();
			this.deferredSaveTimer.Start();
		}

		private bool ImmediateSave()
		{
			bool result;
			lock (this.events)
			{
				HistoryService.LOG.Debug("Saving history...");
				try
				{
					using (System.IO.StreamWriter writer = new System.IO.StreamWriter(this.fileFullPath))
					{
						this.xmlSerializer.Serialize(writer, this.events);
						writer.Flush();
						writer.Close();
					}
					result = true;
					return result;
				}
				catch (System.IO.IOException ioe)
				{
					HistoryService.LOG.Error("Failed to save history", ioe);
				}
			}
			result = false;
			return result;
		}

		private void LoadHistory()
		{
			this.loading = true;
			HistoryService.LOG.Debug(string.Format("Loading history from {0}", this.fileFullPath));
			try
			{
				if (!System.IO.File.Exists(this.fileFullPath))
				{
					HistoryService.LOG.Debug(string.Format("{0} doesn't exist, trying to create new one", this.fileFullPath));
					System.IO.File.Create(this.fileFullPath).Close();
					this.events = new MyObservableCollection<HistoryItem>();
					this.ImmediateSave();
				}
				using (System.IO.StreamReader reader = new System.IO.StreamReader(this.fileFullPath))
				{
					try
					{
						this.events = (this.xmlSerializer.Deserialize(reader) as MyObservableCollection<HistoryItem>);
					}
					catch (System.InvalidOperationException ie)
					{
						HistoryService.LOG.Error("Failed to load history", ie);
						reader.Close();
						System.IO.File.Delete(this.fileFullPath);
					}
				}
			}
			catch (System.Exception e)
			{
				HistoryService.LOG.Error("Failed to load history", e);
			}
			this.loading = false;
			EventHandlerTrigger.TriggerEvent<HistoryEventArgs>(this.onHistoryEvent, this, new HistoryEventArgs(HistoryEventTypes.RESET));
		}
	}
}
