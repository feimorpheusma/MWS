using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class PublicationEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal PublicationEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.PublicationEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(PublicationEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~PublicationEvent()
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
						tinyWRAPPINVOKE.delete_PublicationEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_publish_event_type_t getType()
		{
			return (tsip_publish_event_type_t)tinyWRAPPINVOKE.PublicationEvent_getType(this.swigCPtr);
		}

		public PublicationSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.PublicationEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new PublicationSession(cPtr, false);
		}

		public PublicationSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.PublicationEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new PublicationSession(cPtr, false);
		}
	}
}
