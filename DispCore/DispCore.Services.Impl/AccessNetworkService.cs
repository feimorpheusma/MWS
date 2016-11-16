using DispCore.Events;
using DispCore.Events.Sip;
using DispCore.Models;
using log4net;
using System;
using System.Timers;

namespace DispCore.Services.Impl
{
	public class AccessNetworkService : IAccessNetworkService, IService
	{
		private static ILog LOG = LogManager.GetLogger(typeof(AccessNetworkService));

		private MyRegistrationSession regSession;

		private MyOptionsSession heartbeatSession;

		private ANStatus anStatus;

		private Timer keepAliveTimer;

		private Timer waitKeepAliveRspTimer;

		private bool isRegistered;

		private ServiceManager serviceManager;

		private int elapsedCount;

		public event System.EventHandler<AccessNetworkEventArgs> onAccessNetworkEvent;

		public MyRegistrationSession RegSession
		{
			get
			{
				return this.regSession;
			}
		}

		public ANStatus AnStatus
		{
			get
			{
				return this.anStatus;
			}
		}

		public bool IsRegistered
		{
			get
			{
				return this.isRegistered;
			}
		}

		public AccessNetworkService(ServiceManager manager)
		{
			this.serviceManager = manager;
			this.serviceManager.StackService.onStackEvent += new System.EventHandler<StackEventArgs>(this.OnStackEvent);
			this.serviceManager.StackService.onRegistrationEvent += new System.EventHandler<RegistrationEventArgs>(this.onRegistrationEvent);
			this.anStatus = ANStatus.IDLE;
			this.isRegistered = false;
			this.keepAliveTimer = new Timer();
			this.keepAliveTimer.Interval = 10000.0;
			this.keepAliveTimer.Elapsed += new ElapsedEventHandler(this.KeepAliveTimerHandler);
			this.waitKeepAliveRspTimer = new Timer();
			this.waitKeepAliveRspTimer.Interval = 3000.0;
			this.waitKeepAliveRspTimer.Elapsed += new ElapsedEventHandler(this.WaitKeepAliveRspTimerHandler);
			this.elapsedCount = 0;
		}

		~AccessNetworkService()
		{
			this.serviceManager.StackService.onStackEvent -= new System.EventHandler<StackEventArgs>(this.OnStackEvent);
			this.serviceManager.StackService.onRegistrationEvent -= new System.EventHandler<RegistrationEventArgs>(this.onRegistrationEvent);
		}

		public bool Start()
		{
			return true;
		}

		public bool Stop()
		{
			this.Unregister();
			return true;
		}

		public bool Register()
		{
			if (!this.serviceManager.StackService.SipStackStarted)
			{
				this.serviceManager.StackService.StartSipStack();
				this.anStatus = ANStatus.STACK_STARTING;
			}
			else
			{
				this.anStatus = ANStatus.STACK_STARTED;
				if (this.regSession == null)
				{
					this.regSession = new MyRegistrationSession(this.serviceManager.StackService.SipStack);
				}
				this.serviceManager.StackService.SipStackCfg();
				this.regSession.SigCompId = this.serviceManager.StackService.SipStack.SigCompId;
				this.regSession.FromUri = this.serviceManager.StackService.SipStack.SelfPreferences.impu;
				this.regSession.register();
			}
			return true;
		}

		public bool Unregister()
		{
			if (this.regSession != null)
			{
				this.regSession.unregister();
			}
			if (this.serviceManager.StackService.SipStackStarted)
			{
				this.serviceManager.StackService.StopSipStack();
			}
			return true;
		}

		public void OnStackEvent(object sender, StackEventArgs e)
		{
			switch (e.Type)
			{
			case StackEventTypes.START_OK:
				if (this.anStatus == ANStatus.STACK_STARTING)
				{
					this.anStatus = ANStatus.STACK_STARTED;
					if (this.regSession == null)
					{
						this.regSession = new MyRegistrationSession(this.serviceManager.StackService.SipStack);
					}
					this.regSession.SigCompId = this.serviceManager.StackService.SipStack.SigCompId;
					this.regSession.FromUri = this.serviceManager.StackService.SipStack.SelfPreferences.impu;
					this.regSession.register();
				}
				break;
			case StackEventTypes.STARING:
				this.anStatus = ANStatus.STACK_STARTING;
				break;
			case StackEventTypes.START_NOK:
				this.anStatus = ANStatus.IDLE;
				break;
			case StackEventTypes.STOP_OK:
				this.anStatus = ANStatus.IDLE;
				break;
			case StackEventTypes.STOPPING:
				this.anStatus = ANStatus.STACK_STOPPING;
				break;
			case StackEventTypes.STOP_NOK:
				this.anStatus = ANStatus.STACK_STOPPING;
				break;
			}
			EventHandlerTrigger.TriggerEvent<AccessNetworkEventArgs>(this.onAccessNetworkEvent, this, new AccessNetworkEventArgs(AccessNetworkEventTypes.ANET_LOGIN, this.anStatus, e.Phrase));
		}

		public void onRegistrationEvent(object sender, RegistrationEventArgs e)
		{
			switch (e.Type)
			{
			case RegistrationEventTypes.REGISTRATION_OK:
				this.anStatus = ANStatus.INSERVICE;
				this.isRegistered = true;
				break;
			case RegistrationEventTypes.REGISTRATION_NOK:
				this.anStatus = ANStatus.STACK_STARTED;
				break;
			case RegistrationEventTypes.REGISTRATION_INPROGRESS:
				this.anStatus = ANStatus.REGISTERING;
				break;
			case RegistrationEventTypes.UNREGISTRATION_OK:
				this.anStatus = ANStatus.UNREGISTERED;
				this.isRegistered = false;
				this.StopHeartbeatDetector();
				break;
			case RegistrationEventTypes.UNREGISTRATION_NOK:
				this.anStatus = ANStatus.INSERVICE;
				break;
			case RegistrationEventTypes.UNREGISTRATION_INPROGRESS:
				this.anStatus = ANStatus.UNREGISTERING;
				break;
			}
			EventHandlerTrigger.TriggerEvent<AccessNetworkEventArgs>(this.onAccessNetworkEvent, this, new AccessNetworkEventArgs(AccessNetworkEventTypes.ANET_LOGIN, this.anStatus, e.Phrase));
		}

		public void StartHeartbeatDetector()
		{
			this.keepAliveTimer.AutoReset = true;
			this.keepAliveTimer.Start();
		}

		public void StopHeartbeatDetector()
		{
			this.keepAliveTimer.Stop();
		}

		public void KeepAliveTimerHandler(object sender, ElapsedEventArgs e)
		{
			string toUri = "sip:99999999@" + this.serviceManager.ConfigurationService.NetworkCfg.ProxyHost + ":" + this.serviceManager.ConfigurationService.NetworkCfg.ProxyPort;
			MyOptionsSession session = new MyOptionsSession(this.serviceManager.StackService.SipStack, toUri);
			session.Send();
			this.waitKeepAliveRspTimer.Start();
		}

		public void WaitKeepAliveRspTimerHandler(object sender, ElapsedEventArgs e)
		{
			this.waitKeepAliveRspTimer.Stop();
			this.elapsedCount++;
			if (this.elapsedCount > 3)
			{
				this.elapsedCount = 0;
			}
		}
	}
}
