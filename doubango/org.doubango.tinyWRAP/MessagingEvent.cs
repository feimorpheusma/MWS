using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class MessagingEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal MessagingEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.MessagingEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(MessagingEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~MessagingEvent()
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
						tinyWRAPPINVOKE.delete_MessagingEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_message_event_type_t getType()
		{
			return (tsip_message_event_type_t)tinyWRAPPINVOKE.MessagingEvent_getType(this.swigCPtr);
		}

		public MessagingSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MessagingEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MessagingSession(cPtr, false);
		}

		public MessagingSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.MessagingEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new MessagingSession(cPtr, true);
		}
	}
}
