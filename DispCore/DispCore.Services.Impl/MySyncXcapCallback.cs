using DispCore.Models;
using log4net;
using org.doubango.tinyWRAP;
using System;
using System.Threading;

namespace DispCore.Services.Impl
{
	internal class MySyncXcapCallback : XcapCallback
	{
		private static readonly ILog LOG = LogManager.GetLogger(typeof(MySyncXcapCallback));

		private readonly StackService stackService;

		private MyXcapMessage lastMessage;

		internal MyXcapMessage LastMessage
		{
			get
			{
				return this.lastMessage;
			}
		}

		internal StackService StackService
		{
			get
			{
				return this.stackService;
			}
		}

		internal MySyncXcapCallback(StackService stackService)
		{
			this.stackService = stackService;
		}

		public override int onEvent(XcapEvent e)
		{
			switch (e.getType())
			{
			case thttp_event_type_t.thttp_event_dialog_started:
				this.lastMessage = null;
				break;
			case thttp_event_type_t.thttp_event_message:
			case thttp_event_type_t.thttp_event_auth_failed:
				this.lastMessage = new MyXcapMessage(e.getXcapMessage());
				break;
			case thttp_event_type_t.thttp_event_dialog_terminated:
				if (this.StackService.XCapStack.Synchronizer != null)
				{
					try
					{
						this.StackService.XCapStack.Synchronizer.Release();
					}
					catch (SemaphoreFullException ex)
					{
						MySyncXcapCallback.LOG.Error(ex);
					}
				}
				break;
			}
			return 0;
		}
	}
}
