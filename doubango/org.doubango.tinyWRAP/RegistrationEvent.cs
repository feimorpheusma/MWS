using System;
using System.Runtime.InteropServices;

namespace org.doubango.tinyWRAP
{
	public class RegistrationEvent : SipEvent
	{
		private HandleRef swigCPtr;

		internal RegistrationEvent(IntPtr cPtr, bool cMemoryOwn) : base(tinyWRAPPINVOKE.RegistrationEvent_SWIGUpcast(cPtr), cMemoryOwn)
		{
			this.swigCPtr = new HandleRef(this, cPtr);
		}

		internal static HandleRef getCPtr(RegistrationEvent obj)
		{
			return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
		}

		~RegistrationEvent()
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
						tinyWRAPPINVOKE.delete_RegistrationEvent(this.swigCPtr);
					}
					this.swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
				GC.SuppressFinalize(this);
				base.Dispose();
			}
		}

		public tsip_register_event_type_t getType()
		{
			return (tsip_register_event_type_t)tinyWRAPPINVOKE.RegistrationEvent_getType(this.swigCPtr);
		}

		public RegistrationSession getSession()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.RegistrationEvent_getSession(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new RegistrationSession(cPtr, false);
		}

		public RegistrationSession takeSessionOwnership()
		{
			IntPtr cPtr = tinyWRAPPINVOKE.RegistrationEvent_takeSessionOwnership(this.swigCPtr);
			return (cPtr == IntPtr.Zero) ? null : new RegistrationSession(cPtr, true);
		}
	}
}
