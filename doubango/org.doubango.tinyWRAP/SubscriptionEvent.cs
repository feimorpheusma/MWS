using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class SubscriptionEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal SubscriptionEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.SubscriptionEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(SubscriptionEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~SubscriptionEvent()
		{
			this.Dispose();
		}

		public override void Dispose()
		{
			lock (this)
			{
				if (this.swigCPtr.Handle != IntPtr.Zero)
				{
					if (this.swigCMemOwn)
					{
						this.swigCMemOwn = false;
						tinyWRAPPINVOKE.delete_SubscriptionEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_subscribe_event_type_t getType()
		{
			return (tsip_subscribe_event_type_t)tinyWRAPPINVOKE.SubscriptionEvent_getType(this.swigCPtr);
		}

		public SubscriptionSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SubscriptionEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new SubscriptionSession(cPtr, false);
		}

		public SubscriptionSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.SubscriptionEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new SubscriptionSession(cPtr, false);
		}
	}
}
